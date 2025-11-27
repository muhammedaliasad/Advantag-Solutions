namespace Domain.Entities;

public class ForecastActual : BaseEntity
{
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal Amount { get; set; }

    public long ForecastId { get; set; }
    // public Forecast Forecast { get; set; } // Navigation property if needed, keeping it simple for now to avoid cycles if not configured
}
