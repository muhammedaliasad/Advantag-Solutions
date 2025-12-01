using System.ComponentModel.DataAnnotations.Schema;

namespace AdvAsmPlanning.Domain.Entities;

public class ForecastActual : BaseEntity
{
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal Amount { get; set; }

    [ForeignKey(nameof(Forecast))]
    public long ForecastId { get; set; }
    public virtual Forecast Forecast { get; set; }
}
