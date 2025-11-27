using Application.DTOs;
using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System.Net.Http.Json;

namespace Client.Pages;

public partial class Forecasts : ComponentBase
{
    [Inject] private ForecastService ForecastService { get; set; } = null!;
    [Inject] private DialogService DialogService { get; set; } = null!;
    [Inject] private NotificationService NotificationService { get; set; } = null!;
    [Inject] private IHttpClientFactory HttpClientFactory { get; set; } = null!;

    private List<ForecastDto>? forecasts;
    private List<ForecastDto> filteredForecasts = new();
    private RadzenDataGrid<ForecastDto>? grid;

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

    private int? YearFilter;
    private int? MonthFilter;

    private void OnYearFilterChanged(object? value)
    {
        YearFilter = value as int?;
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

    private void OnMonthFilterChanged(int? value)
    {
        MonthFilter = value;
        ApplyFilters();
        StateHasChanged();
    }

    // Dropdown filter options
    private List<string> sizeOptions = new() { "Small", "Medium", "Large", "Extra Large" };
    private List<string> goFindOptions = new() { "Yes", "No", "Pending" };
    
    // Year and Month filter options
    private List<int> yearOptions = new() { 2024, 2025, 2026, 2027, 2028 };
    private List<int> monthNumbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
    
    private Dictionary<int, string> monthNames = new()
    {
        { 1, "January" },
        { 2, "February" },
        { 3, "March" },
        { 4, "April" },
        { 5, "May" },
        { 6, "June" },
        { 7, "July" },
        { 8, "August" },
        { 9, "September" },
        { 10, "October" },
        { 11, "November" },
        { 12, "December" }
    };
    
    private string GetMonthName(int? month)
    {
        if (month.HasValue && monthNames.ContainsKey(month.Value))
            return monthNames[month.Value];
        return month?.ToString() ?? "Select Month";
    }
    
    // Pagination options
    private int[] pageSizeOptions = new int[] { 10, 20, 50, 100 };

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
        forecasts = await ForecastService.GetForecastsAsync();
        ApplyFilters();
    }

    private void ApplyFilters()
    {
        if (forecasts == null) return;

        var filtered = forecasts.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(ClientFilter))
            filtered = filtered.Where(f => f.Client.Contains(ClientFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(CustomerFilter))
            filtered = filtered.Where(f => f.Customer.Contains(CustomerFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(ProjectFilter))
            filtered = filtered.Where(f => f.Project.Contains(ProjectFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(SizeFilter))
            filtered = filtered.Where(f => f.SizeProject.Equals(SizeFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(GoFindFilter))
            filtered = filtered.Where(f => f.GoFind.Equals(GoFindFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(CommentFilter))
            filtered = filtered.Where(f => f.Comment.Contains(CommentFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(AccountNoFilter))
            filtered = filtered.Where(f => f.AccountNo.Contains(AccountNoFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(DepartmentNoFilter))
            filtered = filtered.Where(f => f.DepartmentNo.Contains(DepartmentNoFilter, StringComparison.OrdinalIgnoreCase));

        // Filter by Year and Month in Actuals
        if (YearFilter.HasValue || MonthFilter.HasValue)
        {
            filtered = filtered.Where(f => f.Actuals.Any(a =>
                (!YearFilter.HasValue || a.Year == YearFilter.Value) &&
                (!MonthFilter.HasValue || a.Month == MonthFilter.Value)
            ));
        }

        filteredForecasts = filtered.ToList();
        StateHasChanged();
    }

    private async Task EditRow(ForecastDto forecast)
    {
        if (grid != null)
        {
            await grid.EditRow(forecast);
        }
    }

    private async Task SaveRow(ForecastDto forecast)
    {
        if (grid != null)
        {
            await grid.UpdateRow(forecast);
        }
    }

    private void CancelEdit(ForecastDto forecast)
    {
        if (grid != null)
        {
            grid.CancelEditRow(forecast);
        }
    }

    private async Task DeleteRowClick(ForecastDto forecast)
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
                Console.WriteLine("User confirmed deletion, calling DeleteForecastAsync");
                var success = await ForecastService.DeleteForecastAsync(forecast.Id);
                Console.WriteLine($"DeleteForecastAsync result: {success}");
                
                if (success)
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
            var newForecast = new ForecastDto 
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

    private async Task OnRowUpdate(ForecastDto forecast)
    {
        try
        {
            ForecastDto? updated;
            
            if (forecast.Id == 0)
            {
                // New row
                updated = await ForecastService.CreateForecastAsync(forecast);
                if (updated != null)
                {
                    forecast.Id = updated.Id;
                    NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Forecast created successfully", Duration = 4000 });
                }
            }
            else
            {
                // Existing row
                updated = await ForecastService.UpdateForecastAsync(forecast.Id, forecast);
                NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Forecast updated successfully", Duration = 4000 });
            }
            
            await LoadData();
        }
        catch (Exception ex)
        {
            NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = $"Failed to save forecast: {ex.Message}", Duration = 4000 });
        }
    }

    private async Task OnRowCreate(ForecastDto forecast)
    {
        await OnRowUpdate(forecast);
    }
}

