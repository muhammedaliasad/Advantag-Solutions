namespace AdvAsmPlanning.Application.DTOs;

public class PlanningScenarioDto
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? CreatedBy { get; set; }
    public DateTime CreatedTime { get; set; }
    public string? LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedTime { get; set; }
    public int? CubeScenarioId { get; set; }
    public string? StartMessage { get; set; }
    public string? ConsolidationNumber { get; set; }
    public bool ActualScenario { get; set; }
    public bool FxFlag { get; set; }
    public int PlanningScenarioGroupId { get; set; }
    public int PostingLayerId { get; set; }

    // Computed property for Status display
    public string Status => ActualScenario ? "Locked" : "Unlocked";
}
