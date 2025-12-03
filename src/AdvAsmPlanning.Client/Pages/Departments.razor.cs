using AdvAsmPlanning.Client.Models;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace AdvAsmPlanning.Client.Pages;

public partial class Departments : ComponentBase
{
    [Inject] private NotificationService NotificationService { get; set; } = default!;

    private RadzenDataGrid<DepartmentViewModel>? grid;
    private List<DepartmentViewModel> departments = new();
    private List<DepartmentViewModel> filteredDepartments = new();
    private bool isLoading = false;

    // Filter variables
    private string? CodeFilter;
    private string? EntityFilter;
    private string? DescriptionFilter;
    private string? InitialOrganicPeriodFilter;
    private string? AliasFilter;
    private string? OMSRevenueAccountCodeFilter;
    private string? BoardorGAAPFilter;
    private string? SourceFilter;
    private string? BranchFilter;
    private string? TimeAuditFieldsFilter;
    private string? CreatedByFilter;
    private string? UpdatedByFilter;
    private string? BusinessUnitFilter;
    private string? ComponentFilter;
    private string? CountryFilter;
    private string? DivisionFilter;
    private string? FinanceOwnerFilter;
    private string? GroupFilter;
    private string? MarketFilter;
    private string? OrganizationGroup1Filter;
    private string? OrganizationGroup2Filter;
    private string? OrganizationGroup3Filter;
    private string? PeriodAcquiredFilter;
    private string? PshReportRollupFilter;
    private string? SalesLeaderFilter;
    private string? SegmentFilter;
    private string? HRBusinessPartnerFilter;
    private string? PartitionFilter;
    private string? OperatingSegmentFilter;
    private string? OperatingUnitFilter;

    // Pagination options
    private int[] pageSizeOptions = new int[] { 50, 100, 200, 500 };

    protected override void OnInitialized()
    {
        LoadSampleData();
        ApplyFilters();
    }

