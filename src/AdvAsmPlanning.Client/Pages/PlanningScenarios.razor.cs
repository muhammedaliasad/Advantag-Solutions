using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Client.Constants;
using AdvAsmPlanning.Client.Helper;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace AdvAsmPlanning.Client.Pages;

public partial class PlanningScenarios
{
    [Inject] private HttpHelper HttpHelper { get; set; } = default!;
    [Inject] private NotificationService NotificationService { get; set; } = default!;
    [Inject] private DialogService DialogService { get; set; } = default!;
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    private RadzenDataGrid<PlanningScenarioDto>? grid;
    private List<PlanningScenarioDto> planningScenarios = new();
    private List<PlanningScenarioDto> filteredScenarios = new();
    private PlanningScenarioDto? scenarioToInsert;
    private PlanningScenarioDto? scenarioToUpdate;
    private bool isLoading = false;

    // Filter variables
    private string? CodeFilter;
    private string? DescriptionFilter;
    private string? StartMessageFilter;
    private string? ConsolidationNumberFilter;

    // Pagination options
    private int[] pageSizeOptions = new int[] { 50, 100, 200, 500 };

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    private async Task LoadData()
    {
        if (isLoading) return; // Prevent multiple simultaneous loads

        isLoading = true;
        StateHasChanged();

        try
        {
            var response = await HttpHelper.PostAsync<ApiResponseDto<IEnumerable<PlanningScenarioDto>>>(
                ApiRoutes.GetAllPlanningScenarios);

            if (response?.Success == true && response.Data != null)
            {
                planningScenarios = response.Data.ToList();
                ApplyFilters();
                NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Data Refreshed", Duration = 2000 });
            }
            else
            {
                ShowNotification("Error", response?.Message ?? "Failed to load planning scenarios", NotificationSeverity.Error);
            }
        }
        catch (Exception ex)
        {
            ShowNotification("Error", $"An error occurred: {ex.Message}", NotificationSeverity.Error);
        }
        finally
        {
            isLoading = false;
            StateHasChanged();
        }
    }

