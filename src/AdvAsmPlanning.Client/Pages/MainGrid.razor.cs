using AdvAsmPlanning.Application;
using AdvAsmPlanning.Client.Constants;
using AdvAsmPlanning.Client.Helper;
using AdvAsmPlanning.Client.Models;
using AdvAsmPlanning.Client.Pages.Base;
using Microsoft.AspNetCore.Components;

namespace AdvAsmPlanning.Client.Pages;

public partial class MainGrid : BaseGridPage<MainGridViewModel>
{
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    private List<MainGridDto>? _mainGridsModel;
    private List<MainGridViewModel> _filteredMainGrids = [];
    private string _scenarioDescription = "Main Grid";

    // Filter variables
    private string? _clientFilter;
    private string? _customerFilter;
    private string? _projectFilter;
    private string? _sizeFilter;
    private string? _goFindFilter;
    private string? _commentFilter;
    private string? _accountNoFilter;
    private string? _departmentNoFilter;

    // Dropdown filter options
    private readonly List<string> _sizeOptions = ["Small", "Medium", "Large", "Extra Large"];
    private readonly List<string> _goFindOptions = ["Yes", "No", "Pending"];

    // Pagination options
    private readonly int[] _pageSizeOptions = [200, 300, 500, 1000];


    // Monthly filter logic
    private readonly Dictionary<string, decimal?> _monthlyFilters = [];

    protected override async Task OnInitializedAsync()
    {
        // Read scenario description from query parameter using helper
        var description = NavigationHelper.GetQueryParameter(NavigationManager, "description");
        if (!string.IsNullOrWhiteSpace(description))
        {
            _scenarioDescription = description;
        }

        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        if (IsLoading) return;

        IsLoading = true;
        StateHasChanged();

        try
        {
            ShowInfo("Refreshing data...");
            var response = await HttpHelper.PostAsync<ApiResponseDto<IEnumerable<MainGridDto>>>(ApiRoutes.GetAllMainGrids);
            
            if (response?.Success != true || response?.Data == null)
            {
                ShowError(response?.Message ?? "Failed to load main grid data");
                return;
            }

            _mainGridsModel = response.Data.ToList();
            ApplyFilters();
            ShowSuccess("Data refreshed successfully");
        }
        catch (Exception ex)
        {
            HandleException(ex, "loading data");
        }
        finally
        {
            IsLoading = false;
            StateHasChanged();
        }
    }

    private void ApplyFilters()
    {
        if (_mainGridsModel?.Count == 0)
        {
            _filteredMainGrids = [];
            StateHasChanged();
            return;
        }

        var query = _mainGridsModel?.Select(MainGridViewModel.FromDto).AsQueryable() 
                   ?? Enumerable.Empty<MainGridViewModel>().AsQueryable();

        // Apply string filters using short-circuiting
        query = ApplyStringFilter(query, _clientFilter, item => item.Client);
        query = ApplyStringFilter(query, _customerFilter, item => item.Customer);
        query = ApplyStringFilter(query, _projectFilter, item => item.Project);
        query = ApplyStringFilter(query, _commentFilter, item => item.Comment);
        query = ApplyStringFilter(query, _accountNoFilter, item => item.AccountNo);
        query = ApplyStringFilter(query, _departmentNoFilter, item => item.DepartmentNo);

        // Apply equality filters using short-circuiting
        query = !string.IsNullOrWhiteSpace(_sizeFilter)
            ? query.Where(item => item.SizeProject.Equals(_sizeFilter, StringComparison.OrdinalIgnoreCase))
            : query;

        query = !string.IsNullOrWhiteSpace(_goFindFilter)
            ? query.Where(item => item.GoFind.Equals(_goFindFilter, StringComparison.OrdinalIgnoreCase))
            : query;

        // Apply monthly filters
        query = ApplyMonthlyFilters(query);

        _filteredMainGrids = query.ToList();
        StateHasChanged();
    }

    private IQueryable<MainGridViewModel> ApplyStringFilter(
        IQueryable<MainGridViewModel> query,
        string? filterValue,
        Func<MainGridViewModel, string> propertySelector)
    {
        return string.IsNullOrWhiteSpace(filterValue)
            ? query
            : query.Where(item => propertySelector(item).Contains(filterValue, StringComparison.OrdinalIgnoreCase));
    }