    private void LoadSampleData()
    {
        departments = new List<DepartmentViewModel>
        {
            new() { Id = 1, Code = "DEPT001", c_Entity = "ENT-001", Description = "Sales Department", c_InitialOrganicPeriod = "2024-Q1", Alias = "SALES", c_OMSRevenueAccountCode = "OMS-DEPT-001", Active = true, c_BoardorGAAP = "GAAP", Source = "Manual", c_Branch = "BR-001", TimeAuditFields = "TAF-001", CreatedBy = "admin", CreatedOn = DateTime.Now.AddDays(-30), UpdatedBy = "admin", UpdatedOn = DateTime.Now.AddDays(-10), ActivatedOn = DateTime.Now.AddDays(-30), DeactivatedOn = null, c_BusinessUnit = "BU-001", c_Component = "COMP-001", c_Country = "USA", c_DateAcquired = DateTime.Now.AddDays(-100), c_Division = "DIV-001", c_FinanceOwner = "FO-001", c_Group = "GRP-001", c_IncludedInBoard = true, c_IncludedInGAAP = true, c_IsLeaf = false, c_Market = "MKT-001", c_OrganizationGroup1 = "ORG1-001", c_OrganizationGroup2 = "ORG2-001", c_OrganizationGroup3 = "ORG3-001", c_PeriodAcquired = "2024-Q1", c_PshReportRollup = "PSH-001", c_SalesLeader = "SL-001", c_Segment = "SEG-001", c_Passthrough = false, c_HRBusinessPartner = "HRBP-001", c_Partition = "PART-001", c_OperatingSegment = "OPSEG-001", c_OperatingUnit = "OPUNIT-001" },
            new() { Id = 2, Code = "DEPT002", c_Entity = "ENT-002", Description = "Marketing Department", c_InitialOrganicPeriod = "2024-Q1", Alias = "MKTG", c_OMSRevenueAccountCode = "OMS-DEPT-002", Active = true, c_BoardorGAAP = "GAAP", Source = "System", c_Branch = "BR-002", TimeAuditFields = "TAF-002", CreatedBy = "user1", CreatedOn = DateTime.Now.AddDays(-25), UpdatedBy = "user1", UpdatedOn = DateTime.Now.AddDays(-5), ActivatedOn = DateTime.Now.AddDays(-25), DeactivatedOn = null, c_BusinessUnit = "BU-002", c_Component = "COMP-002", c_Country = "USA", c_DateAcquired = DateTime.Now.AddDays(-95), c_Division = "DIV-002", c_FinanceOwner = "FO-002", c_Group = "GRP-002", c_IncludedInBoard = true, c_IncludedInGAAP = true, c_IsLeaf = true, c_Market = "MKT-002", c_OrganizationGroup1 = "ORG1-002", c_OrganizationGroup2 = "ORG2-002", c_OrganizationGroup3 = "ORG3-002", c_PeriodAcquired = "2024-Q1", c_PshReportRollup = "PSH-002", c_SalesLeader = "SL-002", c_Segment = "SEG-002", c_Passthrough = false, c_HRBusinessPartner = "HRBP-002", c_Partition = "PART-002", c_OperatingSegment = "OPSEG-002", c_OperatingUnit = "OPUNIT-002" },
            new() { Id = 3, Code = "DEPT003", c_Entity = "ENT-003", Description = "Finance Department", c_InitialOrganicPeriod = "2024-Q2", Alias = "FIN", c_OMSRevenueAccountCode = "OMS-DEPT-003", Active = true, c_BoardorGAAP = "Board", Source = "Manual", c_Branch = "BR-003", TimeAuditFields = "TAF-003", CreatedBy = "admin", CreatedOn = DateTime.Now.AddDays(-20), UpdatedBy = "admin", UpdatedOn = DateTime.Now.AddDays(-2), ActivatedOn = DateTime.Now.AddDays(-20), DeactivatedOn = null, c_BusinessUnit = "BU-003", c_Component = "COMP-003", c_Country = "UK", c_DateAcquired = DateTime.Now.AddDays(-90), c_Division = "DIV-003", c_FinanceOwner = "FO-003", c_Group = "GRP-003", c_IncludedInBoard = true, c_IncludedInGAAP = false, c_IsLeaf = false, c_Market = "MKT-003", c_OrganizationGroup1 = "ORG1-003", c_OrganizationGroup2 = "ORG2-003", c_OrganizationGroup3 = "ORG3-003", c_PeriodAcquired = "2024-Q2", c_PshReportRollup = "PSH-003", c_SalesLeader = "SL-003", c_Segment = "SEG-003", c_Passthrough = true, c_HRBusinessPartner = "HRBP-003", c_Partition = "PART-003", c_OperatingSegment = "OPSEG-003", c_OperatingUnit = "OPUNIT-003" },
            new() { Id = 4, Code = "DEPT004", c_Entity = "ENT-004", Description = "Human Resources Department", c_InitialOrganicPeriod = "2024-Q2", Alias = "HR", c_OMSRevenueAccountCode = "OMS-DEPT-004", Active = true, c_BoardorGAAP = "GAAP", Source = "System", c_Branch = "BR-004", TimeAuditFields = "TAF-004", CreatedBy = "user2", CreatedOn = DateTime.Now.AddDays(-15), UpdatedBy = "user2", UpdatedOn = DateTime.Now.AddDays(-1), ActivatedOn = DateTime.Now.AddDays(-15), DeactivatedOn = null, c_BusinessUnit = "BU-004", c_Component = "COMP-004", c_Country = "USA", c_DateAcquired = DateTime.Now.AddDays(-85), c_Division = "DIV-004", c_FinanceOwner = "FO-004", c_Group = "GRP-004", c_IncludedInBoard = false, c_IncludedInGAAP = true, c_IsLeaf = true, c_Market = "MKT-004", c_OrganizationGroup1 = "ORG1-004", c_OrganizationGroup2 = "ORG2-004", c_OrganizationGroup3 = "ORG3-004", c_PeriodAcquired = "2024-Q2", c_PshReportRollup = "PSH-004", c_SalesLeader = "SL-004", c_Segment = "SEG-004", c_Passthrough = false, c_HRBusinessPartner = "HRBP-004", c_Partition = "PART-004", c_OperatingSegment = "OPSEG-004", c_OperatingUnit = "OPUNIT-004" },
            new() { Id = 5, Code = "DEPT005", c_Entity = "ENT-005", Description = "IT Department", c_InitialOrganicPeriod = "2024-Q3", Alias = "IT", c_OMSRevenueAccountCode = "OMS-DEPT-005", Active = true, c_BoardorGAAP = "GAAP", Source = "Manual", c_Branch = "BR-005", TimeAuditFields = "TAF-005", CreatedBy = "admin", CreatedOn = DateTime.Now.AddDays(-10), UpdatedBy = "admin", UpdatedOn = DateTime.Now, ActivatedOn = DateTime.Now.AddDays(-10), DeactivatedOn = null, c_BusinessUnit = "BU-005", c_Component = "COMP-005", c_Country = "USA", c_DateAcquired = DateTime.Now.AddDays(-80), c_Division = "DIV-005", c_FinanceOwner = "FO-005", c_Group = "GRP-005", c_IncludedInBoard = true, c_IncludedInGAAP = true, c_IsLeaf = false, c_Market = "MKT-005", c_OrganizationGroup1 = "ORG1-005", c_OrganizationGroup2 = "ORG2-005", c_OrganizationGroup3 = "ORG3-005", c_PeriodAcquired = "2024-Q3", c_PshReportRollup = "PSH-005", c_SalesLeader = "SL-005", c_Segment = "SEG-005", c_Passthrough = false, c_HRBusinessPartner = "HRBP-005", c_Partition = "PART-005", c_OperatingSegment = "OPSEG-005", c_OperatingUnit = "OPUNIT-005" },
            new() { Id = 6, Code = "DEPT006", c_Entity = "ENT-006", Description = "Operations Department", c_InitialOrganicPeriod = "2024-Q3", Alias = "OPS", c_OMSRevenueAccountCode = "OMS-DEPT-006", Active = true, c_BoardorGAAP = "Board", Source = "System", c_Branch = "BR-006", TimeAuditFields = "TAF-006", CreatedBy = "user1", CreatedOn = DateTime.Now.AddDays(-8), UpdatedBy = "user1", UpdatedOn = DateTime.Now.AddDays(-3), ActivatedOn = DateTime.Now.AddDays(-8), DeactivatedOn = null, c_BusinessUnit = "BU-006", c_Component = "COMP-006", c_Country = "CAN", c_DateAcquired = DateTime.Now.AddDays(-75), c_Division = "DIV-006", c_FinanceOwner = "FO-006", c_Group = "GRP-006", c_IncludedInBoard = true, c_IncludedInGAAP = false, c_IsLeaf = true, c_Market = "MKT-006", c_OrganizationGroup1 = "ORG1-006", c_OrganizationGroup2 = "ORG2-006", c_OrganizationGroup3 = "ORG3-006", c_PeriodAcquired = "2024-Q3", c_PshReportRollup = "PSH-006", c_SalesLeader = "SL-006", c_Segment = "SEG-006", c_Passthrough = true, c_HRBusinessPartner = "HRBP-006", c_Partition = "PART-006", c_OperatingSegment = "OPSEG-006", c_OperatingUnit = "OPUNIT-006" },
            new() { Id = 7, Code = "DEPT007", c_Entity = "ENT-007", Description = "Customer Service Department", c_InitialOrganicPeriod = "2024-Q4", Alias = "CS", c_OMSRevenueAccountCode = "OMS-DEPT-007", Active = true, c_BoardorGAAP = "GAAP", Source = "Manual", c_Branch = "BR-007", TimeAuditFields = "TAF-007", CreatedBy = "admin", CreatedOn = DateTime.Now.AddDays(-5), UpdatedBy = "admin", UpdatedOn = DateTime.Now.AddDays(-1), ActivatedOn = DateTime.Now.AddDays(-5), DeactivatedOn = null, c_BusinessUnit = "BU-007", c_Component = "COMP-007", c_Country = "USA", c_DateAcquired = DateTime.Now.AddDays(-70), c_Division = "DIV-007", c_FinanceOwner = "FO-007", c_Group = "GRP-007", c_IncludedInBoard = false, c_IncludedInGAAP = true, c_IsLeaf = false, c_Market = "MKT-007", c_OrganizationGroup1 = "ORG1-007", c_OrganizationGroup2 = "ORG2-007", c_OrganizationGroup3 = "ORG3-007", c_PeriodAcquired = "2024-Q4", c_PshReportRollup = "PSH-007", c_SalesLeader = "SL-007", c_Segment = "SEG-007", c_Passthrough = false, c_HRBusinessPartner = "HRBP-007", c_Partition = "PART-007", c_OperatingSegment = "OPSEG-007", c_OperatingUnit = "OPUNIT-007" },
            new() { Id = 8, Code = "DEPT008", c_Entity = "ENT-008", Description = "Research & Development", c_InitialOrganicPeriod = "2024-Q4", Alias = "R&D", c_OMSRevenueAccountCode = "OMS-DEPT-008", Active = true, c_BoardorGAAP = "GAAP", Source = "System", c_Branch = "BR-008", TimeAuditFields = "TAF-008", CreatedBy = "user2", CreatedOn = DateTime.Now.AddDays(-12), UpdatedBy = "user2", UpdatedOn = DateTime.Now.AddDays(-4), ActivatedOn = DateTime.Now.AddDays(-12), DeactivatedOn = null, c_BusinessUnit = "BU-008", c_Component = "COMP-008", c_Country = "UK", c_DateAcquired = DateTime.Now.AddDays(-65), c_Division = "DIV-008", c_FinanceOwner = "FO-008", c_Group = "GRP-008", c_IncludedInBoard = true, c_IncludedInGAAP = true, c_IsLeaf = true, c_Market = "MKT-008", c_OrganizationGroup1 = "ORG1-008", c_OrganizationGroup2 = "ORG2-008", c_OrganizationGroup3 = "ORG3-008", c_PeriodAcquired = "2024-Q4", c_PshReportRollup = "PSH-008", c_SalesLeader = "SL-008", c_Segment = "SEG-008", c_Passthrough = false, c_HRBusinessPartner = "HRBP-008", c_Partition = "PART-008", c_OperatingSegment = "OPSEG-008", c_OperatingUnit = "OPUNIT-008" },
            new() { Id = 9, Code = "DEPT009", c_Entity = "ENT-009", Description = "Legal Department", c_InitialOrganicPeriod = "2024-Q1", Alias = "LEGAL", c_OMSRevenueAccountCode = "OMS-DEPT-009", Active = false, c_BoardorGAAP = "Board", Source = "Manual", c_Branch = "BR-009", TimeAuditFields = "TAF-009", CreatedBy = "admin", CreatedOn = DateTime.Now.AddDays(-18), UpdatedBy = "admin", UpdatedOn = DateTime.Now.AddDays(-6), ActivatedOn = DateTime.Now.AddDays(-18), DeactivatedOn = DateTime.Now.AddDays(-6), c_BusinessUnit = "BU-009", c_Component = "COMP-009", c_Country = "USA", c_DateAcquired = DateTime.Now.AddDays(-60), c_Division = "DIV-009", c_FinanceOwner = "FO-009", c_Group = "GRP-009", c_IncludedInBoard = true, c_IncludedInGAAP = false, c_IsLeaf = false, c_Market = "MKT-009", c_OrganizationGroup1 = "ORG1-009", c_OrganizationGroup2 = "ORG2-009", c_OrganizationGroup3 = "ORG3-009", c_PeriodAcquired = "2024-Q1", c_PshReportRollup = "PSH-009", c_SalesLeader = "SL-009", c_Segment = "SEG-009", c_Passthrough = true, c_HRBusinessPartner = "HRBP-009", c_Partition = "PART-009", c_OperatingSegment = "OPSEG-009", c_OperatingUnit = "OPUNIT-009" },
            new() { Id = 10, Code = "DEPT010", c_Entity = "ENT-010", Description = "Procurement Department", c_InitialOrganicPeriod = "2024-Q2", Alias = "PROC", c_OMSRevenueAccountCode = "OMS-DEPT-010", Active = true, c_BoardorGAAP = "GAAP", Source = "System", c_Branch = "BR-010", TimeAuditFields = "TAF-010", CreatedBy = "user1", CreatedOn = DateTime.Now.AddDays(-22), UpdatedBy = "user1", UpdatedOn = DateTime.Now.AddDays(-7), ActivatedOn = DateTime.Now.AddDays(-22), DeactivatedOn = null, c_BusinessUnit = "BU-010", c_Component = "COMP-010", c_Country = "CAN", c_DateAcquired = DateTime.Now.AddDays(-55), c_Division = "DIV-010", c_FinanceOwner = "FO-010", c_Group = "GRP-010", c_IncludedInBoard = false, c_IncludedInGAAP = true, c_IsLeaf = true, c_Market = "MKT-010", c_OrganizationGroup1 = "ORG1-010", c_OrganizationGroup2 = "ORG2-010", c_OrganizationGroup3 = "ORG3-010", c_PeriodAcquired = "2024-Q2", c_PshReportRollup = "PSH-010", c_SalesLeader = "SL-010", c_Segment = "SEG-010", c_Passthrough = false, c_HRBusinessPartner = "HRBP-010", c_Partition = "PART-010", c_OperatingSegment = "OPSEG-010", c_OperatingUnit = "OPUNIT-010" }
        };
    }

