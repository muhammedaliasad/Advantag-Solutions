using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Client.Constants;
using AdvAsmPlanning.Client.Helper;
using AdvAsmPlanning.Client.Models;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System.Net.Http.Json;

namespace AdvAsmPlanning.Client.Pages;

public partial class Forecasts : ComponentBase
{
    [Inject] private HttpHelper HttpHelper { get; set; } = null!;
    [Inject] private DialogService DialogService { get; set; } = null!;
    [Inject] private NotificationService NotificationService { get; set; } = null!;
    [Inject] private IHttpClientFactory HttpClientFactory { get; set; } = null!;

    private List<ForecastDto>? forecastsModel;
    private List<ForecastViewModel> filteredForecasts = new();
    private RadzenDataGrid<ForecastViewModel>? grid;

    // Filter variables
    private string? ClientFilter;
    private string? CustomerFilter;
    private string? ProjectFilter;
    private string? SizeFilter;
    private string? GoFindFilter;
    private string? CommentFilter;
    private string? AccountNoFilter;
    private string? DepartmentNoFilter;

    private void OnClientFilterChanged(string? value)
    {
        ClientFilter = value;
        ApplyFilters();
    }

    private void OnCustomerFilterChanged(string? value)
    {
        CustomerFilter = value;
        ApplyFilters();
    }

    private void OnProjectFilterChanged(string? value)
    {
        ProjectFilter = value;
        ApplyFilters();
    }

    private void OnCommentFilterChanged(string? value)
    {
        CommentFilter = value;
        ApplyFilters();
    }

    private void OnAccountNoFilterChanged(string? value)
    {
        AccountNoFilter = value;
        ApplyFilters();
    }

    private void OnDepartmentNoFilterChanged(string? value)
    {
        DepartmentNoFilter = value;
        ApplyFilters();
    }

    private void OnSizeFilterChanged(object? value)
    {
        SizeFilter = value?.ToString();
        ApplyFilters();
    }

    private void OnGoFindFilterChanged(object? value)
    {
        GoFindFilter = value?.ToString();
        ApplyFilters();
    }

    // Dropdown filter options
    private List<string> sizeOptions = new() { "Small", "Medium", "Large", "Extra Large" };
    private List<string> goFindOptions = new() { "Yes", "No", "Pending" };

    // Pagination options
    private int[] pageSizeOptions = new int[] { 200, 300, 500, 1000 };

    // Dropdown filter variables
    private List<string> businessUnitOptions = new();
    private List<string> divisionOptions = new();
    private List<string> marketOptions = new();
    private List<string> departmentNameOptions = new();
    private List<string> departmentRangeOptions = new();
    private List<string> accountExternalReportOptions = new();
    private List<string> accountGroupOptions = new();
    private List<string> accountSubGroupOptions = new();
    private List<string> accountNameOptions = new();
    private List<string> accountRangeOptions = new();

    // Dropdown filter values
    private string? businessUnitFilter;
    private string? divisionFilter;
    private string? marketFilter;
    private string? departmentNameFilter;
    private string? departmentRangeFilter;
    private string? accountExternalReportFilter;
    private string? accountGroupFilter;
    private string? accountSubGroupFilter;
    private string? accountNameFilter;
    private string? accountRangeFilter;

    protected override async Task OnInitializedAsync()
    {
        await LoadDropdownData();
        await LoadData();
    }

    private async Task LoadDropdownData()
    {
        try
        {
            var httpClient = HttpClientFactory.CreateClient("ASMClient");

            // Load all dropdown options in parallel
            var tasks = new[]
            {
                LoadDropdownOptions(httpClient, "BusinessUnit", businessUnitOptions),
                LoadDropdownOptions(httpClient, "Division", divisionOptions),
                LoadDropdownOptions(httpClient, "Market", marketOptions),
                LoadDropdownOptions(httpClient, "DepartmentName", departmentNameOptions),
                LoadDropdownOptions(httpClient, "DepartmentRange", departmentRangeOptions),
                LoadDropdownOptions(httpClient, "AccountExternalReport", accountExternalReportOptions),
                LoadDropdownOptions(httpClient, "AccountGroup", accountGroupOptions),
                LoadDropdownOptions(httpClient, "AccountSubGroup", accountSubGroupOptions),
                LoadDropdownOptions(httpClient, "AccountName", accountNameOptions),
                LoadDropdownOptions(httpClient, "AccountRange", accountRangeOptions)
            };

            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading dropdown data: {ex.Message}");
        }
    }