    private IQueryable<MainGridViewModel> ApplyMonthlyFilters(IQueryable<MainGridViewModel> query)
    {
        foreach (var filter in _monthlyFilters.Where(f => f.Value.HasValue))
        {
            var property = typeof(MainGridViewModel).GetProperty(filter.Key);
            if (property == null) continue;

            // Convert to enumerable to use reflection, then back to queryable
            var filteredItems = query.AsEnumerable().Where(item =>
            {
                var value = property.GetValue(item) as decimal?;
                return value.HasValue && value.Value == filter.Value!.Value;
            });
            
            query = filteredItems.AsQueryable();
        }
        return query;
    }

    // Consolidated filter change handlers using DRY principle
    private void OnFilterChanged(string? value, ref string? filterField)
    {
        filterField = value;
        ApplyFilters();
    }

    private void OnClientFilterChanged(string? value) => OnFilterChanged(value, ref _clientFilter);
    private void OnCustomerFilterChanged(string? value) => OnFilterChanged(value, ref _customerFilter);
    private void OnProjectFilterChanged(string? value) => OnFilterChanged(value, ref _projectFilter);
    private void OnCommentFilterChanged(string? value) => OnFilterChanged(value, ref _commentFilter);
    private void OnAccountNoFilterChanged(string? value) => OnFilterChanged(value, ref _accountNoFilter);
    private void OnDepartmentNoFilterChanged(string? value) => OnFilterChanged(value, ref _departmentNoFilter);

    private void OnSizeFilterChanged(object? value)
    {
        _sizeFilter = value?.ToString();
        ApplyFilters();
    }

    private void OnGoFindFilterChanged(object? value)
    {
        _goFindFilter = value?.ToString();
        ApplyFilters();
    }


    private void OnMonthlyFilterChanged(string month, decimal? value)
    {
        _monthlyFilters[month] = value;
        ApplyFilters();
    }

    private async Task EditRowAsync(MainGridViewModel item)
    {
        await Grid!.EditRow(item);
    }

    private async Task SaveRowAsync(MainGridViewModel item)
    {
        await Grid!.UpdateRow(item);
    }

    private void CancelEdit(MainGridViewModel item)
    {
        Grid!.CancelEditRow(item);
    }

    private async Task DeleteRowAsync(MainGridViewModel item)
    {
        if (item == null)
        {
            ShowError("No item selected");
            return;
        }

        try
        {
            var confirmed = await ConfirmActionAsync(
                $"Are you sure you want to delete main grid for {item.Client}?",
                "Delete Main Grid");

            if (!confirmed) return;

            var response = await HttpHelper.PostAsync<ApiResponse>(ApiRoutes.DeleteMainGrid, item.Id);

            if (response?.Success != true)
            {
                ShowError(response?.Message ?? "Failed to delete main grid");
                return;
            }

            ShowSuccess("Main grid deleted successfully");
            await LoadDataAsync();
            
            if (Grid != null)
            {
                await Grid.Reload();
            }
        }
        catch (Exception ex)
        {
            HandleException(ex, "deleting main grid");
        }
    }

    private async Task InsertRowAsync()
    {
        var newItem = new MainGridViewModel
        {
            Client = string.Empty,
            Customer = string.Empty,
            Project = string.Empty,
            SizeProject = string.Empty,
            GoFind = string.Empty,
            Comment = string.Empty,
            Actuals = []
        };

        await Grid!.InsertRow(newItem);
    }

    private async Task OnRowUpdateAsync(MainGridViewModel item)
    {
        try
        {
            var isNew = item.Id == 0;
            var dto = item.ToDto();
            
            if (!isNew)
            {
                dto.Id = item.Id;
            }

            var response = isNew
                ? await CreateItemAsync(dto)
                : await UpdateItemAsync(dto);

            if (response?.Success != true)
            {
                ShowError(response?.Message ?? $"Failed to {(isNew ? "create" : "update")} main grid");
                return;
            }

            if (isNew)
            {
                item.Id = response.Data?.Id ?? 0;
                ShowSuccess("Main grid created successfully");
            }
            else
            {
                ShowSuccess("Main grid updated successfully");
            }

            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            HandleException(ex, "saving main grid");
        }
    }

    private async Task<ApiResponseDto<MainGridDto>?> CreateItemAsync(MainGridDto dto)
    {
        return await HttpHelper.PostAsync<MainGridDto, ApiResponseDto<MainGridDto>>(
            ApiRoutes.CreateMainGrid,
            dto);
    }

    private async Task<ApiResponseDto<MainGridDto>?> UpdateItemAsync(MainGridDto dto)
    {
        return await HttpHelper.PostAsync<MainGridDto, ApiResponseDto<MainGridDto>>(
            ApiRoutes.UpdateMainGrid,
            dto);
    }

    private async Task OnRowCreateAsync(MainGridViewModel item)
    {
        await OnRowUpdateAsync(item);
    }
}