    private void LoadData()
    {
        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Refreshing Data...", Duration = 1000 });
        LoadSampleData();
        ApplyFilters();
        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Data Refreshed", Duration = 2000 });
    }

    private void ApplyFilters()
    {
        if (departments == null)
        {
            filteredDepartments = new List<DepartmentViewModel>();
            return;
        }

        var query = departments.AsQueryable();

        if (!string.IsNullOrWhiteSpace(CodeFilter))
            query = query.Where(d => d.Code.Contains(CodeFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(EntityFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_Entity) && d.c_Entity.Contains(EntityFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(DescriptionFilter))
            query = query.Where(d => d.Description.Contains(DescriptionFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(InitialOrganicPeriodFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_InitialOrganicPeriod) && d.c_InitialOrganicPeriod.Contains(InitialOrganicPeriodFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(AliasFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.Alias) && d.Alias.Contains(AliasFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(OMSRevenueAccountCodeFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_OMSRevenueAccountCode) && d.c_OMSRevenueAccountCode.Contains(OMSRevenueAccountCodeFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(BoardorGAAPFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_BoardorGAAP) && d.c_BoardorGAAP.Contains(BoardorGAAPFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(SourceFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.Source) && d.Source.Contains(SourceFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(BranchFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_Branch) && d.c_Branch.Contains(BranchFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(TimeAuditFieldsFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.TimeAuditFields) && d.TimeAuditFields.Contains(TimeAuditFieldsFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(CreatedByFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.CreatedBy) && d.CreatedBy.Contains(CreatedByFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(UpdatedByFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.UpdatedBy) && d.UpdatedBy.Contains(UpdatedByFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(BusinessUnitFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_BusinessUnit) && d.c_BusinessUnit.Contains(BusinessUnitFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(ComponentFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_Component) && d.c_Component.Contains(ComponentFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(CountryFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_Country) && d.c_Country.Contains(CountryFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(DivisionFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_Division) && d.c_Division.Contains(DivisionFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(FinanceOwnerFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_FinanceOwner) && d.c_FinanceOwner.Contains(FinanceOwnerFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(GroupFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_Group) && d.c_Group.Contains(GroupFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(MarketFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_Market) && d.c_Market.Contains(MarketFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(OrganizationGroup1Filter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_OrganizationGroup1) && d.c_OrganizationGroup1.Contains(OrganizationGroup1Filter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(OrganizationGroup2Filter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_OrganizationGroup2) && d.c_OrganizationGroup2.Contains(OrganizationGroup2Filter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(OrganizationGroup3Filter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_OrganizationGroup3) && d.c_OrganizationGroup3.Contains(OrganizationGroup3Filter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(PeriodAcquiredFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_PeriodAcquired) && d.c_PeriodAcquired.Contains(PeriodAcquiredFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(PshReportRollupFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_PshReportRollup) && d.c_PshReportRollup.Contains(PshReportRollupFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(SalesLeaderFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_SalesLeader) && d.c_SalesLeader.Contains(SalesLeaderFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(SegmentFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_Segment) && d.c_Segment.Contains(SegmentFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(HRBusinessPartnerFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_HRBusinessPartner) && d.c_HRBusinessPartner.Contains(HRBusinessPartnerFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(PartitionFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_Partition) && d.c_Partition.Contains(PartitionFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(OperatingSegmentFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_OperatingSegment) && d.c_OperatingSegment.Contains(OperatingSegmentFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(OperatingUnitFilter))
            query = query.Where(d => !string.IsNullOrEmpty(d.c_OperatingUnit) && d.c_OperatingUnit.Contains(OperatingUnitFilter, StringComparison.OrdinalIgnoreCase));

        filteredDepartments = query.ToList();
        StateHasChanged();
    }

    // Filter change handlers
    private void OnCodeFilterChanged(string? value) { CodeFilter = value; ApplyFilters(); }
    private void OnEntityFilterChanged(string? value) { EntityFilter = value; ApplyFilters(); }
    private void OnDescriptionFilterChanged(string? value) { DescriptionFilter = value; ApplyFilters(); }
    private void OnInitialOrganicPeriodFilterChanged(string? value) { InitialOrganicPeriodFilter = value; ApplyFilters(); }
    private void OnAliasFilterChanged(string? value) { AliasFilter = value; ApplyFilters(); }
    private void OnOMSRevenueAccountCodeFilterChanged(string? value) { OMSRevenueAccountCodeFilter = value; ApplyFilters(); }
    private void OnBoardorGAAPFilterChanged(string? value) { BoardorGAAPFilter = value; ApplyFilters(); }
    private void OnSourceFilterChanged(string? value) { SourceFilter = value; ApplyFilters(); }
    private void OnBranchFilterChanged(string? value) { BranchFilter = value; ApplyFilters(); }
    private void OnTimeAuditFieldsFilterChanged(string? value) { TimeAuditFieldsFilter = value; ApplyFilters(); }
    private void OnCreatedByFilterChanged(string? value) { CreatedByFilter = value; ApplyFilters(); }
    private void OnUpdatedByFilterChanged(string? value) { UpdatedByFilter = value; ApplyFilters(); }
    private void OnBusinessUnitFilterChanged(string? value) { BusinessUnitFilter = value; ApplyFilters(); }
    private void OnComponentFilterChanged(string? value) { ComponentFilter = value; ApplyFilters(); }
    private void OnCountryFilterChanged(string? value) { CountryFilter = value; ApplyFilters(); }
    private void OnDivisionFilterChanged(string? value) { DivisionFilter = value; ApplyFilters(); }
    private void OnFinanceOwnerFilterChanged(string? value) { FinanceOwnerFilter = value; ApplyFilters(); }
    private void OnGroupFilterChanged(string? value) { GroupFilter = value; ApplyFilters(); }
    private void OnMarketFilterChanged(string? value) { MarketFilter = value; ApplyFilters(); }
    private void OnOrganizationGroup1FilterChanged(string? value) { OrganizationGroup1Filter = value; ApplyFilters(); }
    private void OnOrganizationGroup2FilterChanged(string? value) { OrganizationGroup2Filter = value; ApplyFilters(); }
    private void OnOrganizationGroup3FilterChanged(string? value) { OrganizationGroup3Filter = value; ApplyFilters(); }
    private void OnPeriodAcquiredFilterChanged(string? value) { PeriodAcquiredFilter = value; ApplyFilters(); }
    private void OnPshReportRollupFilterChanged(string? value) { PshReportRollupFilter = value; ApplyFilters(); }
    private void OnSalesLeaderFilterChanged(string? value) { SalesLeaderFilter = value; ApplyFilters(); }
    private void OnSegmentFilterChanged(string? value) { SegmentFilter = value; ApplyFilters(); }
    private void OnHRBusinessPartnerFilterChanged(string? value) { HRBusinessPartnerFilter = value; ApplyFilters(); }
    private void OnPartitionFilterChanged(string? value) { PartitionFilter = value; ApplyFilters(); }
    private void OnOperatingSegmentFilterChanged(string? value) { OperatingSegmentFilter = value; ApplyFilters(); }
    private void OnOperatingUnitFilterChanged(string? value) { OperatingUnitFilter = value; ApplyFilters(); }
}