    private async Task LoadDropdownOptions(HttpClient httpClient, string key, List<string> targetList)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("api/Dropdown/GetAll", key);
            if (response.IsSuccessStatusCode)
            {
                var dropdowns = await response.Content.ReadFromJsonAsync<List<DropdownDto>>();
                if (dropdowns != null)
                {
                    targetList.Clear();
                    targetList.AddRange(dropdowns.Select(d => d.Label));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading dropdown options for {key}: {ex.Message}");
        }
    }

    // Dropdown filter change handlers
    private void OnBusinessUnitFilterChanged(string? value)
    {
        businessUnitFilter = value;
    }

    private void OnDivisionFilterChanged(string? value)
    {
        divisionFilter = value;
    }

    private void OnMarketFilterChanged(string? value)
    {
        marketFilter = value;
    }

    private void OnDepartmentNameFilterChanged(string? value)
    {
        departmentNameFilter = value;
    }

    private void OnDepartmentRangeFilterChanged(string? value)
    {
        departmentRangeFilter = value;
    }

    private void OnAccountExternalReportFilterChanged(string? value)
    {
        accountExternalReportFilter = value;
    }

    private void OnAccountGroupFilterChanged(string? value)
    {
        accountGroupFilter = value;
    }

    private void OnAccountSubGroupFilterChanged(string? value)
    {
        accountSubGroupFilter = value;
    }

    private void OnAccountNameFilterChanged(string? value)
    {
        accountNameFilter = value;
    }

    private void OnAccountRangeFilterChanged(string? value)
    {
        accountRangeFilter = value;
    }

    private async Task LoadData()
    {
        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Refreshing Data...", Duration = 1000 });
        var response = await HttpHelper.PostAsync<ApiResponseDto<IEnumerable<ForecastDto>>>(ApiRoutes.GetAllForecasts);
        forecastsModel = response.Data.ToList();
        ApplyFilters();
        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Data Refreshed", Duration = 2000 });
    }