    private void ApplyFilters()
    {
        if (planningScenarios == null)
        {
            filteredScenarios = new List<PlanningScenarioDto>();
            return;
        }

        var query = planningScenarios.AsQueryable();

        if (!string.IsNullOrWhiteSpace(CodeFilter))
            query = query.Where(s => s.Code.Contains(CodeFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(DescriptionFilter))
            query = query.Where(s => s.Description.Contains(DescriptionFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(StartMessageFilter))
            query = query.Where(s => !string.IsNullOrEmpty(s.StartMessage) && s.StartMessage.Contains(StartMessageFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(ConsolidationNumberFilter))
            query = query.Where(s => !string.IsNullOrEmpty(s.ConsolidationNumber) && s.ConsolidationNumber.Contains(ConsolidationNumberFilter, StringComparison.OrdinalIgnoreCase));

        filteredScenarios = query.ToList();
        StateHasChanged();
    }

    private void OnCodeFilterChanged(string? value)
    {
        CodeFilter = value;
        ApplyFilters();
    }

    private void OnDescriptionFilterChanged(string? value)
    {
        DescriptionFilter = value;
        ApplyFilters();
    }

    private void OnStartMessageFilterChanged(string? value)
    {
        StartMessageFilter = value;
        ApplyFilters();
    }

    private void OnConsolidationNumberFilterChanged(string? value)
    {
        ConsolidationNumberFilter = value;
        ApplyFilters();
    }

    private async Task EditRow(PlanningScenarioDto scenario)
    {
        scenarioToUpdate = scenario;
        await grid!.EditRow(scenario);
    }

    private async Task SaveRow(PlanningScenarioDto scenario)
    {
        await grid!.UpdateRow(scenario);
    }

    private void CancelEdit(PlanningScenarioDto scenario)
    {
        grid!.CancelEditRow(scenario);
        scenarioToUpdate = null;
    }

    private async Task DeleteRowClick(PlanningScenarioDto scenario)
    {
        try
        {
            var confirmed = await DialogService.Confirm(
                $"Are you sure you want to delete scenario '{scenario.Code}'?",
                "Confirm Delete",
                new ConfirmOptions { OkButtonText = "Yes", CancelButtonText = "No" });

            if (confirmed == true)
            {
                var response = await HttpHelper.PostAsync<long, ApiResponse>(
                    ApiRoutes.DeletePlanningScenario,
                    scenario.Id);

                if (response?.Success == true)
                {
                    ShowNotification("Success", "Planning scenario deleted successfully", NotificationSeverity.Success);
                    await LoadData();
                }
                else
                {
                    ShowNotification("Error", response?.Message ?? "Failed to delete scenario", NotificationSeverity.Error);
                }
            }
        }
        catch (Exception ex)
        {
            ShowNotification("Error", $"An error occurred: {ex.Message}", NotificationSeverity.Error);
        }
    }

    private async Task InsertRow()
    {
        scenarioToInsert = new PlanningScenarioDto
        {
            Code = string.Empty,
            Description = string.Empty,
            ActualScenario = false,
            FxFlag = false,
            PostingLayerId = 1,
            PlanningScenarioGroupId = 1
        };

        await grid!.InsertRow(scenarioToInsert);
    }

    private async Task OnRowUpdate(PlanningScenarioDto scenario)
    {
        try
        {
            PlanningScenarioDto? updated;

            if (scenario == scenarioToInsert || scenario.Id == 0)
            {
                // New row - create
                var response = await HttpHelper.PostAsync<PlanningScenarioDto, ApiResponseDto<PlanningScenarioDto>>(
                    ApiRoutes.CreatePlanningScenario,
                    scenario);

                if (response?.Success == true)
                {
                    scenario.Id = response.Data.Id;
                    ShowNotification("Success", "Planning scenario created successfully", NotificationSeverity.Success);
                }
                else
                {
                    ShowNotification("Error", response?.Message ?? "Failed to create scenario", NotificationSeverity.Error);
                    return;
                }
                scenarioToInsert = null;
            }
            else
            {
                // Existing row - update
                var response = await HttpHelper.PostAsync<PlanningScenarioDto, ApiResponseDto<PlanningScenarioDto>>(
                    ApiRoutes.UpdatePlanningScenario,
                    scenario);

                updated = response?.Data;

                if (response?.Success == true)
                {
                    ShowNotification("Success", "Planning scenario updated successfully", NotificationSeverity.Success);
                }
                else
                {
                    ShowNotification("Error", response?.Message ?? "Failed to update scenario", NotificationSeverity.Error);
                    return;
                }
            }

            await LoadData();
            scenarioToUpdate = null;
        }
        catch (Exception ex)
        {
            ShowNotification("Error", $"An error occurred: {ex.Message}", NotificationSeverity.Error);
        }
    }

    private async Task OnRowCreate(PlanningScenarioDto scenario)
    {
        await OnRowUpdate(scenario);
    }

    private void OnScenarioClick(PlanningScenarioDto scenario)
    {
        // Navigate to forecast page when scenario code is clicked
        NavigationManager.NavigateTo("/forecasts");
    }

    private async Task OnRowDoubleClick(DataGridRowMouseEventArgs<PlanningScenarioDto> args)
    {
        if (args.Data.ActualScenario)
        {
            // If locked, show dialog
            await DialogService.Alert("This scenario is locked and cannot be selected", "Locked Scenario", new AlertOptions() { OkButtonText = "OK" });
        }
        else
        {
            // If unlocked, navigate to forecast page
            NavigationManager.NavigateTo("/forecasts");
        }
    }

    private void ShowNotification(string title, string message, NotificationSeverity severity)
    {
        NotificationService.Notify(new NotificationMessage
        {
            Severity = severity,
            Summary = title,
            Detail = message,
            Duration = 4000
        });
    }
}
