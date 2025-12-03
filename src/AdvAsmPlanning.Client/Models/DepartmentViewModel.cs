namespace AdvAsmPlanning.Client.Models;

public class DepartmentViewModel
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? c_Entity { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? c_InitialOrganicPeriod { get; set; }
    public string? Alias { get; set; }
    public string? c_OMSRevenueAccountCode { get; set; }
    public bool Active { get; set; }
    public string? c_BoardorGAAP { get; set; }
    public string? Source { get; set; }
    public string? c_Branch { get; set; }
    public string? TimeAuditFields { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public DateTime? ActivatedOn { get; set; }
    public DateTime? DeactivatedOn { get; set; }
    public string? c_BusinessUnit { get; set; }
    public string? c_Component { get; set; }
    public string? c_Country { get; set; }
    public DateTime? c_DateAcquired { get; set; }
    public string? c_Division { get; set; }
    public string? c_FinanceOwner { get; set; }
    public string? c_Group { get; set; }
    public bool? c_IncludedInBoard { get; set; }
    public bool? c_IncludedInGAAP { get; set; }
    public bool? c_IsLeaf { get; set; }
    public string? c_Market { get; set; }
    public string? c_OrganizationGroup1 { get; set; }
    public string? c_OrganizationGroup2 { get; set; }
    public string? c_OrganizationGroup3 { get; set; }
    public string? c_PeriodAcquired { get; set; }
    public string? c_PshReportRollup { get; set; }
    public string? c_SalesLeader { get; set; }
    public string? c_Segment { get; set; }
    public bool? c_Passthrough { get; set; }
    public string? c_HRBusinessPartner { get; set; }
    public string? c_Partition { get; set; }
    public string? c_OperatingSegment { get; set; }
    public string? c_OperatingUnit { get; set; }
}

