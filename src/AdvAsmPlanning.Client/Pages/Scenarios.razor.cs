using AdvAsmPlanning.Application;
using AdvAsmPlanning.Client.Constants;
using AdvAsmPlanning.Client.Pages.Base;
using Microsoft.AspNetCore.Components;

namespace AdvAsmPlanning.Client.Pages;

public partial class Scenarios : BaseGridPage<ScenarioDto>
{
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    private List<ScenarioDto> _scenarios = [];
    private List<ScenarioDto> _filteredScenarios = [];
    private ScenarioDto? _scenarioToInsert;
    private ScenarioDto? _scenarioToUpdate;

    // Filter variables
    private string? _codeFilter;
    private string? _descriptionFilter;
    private string? _startMessageFilter;
    private string? _consolidationNumberFilter;

    // Pagination options
    private readonly int[] _pageSizeOptions = [50, 100, 200, 500];

    protected override async Task OnInitializedAsync()
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        if (IsLoading) return;

        IsLoading = true;
        StateHasChanged();

        try
        {
            var response = await HttpHelper.PostAsync<ApiResponseDto<IEnumerable<ScenarioDto>>>(
                ApiRoutes.GetAllScenarios);

            if (response?.Success != true || response?.Data == null)
            {
                ShowError(response?.Message ?? "Failed to load scenarios");
                return;
            }

            _scenarios = response.Data.ToList();
            ApplyFilters();
            ShowSuccess("Data refreshed successfully");
        }
        catch (Exception ex)
        {
            HandleException(ex, "loading scenarios");
        }
        finally
        {
            IsLoading = false;
            StateHasChanged();
        }
    }

    private void ApplyFilters()
    {
        if (_scenarios?.Count == 0)
        {
            _filteredScenarios = [];
            StateHasChanged();
            return;
        }

        var query = _scenarios?.AsQueryable() ?? Enumerable.Empty<ScenarioDto>().AsQueryable();

        // Apply filters using short-circuiting
        query = !string.IsNullOrWhiteSpace(_codeFilter)
            ? query.Where(s => s.Code.Contains(_codeFilter, StringComparison.OrdinalIgnoreCase))
            : query;

        query = !string.IsNullOrWhiteSpace(_descriptionFilter)
            ? query.Where(s => s.Description.Contains(_descriptionFilter, StringComparison.OrdinalIgnoreCase))
            : query;

        query = !string.IsNullOrWhiteSpace(_startMessageFilter)
            ? query.Where(s => !string.IsNullOrEmpty(s.StartMessage) && 
                             s.StartMessage.Contains(_startMessageFilter, StringComparison.OrdinalIgnoreCase))
            : query;

        query = !string.IsNullOrWhiteSpace(_consolidationNumberFilter)
            ? query.Where(s => !string.IsNullOrEmpty(s.ConsolidationNumber) && 
                             s.ConsolidationNumber.Contains(_consolidationNumberFilter, StringComparison.OrdinalIgnoreCase))
            : query;

        _filteredScenarios = query.ToList();
        StateHasChanged();
    }

    // Consolidated filter change handler using DRY principle
    private void OnFilterChanged(string? value, ref string? filterField)
    {
        filterField = value;
        ApplyFilters();
    }

    private void OnCodeFilterChanged(string? value) => OnFilterChanged(value, ref _codeFilter);
    private void OnDescriptionFilterChanged(string? value) => OnFilterChanged(value, ref _descriptionFilter);
    private void OnStartMessageFilterChanged(string? value) => OnFilterChanged(value, ref _startMessageFilter);
    private void OnConsolidationNumberFilterChanged(string? value) => OnFilterChanged(value, ref _consolidationNumberFilter);

    private async Task EditRowAsync(ScenarioDto scenario)
    {
        _scenarioToUpdate = scenario;
        await Grid!.EditRow(scenario);
    }

    private async Task SaveRowAsync(ScenarioDto scenario)
    {
        await Grid!.UpdateRow(scenario);
    }

    private void CancelEdit(ScenarioDto scenario)
    {
        Grid!.CancelEditRow(scenario);
        _scenarioToUpdate = null;
    }

    private async Task DeleteRowAsync(ScenarioDto scenario)
    {
        if (scenario == null)
        {
            ShowError("No scenario selected");
            return;
        }

        try
        {
            var confirmed = await ConfirmActionAsync(
                $"Are you sure you want to delete scenario '{scenario.Code}'?",
                "Confirm Delete");

            if (!confirmed) return;

            var response = await HttpHelper.PostAsync<long, ApiResponse>(
                ApiRoutes.DeleteScenario,
                scenario.Id);

            if (response?.Success != true)
            {
                ShowError(response?.Message ?? "Failed to delete scenario");
                return;
            }

            ShowSuccess("Scenario deleted successfully");
            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            HandleException(ex, "deleting scenario");
        }
    }

    private async Task InsertRowAsync()
    {
        _scenarioToInsert = new ScenarioDto
        {
            Code = string.Empty,
            Description = string.Empty,
            ActualScenario = false,
            FxFlag = false,
            PostingLayerId = 1,
            PlanningScenarioGroupId = 1
        };

        await Grid!.InsertRow(_scenarioToInsert);
    }

    private async Task OnRowUpdateAsync(ScenarioDto scenario)
    {
        try
        {
            var isNew = scenario == _scenarioToInsert || scenario.Id == 0;
            var response = isNew
                ? await CreateScenarioAsync(scenario)
                : await UpdateScenarioAsync(scenario);

            if (response?.Success != true)
            {
                ShowError(response?.Message ?? $"Failed to {(isNew ? "create" : "update")} scenario");
                return;
            }

            if (isNew)
            {
                scenario.Id = response.Data?.Id ?? 0;
                _scenarioToInsert = null;
                ShowSuccess("Scenario created successfully");
            }
            else
            {
                _scenarioToUpdate = null;
                ShowSuccess("Scenario updated successfully");
            }

            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            HandleException(ex, "saving scenario");
        }
    }

    private async Task<ApiResponseDto<ScenarioDto>?> CreateScenarioAsync(ScenarioDto scenario)
    {
        return await HttpHelper.PostAsync<ScenarioDto, ApiResponseDto<ScenarioDto>>(
            ApiRoutes.CreateScenario,
            scenario);
    }

    private async Task<ApiResponseDto<ScenarioDto>?> UpdateScenarioAsync(ScenarioDto scenario)
    {
        return await HttpHelper.PostAsync<ScenarioDto, ApiResponseDto<ScenarioDto>>(
            ApiRoutes.UpdateScenario,
            scenario);
    }

    private async Task OnRowCreateAsync(ScenarioDto scenario)
    {
        await OnRowUpdateAsync(scenario);
    }

    private async Task OnOpenScenarioClickAsync(ScenarioDto scenario)
    {
        if (scenario.ActualScenario)
        {
            await DialogService.Alert(
                "This scenario is locked and cannot be selected",
                "Locked Scenario",
                new AlertOptions { OkButtonText = "OK" });
        }
        else
        {
            // Option 1: Query Parameter (current - bookmarkable, survives refresh)
            var description = Uri.EscapeDataString(scenario.Description ?? string.Empty);
            NavigationManager.NavigateTo($"/main-grid?description={description}");
            
            // Option 2: NavigationState (alternative - cleaner, but doesn't survive refresh)
            // NavigationManager.NavigateTo("/main-grid", new NavigationOptions 
            // { 
            //     State = new Dictionary<string, object?> { { "scenarioDescription", scenario.Description } }
            // });
        }
    }
}

