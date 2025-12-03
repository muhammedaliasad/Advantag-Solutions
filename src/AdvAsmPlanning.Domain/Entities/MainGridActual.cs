using System.ComponentModel.DataAnnotations.Schema;

namespace AdvAsmPlanning.Domain.Entities;

public class MainGridActual : BaseEntity
{
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal Amount { get; set; }

    [ForeignKey(nameof(MainGrid))]
    public long MainGridId { get; set; }
    public virtual MainGrid MainGrid { get; set; }
}