    private void ApplyFilters()
    {
        if (forecastsModel == null) return;

        // Convert to ViewModel first to allow filtering on flattened properties
        var query = forecastsModel.Select(ForecastViewModel.FromDto);

        if (!string.IsNullOrWhiteSpace(ClientFilter))
            query = query.Where(f => f.Client.Contains(ClientFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(CustomerFilter))
            query = query.Where(f => f.Customer.Contains(CustomerFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(ProjectFilter))
            query = query.Where(f => f.Project.Contains(ProjectFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(SizeFilter))
            query = query.Where(f => f.SizeProject.Equals(SizeFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(GoFindFilter))
            query = query.Where(f => f.GoFind.Equals(GoFindFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(CommentFilter))
            query = query.Where(f => f.Comment.Contains(CommentFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(AccountNoFilter))
            query = query.Where(f => f.AccountNo.Contains(AccountNoFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(DepartmentNoFilter))
            query = query.Where(f => f.DepartmentNo.Contains(DepartmentNoFilter, StringComparison.OrdinalIgnoreCase));

        // Apply monthly filters
        foreach (var filter in monthlyFilters)
        {
            if (filter.Value.HasValue)
            {
                var property = typeof(ForecastViewModel).GetProperty(filter.Key);
                if (property != null)
                {
                    query = query.Where(f =>
                    {
                        var value = property.GetValue(f) as decimal?;
                        return value.HasValue && value.Value == filter.Value.Value;
                    });
                }
            }
        }

        filteredForecasts = query.ToList();
        StateHasChanged();
    }

    // Monthly filter logic
    private Dictionary<string, decimal?> monthlyFilters = new();

    private void OnMonthlyFilterChanged(string month, decimal? value)
    {
        if (monthlyFilters.ContainsKey(month))
        {
            monthlyFilters[month] = value;
        }
        else
        {
            monthlyFilters.Add(month, value);
        }
        ApplyFilters();
    }

    private async Task EditRow(ForecastViewModel forecast)
    {
        if (grid != null)
        {
            await grid.EditRow(forecast);
        }
    }

    private async Task SaveRow(ForecastViewModel forecast)
    {
        if (grid != null)
        {
            await grid.UpdateRow(forecast);
        }
    }

    private void CancelEdit(ForecastViewModel forecast)
    {
        if (grid != null)
        {
            grid.CancelEditRow(forecast);
        }
    }

    private async Task DeleteRowClick(ForecastViewModel forecast)
    {
        try
        {
            Console.WriteLine($"DeleteRowClick called for forecast ID: {forecast?.Id}");

            if (forecast == null)
            {
                Console.WriteLine("Forecast is null!");
                NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Warning, Summary = "Warning", Detail = "No forecast selected", Duration = 4000 });
                return;
            }

            Console.WriteLine($"Calling DialogService.Confirm for client: {forecast.Client}");
            var confirm = await DialogService.Confirm($"Are you sure you want to delete forecast for {forecast.Client}?", "Delete Forecast", new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" });
            Console.WriteLine($"Dialog result: {confirm}");

            if (confirm == true)
            {
                // Use the correct PostAsync overload and route format
                var response = await HttpHelper.PostAsync<ApiResponseDto>(ApiRoutes.DeleteForecast, forecast.Id);

                if (response != null && response.Success)
                {
                    // Reload data from server to ensure consistency
                    await LoadData();
                    NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Forecast deleted successfully", Duration = 4000 });

                    if (grid != null)
                    {
                        await grid.Reload();
                    }
                }
                else
                {
                    NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Failed to delete forecast", Duration = 4000 });
                }
            }
            else
            {
                Console.WriteLine("User cancelled deletion");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in DeleteRowClick: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = $"An error occurred: {ex.Message}", Duration = 4000 });
        }
    }

    private async Task InsertRow()
    {
        if (grid != null)
        {
            var newForecast = new ForecastViewModel
            {
                Client = "",
                Customer = "",
                Project = "",
                SizeProject = "",
                GoFind = "",
                Comment = "",
                Actuals = new List<ForecastActualDto>()
            };

            await grid.InsertRow(newForecast);
        }
    }

    private async Task OnRowUpdate(ForecastViewModel forecast)
    {
        try
        {
            // Convert ViewModel back to DTO
            var forecastDto = forecast.ToDto();
            ForecastDto? updated;

            if (forecast.Id == 0)
            {
                // New row - request a ForecastDto back from the API
                var response = await HttpHelper.PostAsync<ForecastDto, ApiResponseDto<ForecastDto>>(ApiRoutes.CreateForecast, forecastDto);
                if (response.Success)
                {
                    forecast.Id = response.Data.Id;
                    NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Forecast created successfully", Duration = 4000 });
                }
            }
            else
            {
                // Existing row - use the injected HttpHelper instance for update
                forecastDto.Id = forecast.Id;
                var response = await HttpHelper.PostAsync<ForecastDto, ApiResponseDto<ForecastDto>>(ApiRoutes.UpdateForecast, forecastDto);
                updated = response.Data;
                NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Forecast updated successfully", Duration = 4000 });
            }

            await LoadData();
        }
        catch (Exception ex)
        {
            NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = $"Failed to save forecast: {ex.Message}", Duration = 4000 });
        }
    }

    private async Task OnRowCreate(ForecastViewModel forecast)
    {
        await OnRowUpdate(forecast);
    }
}

