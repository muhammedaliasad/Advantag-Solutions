namespace AdvAsmPlanning.Domain.Entities;

public class Scenario : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? CreatedBy { get; set; }
    public string? LastUpdatedBy { get; set; }
    public int? CubeScenarioId { get; set; }
    public string? StartMessage { get; set; }
    public string? ConsolidationNumber { get; set; }
    public bool ActualScenario { get; set; }
    public bool FxFlag { get; set; } = false;
    public int PlanningScenarioGroupId { get; set; }
    public int PostingLayerId { get; set; } = 1;
}
