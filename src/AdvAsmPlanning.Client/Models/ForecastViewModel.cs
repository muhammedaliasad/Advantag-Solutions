using AdvAsmPlanning.Application.DTOs;

namespace AdvAsmPlanning.Client.Models;

public class ForecastViewModel
{
    // Original ForecastDto properties
    public long Id { get; set; }
    public string Client { get; set; } = string.Empty;
    public string Customer { get; set; } = string.Empty;
    public string SizeProject { get; set; } = string.Empty;
    public string Project { get; set; } = string.Empty;
    public string GoFind { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public int? Delta { get; set; }
    public string AccountNo { get; set; } = string.Empty;
    public string DepartmentNo { get; set; } = string.Empty;

    // Keep original Actuals for editing purposes
    public List<ForecastActualDto> Actuals { get; set; } = new();

    // Monthly properties for 2023
    public decimal? Jan2023 { get; set; }
    public decimal? Feb2023 { get; set; }
    public decimal? Mar2023 { get; set; }
    public decimal? Apr2023 { get; set; }
    public decimal? May2023 { get; set; }
    public decimal? Jun2023 { get; set; }
    public decimal? Jul2023 { get; set; }
    public decimal? Aug2023 { get; set; }
    public decimal? Sep2023 { get; set; }
    public decimal? Oct2023 { get; set; }
    public decimal? Nov2023 { get; set; }
    public decimal? Dec2023 { get; set; }

    // Monthly properties for 2024
    public decimal? Jan2024 { get; set; }
    public decimal? Feb2024 { get; set; }
    public decimal? Mar2024 { get; set; }
    public decimal? Apr2024 { get; set; }
    public decimal? May2024 { get; set; }
    public decimal? Jun2024 { get; set; }
    public decimal? Jul2024 { get; set; }
    public decimal? Aug2024 { get; set; }
    public decimal? Sep2024 { get; set; }
    public decimal? Oct2024 { get; set; }
    public decimal? Nov2024 { get; set; }
    public decimal? Dec2024 { get; set; }

    // Monthly properties for 2025
    public decimal? Jan2025 { get; set; }
    public decimal? Feb2025 { get; set; }
    public decimal? Mar2025 { get; set; }
    public decimal? Apr2025 { get; set; }
    public decimal? May2025 { get; set; }
    public decimal? Jun2025 { get; set; }
    public decimal? Jul2025 { get; set; }
    public decimal? Aug2025 { get; set; }
    public decimal? Sep2025 { get; set; }
    public decimal? Oct2025 { get; set; }
    public decimal? Nov2025 { get; set; }
    public decimal? Dec2025 { get; set; }

    public static ForecastViewModel FromDto(ForecastDto dto)
    {
        var viewModel = new ForecastViewModel
        {
            Id = dto.Id,
            Client = dto.Client,
            Customer = dto.Customer,
            SizeProject = dto.SizeProject,
            Project = dto.Project,
            GoFind = dto.GoFind,
            Comment = dto.Comment,
            Delta = dto.Delta,
            AccountNo = dto.AccountNo,
            DepartmentNo = dto.DepartmentNo,
            Actuals = dto.Actuals
        };

        // Map actuals to monthly properties
        foreach (var actual in dto.Actuals)
        {
            var propertyName = GetPropertyNameForYearMonth(actual.Year, actual.Month);
            if (!string.IsNullOrEmpty(propertyName))
            {
                var property = typeof(ForecastViewModel).GetProperty(propertyName);
                property?.SetValue(viewModel, actual.Amount);
            }
        }

        return viewModel;
    }

    public ForecastDto ToDto()
    {
        var dto = new ForecastDto
        {
            Id = Id,
            Client = Client,
            Customer = Customer,
            SizeProject = SizeProject,
            Project = Project,
            GoFind = GoFind,
            Comment = Comment,
            Delta = Delta,
            AccountNo = AccountNo,
            DepartmentNo = DepartmentNo,
            Actuals = new List<ForecastActualDto>()
        };

        // Convert monthly properties back to actuals
        for (int year = 2023; year <= 2025; year++)
        {
            for (int month = 1; month <= 12; month++)
            {
                var propertyName = GetPropertyNameForYearMonth(year, month);
                if (!string.IsNullOrEmpty(propertyName))
                {
                    var property = typeof(ForecastViewModel).GetProperty(propertyName);
                    var value = (decimal?)property?.GetValue(this);

                    if (value.HasValue && value.Value != 0)
                    {
                        // Find existing actual or create new one
                        var existingActual = Actuals.FirstOrDefault(a => a.Year == year && a.Month == month);
                        if (existingActual != null)
                        {
                            existingActual.Amount = value.Value;
                            dto.Actuals.Add(existingActual);
                        }
                        else
                        {
                            dto.Actuals.Add(new ForecastActualDto
                            {
                                Year = year,
                                Month = month,
                                Amount = value.Value
                            });
                        }
                    }
                }
            }
        }

        return dto;
    }

    private static string GetPropertyNameForYearMonth(int year, int month)
    {
        if (year < 2023 || year > 2025 || month < 1 || month > 12)
            return string.Empty;

        var monthName = month switch
        {
            1 => "Jan",
            2 => "Feb",
            3 => "Mar",
            4 => "Apr",
            5 => "May",
            6 => "Jun",
            7 => "Jul",
            8 => "Aug",
            9 => "Sep",
            10 => "Oct",
            11 => "Nov",
            12 => "Dec",
            _ => string.Empty
        };

        return $"{monthName}{year}";
    }
}
