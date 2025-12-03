using AdvAsmPlanning.Client.Models;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace AdvAsmPlanning.Client.Pages;

public partial class Accounts : ComponentBase
{
    [Inject] private NotificationService NotificationService { get; set; } = default!;

    private RadzenDataGrid<AccountViewModel>? grid;
    private List<AccountViewModel> accounts = new();
    private List<AccountViewModel> filteredAccounts = new();
    private bool isLoading = false;

    // Filter variables
    private string? CodeFilter;
    private string? CreatedByFilter;
    private string? RollupLevel2Filter;
    private string? DescriptionFilter;
    private string? AccountFunctionFilter;
    private string? AliasFilter;
    private string? UpdatedByFilter;
    private string? SalesRollupLevel2Filter;
    private string? AccountTypeFilter;
    private string? OMSRevenueAccountCodeFilter;
    private string? DebitCreditFilter;
    private string? OMSRevenueAccountDescriptionFilter;
    private string? AccountCategoryFilter;
    private string? GAAPNONGAAPFilter;
    private string? SourceFilter;
    private string? EBITDARollupFilter;
    private string? ExtReportFilter;
    private string? AccountSubgroupFilter;
    private string? FLUXRollup1Filter;
    private string? FLUXRollup2Filter;
    private string? RollupLevel0Filter;
    private string? SignMultiplierFilter;
    private string? NavisionGLCodeFilter;
    private string? AllocationRollupFilter;

    // Pagination options
    private int[] pageSizeOptions = new int[] { 50, 100, 200, 500 };

    protected override void OnInitialized()
    {
        LoadSampleData();
        ApplyFilters();
    }

    private void LoadSampleData()
    {
        accounts = new List<AccountViewModel>
        {
            new() { Id = 1, Code = "ACC001", CreatedBy = "admin", c_RollupLevel2 = "RL2-001", Description = "Cash and Cash Equivalents", CreatedOn = DateTime.Now.AddDays(-30), c_AccountFunction = "AF-001", Alias = "CASH", UpdatedBy = "admin", c_SalesRollupLevel2 = "SRL2-001", AccountType = "Asset", c_OMSRevenueAccountCode = "OMS-001", DebitCredit = "Debit", UpdatedOn = DateTime.Now.AddDays(-10), c_OMSRevenueAccountDescription = "Cash Account", AccountCategory = "Current Asset", ActivatedOn = DateTime.Now.AddDays(-30), c_GAAP_NONGAAP = "GAAP", Source = "Manual", DeactivatedOn = null, c_EBITDARollup = "EBITDA-001", c_ExtReport = "EXT-001", c_AccountSubgroup = "ASG-001", c_FLUXRollup1 = "FLUX1-001", c_FLUXRollup2 = "FLUX2-001", c_RollupLevel0 = "RL0-001", c_SignMultiplier = "1", c_NavisionGLCode = "NV-001", c_AllocationRollup = "ALLOC-001" },
            new() { Id = 2, Code = "ACC002", CreatedBy = "user1", c_RollupLevel2 = "RL2-002", Description = "Accounts Receivable", CreatedOn = DateTime.Now.AddDays(-25), c_AccountFunction = "AF-002", Alias = "AR", UpdatedBy = "user1", c_SalesRollupLevel2 = "SRL2-002", AccountType = "Asset", c_OMSRevenueAccountCode = "OMS-002", DebitCredit = "Debit", UpdatedOn = DateTime.Now.AddDays(-5), c_OMSRevenueAccountDescription = "Accounts Receivable Account", AccountCategory = "Current Asset", ActivatedOn = DateTime.Now.AddDays(-25), c_GAAP_NONGAAP = "GAAP", Source = "System", DeactivatedOn = null, c_EBITDARollup = "EBITDA-002", c_ExtReport = "EXT-002", c_AccountSubgroup = "ASG-002", c_FLUXRollup1 = "FLUX1-002", c_FLUXRollup2 = "FLUX2-002", c_RollupLevel0 = "RL0-002", c_SignMultiplier = "1", c_NavisionGLCode = "NV-002", c_AllocationRollup = "ALLOC-002" },
            new() { Id = 3, Code = "ACC003", CreatedBy = "admin", c_RollupLevel2 = "RL2-003", Description = "Inventory", CreatedOn = DateTime.Now.AddDays(-20), c_AccountFunction = "AF-003", Alias = "INV", UpdatedBy = "admin", c_SalesRollupLevel2 = "SRL2-003", AccountType = "Asset", c_OMSRevenueAccountCode = "OMS-003", DebitCredit = "Debit", UpdatedOn = DateTime.Now.AddDays(-2), c_OMSRevenueAccountDescription = "Inventory Account", AccountCategory = "Current Asset", ActivatedOn = DateTime.Now.AddDays(-20), c_GAAP_NONGAAP = "GAAP", Source = "Manual", DeactivatedOn = null, c_EBITDARollup = "EBITDA-003", c_ExtReport = "EXT-003", c_AccountSubgroup = "ASG-003", c_FLUXRollup1 = "FLUX1-003", c_FLUXRollup2 = "FLUX2-003", c_RollupLevel0 = "RL0-003", c_SignMultiplier = "1", c_NavisionGLCode = "NV-003", c_AllocationRollup = "ALLOC-003" },
            new() { Id = 4, Code = "ACC004", CreatedBy = "user2", c_RollupLevel2 = "RL2-004", Description = "Accounts Payable", CreatedOn = DateTime.Now.AddDays(-15), c_AccountFunction = "AF-004", Alias = "AP", UpdatedBy = "user2", c_SalesRollupLevel2 = "SRL2-004", AccountType = "Liability", c_OMSRevenueAccountCode = "OMS-004", DebitCredit = "Credit", UpdatedOn = DateTime.Now.AddDays(-1), c_OMSRevenueAccountDescription = "Accounts Payable Account", AccountCategory = "Current Liability", ActivatedOn = DateTime.Now.AddDays(-15), c_GAAP_NONGAAP = "GAAP", Source = "System", DeactivatedOn = null, c_EBITDARollup = "EBITDA-004", c_ExtReport = "EXT-004", c_AccountSubgroup = "ASG-004", c_FLUXRollup1 = "FLUX1-004", c_FLUXRollup2 = "FLUX2-004", c_RollupLevel0 = "RL0-004", c_SignMultiplier = "-1", c_NavisionGLCode = "NV-004", c_AllocationRollup = "ALLOC-004" },
            new() { Id = 5, Code = "ACC005", CreatedBy = "admin", c_RollupLevel2 = "RL2-005", Description = "Revenue - Product Sales", CreatedOn = DateTime.Now.AddDays(-10), c_AccountFunction = "AF-005", Alias = "REV-PROD", UpdatedBy = "admin", c_SalesRollupLevel2 = "SRL2-005", AccountType = "Revenue", c_OMSRevenueAccountCode = "OMS-005", DebitCredit = "Credit", UpdatedOn = DateTime.Now, c_OMSRevenueAccountDescription = "Product Sales Revenue", AccountCategory = "Revenue", ActivatedOn = DateTime.Now.AddDays(-10), c_GAAP_NONGAAP = "GAAP", Source = "Manual", DeactivatedOn = null, c_EBITDARollup = "EBITDA-005", c_ExtReport = "EXT-005", c_AccountSubgroup = "ASG-005", c_FLUXRollup1 = "FLUX1-005", c_FLUXRollup2 = "FLUX2-005", c_RollupLevel0 = "RL0-005", c_SignMultiplier = "-1", c_NavisionGLCode = "NV-005", c_AllocationRollup = "ALLOC-005" },
            new() { Id = 6, Code = "ACC006", CreatedBy = "user1", c_RollupLevel2 = "RL2-006", Description = "Cost of Goods Sold", CreatedOn = DateTime.Now.AddDays(-8), c_AccountFunction = "AF-006", Alias = "COGS", UpdatedBy = "user1", c_SalesRollupLevel2 = "SRL2-006", AccountType = "Expense", c_OMSRevenueAccountCode = "OMS-006", DebitCredit = "Debit", UpdatedOn = DateTime.Now.AddDays(-3), c_OMSRevenueAccountDescription = "Cost of Goods Sold", AccountCategory = "Cost of Sales", ActivatedOn = DateTime.Now.AddDays(-8), c_GAAP_NONGAAP = "GAAP", Source = "System", DeactivatedOn = null, c_EBITDARollup = "EBITDA-006", c_ExtReport = "EXT-006", c_AccountSubgroup = "ASG-006", c_FLUXRollup1 = "FLUX1-006", c_FLUXRollup2 = "FLUX2-006", c_RollupLevel0 = "RL0-006", c_SignMultiplier = "1", c_NavisionGLCode = "NV-006", c_AllocationRollup = "ALLOC-006" },
            new() { Id = 7, Code = "ACC007", CreatedBy = "admin", c_RollupLevel2 = "RL2-007", Description = "Operating Expenses", CreatedOn = DateTime.Now.AddDays(-5), c_AccountFunction = "AF-007", Alias = "OPEX", UpdatedBy = "admin", c_SalesRollupLevel2 = "SRL2-007", AccountType = "Expense", c_OMSRevenueAccountCode = "OMS-007", DebitCredit = "Debit", UpdatedOn = DateTime.Now.AddDays(-1), c_OMSRevenueAccountDescription = "Operating Expenses", AccountCategory = "Operating Expense", ActivatedOn = DateTime.Now.AddDays(-5), c_GAAP_NONGAAP = "NONGAAP", Source = "Manual", DeactivatedOn = null, c_EBITDARollup = "EBITDA-007", c_ExtReport = "EXT-007", c_AccountSubgroup = "ASG-007", c_FLUXRollup1 = "FLUX1-007", c_FLUXRollup2 = "FLUX2-007", c_RollupLevel0 = "RL0-007", c_SignMultiplier = "1", c_NavisionGLCode = "NV-007", c_AllocationRollup = "ALLOC-007" },
            new() { Id = 8, Code = "ACC008", CreatedBy = "user2", c_RollupLevel2 = "RL2-008", Description = "Fixed Assets", CreatedOn = DateTime.Now.AddDays(-12), c_AccountFunction = "AF-008", Alias = "FA", UpdatedBy = "user2", c_SalesRollupLevel2 = "SRL2-008", AccountType = "Asset", c_OMSRevenueAccountCode = "OMS-008", DebitCredit = "Debit", UpdatedOn = DateTime.Now.AddDays(-4), c_OMSRevenueAccountDescription = "Fixed Assets Account", AccountCategory = "Non-Current Asset", ActivatedOn = DateTime.Now.AddDays(-12), c_GAAP_NONGAAP = "GAAP", Source = "System", DeactivatedOn = null, c_EBITDARollup = "EBITDA-008", c_ExtReport = "EXT-008", c_AccountSubgroup = "ASG-008", c_FLUXRollup1 = "FLUX1-008", c_FLUXRollup2 = "FLUX2-008", c_RollupLevel0 = "RL0-008", c_SignMultiplier = "1", c_NavisionGLCode = "NV-008", c_AllocationRollup = "ALLOC-008" },
            new() { Id = 9, Code = "ACC009", CreatedBy = "admin", c_RollupLevel2 = "RL2-009", Description = "Long Term Debt", CreatedOn = DateTime.Now.AddDays(-18), c_AccountFunction = "AF-009", Alias = "LTD", UpdatedBy = "admin", c_SalesRollupLevel2 = "SRL2-009", AccountType = "Liability", c_OMSRevenueAccountCode = "OMS-009", DebitCredit = "Credit", UpdatedOn = DateTime.Now.AddDays(-6), c_OMSRevenueAccountDescription = "Long Term Debt Account", AccountCategory = "Non-Current Liability", ActivatedOn = DateTime.Now.AddDays(-18), c_GAAP_NONGAAP = "GAAP", Source = "Manual", DeactivatedOn = null, c_EBITDARollup = "EBITDA-009", c_ExtReport = "EXT-009", c_AccountSubgroup = "ASG-009", c_FLUXRollup1 = "FLUX1-009", c_FLUXRollup2 = "FLUX2-009", c_RollupLevel0 = "RL0-009", c_SignMultiplier = "-1", c_NavisionGLCode = "NV-009", c_AllocationRollup = "ALLOC-009" },
            new() { Id = 10, Code = "ACC010", CreatedBy = "user1", c_RollupLevel2 = "RL2-010", Description = "Equity - Common Stock", CreatedOn = DateTime.Now.AddDays(-22), c_AccountFunction = "AF-010", Alias = "EQUITY", UpdatedBy = "user1", c_SalesRollupLevel2 = "SRL2-010", AccountType = "Equity", c_OMSRevenueAccountCode = "OMS-010", DebitCredit = "Credit", UpdatedOn = DateTime.Now.AddDays(-7), c_OMSRevenueAccountDescription = "Common Stock Equity", AccountCategory = "Equity", ActivatedOn = DateTime.Now.AddDays(-22), c_GAAP_NONGAAP = "GAAP", Source = "System", DeactivatedOn = null, c_EBITDARollup = "EBITDA-010", c_ExtReport = "EXT-010", c_AccountSubgroup = "ASG-010", c_FLUXRollup1 = "FLUX1-010", c_FLUXRollup2 = "FLUX2-010", c_RollupLevel0 = "RL0-010", c_SignMultiplier = "-1", c_NavisionGLCode = "NV-010", c_AllocationRollup = "ALLOC-010" }
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
        if (accounts == null)
        {
            filteredAccounts = new List<AccountViewModel>();
            return;
        }

        var query = accounts.AsQueryable();

        if (!string.IsNullOrWhiteSpace(CodeFilter))
            query = query.Where(a => a.Code.Contains(CodeFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(CreatedByFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.CreatedBy) && a.CreatedBy.Contains(CreatedByFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(RollupLevel2Filter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_RollupLevel2) && a.c_RollupLevel2.Contains(RollupLevel2Filter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(DescriptionFilter))
            query = query.Where(a => a.Description.Contains(DescriptionFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(AccountFunctionFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_AccountFunction) && a.c_AccountFunction.Contains(AccountFunctionFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(AliasFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.Alias) && a.Alias.Contains(AliasFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(UpdatedByFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.UpdatedBy) && a.UpdatedBy.Contains(UpdatedByFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(SalesRollupLevel2Filter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_SalesRollupLevel2) && a.c_SalesRollupLevel2.Contains(SalesRollupLevel2Filter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(AccountTypeFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.AccountType) && a.AccountType.Contains(AccountTypeFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(OMSRevenueAccountCodeFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_OMSRevenueAccountCode) && a.c_OMSRevenueAccountCode.Contains(OMSRevenueAccountCodeFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(DebitCreditFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.DebitCredit) && a.DebitCredit.Contains(DebitCreditFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(OMSRevenueAccountDescriptionFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_OMSRevenueAccountDescription) && a.c_OMSRevenueAccountDescription.Contains(OMSRevenueAccountDescriptionFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(AccountCategoryFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.AccountCategory) && a.AccountCategory.Contains(AccountCategoryFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(GAAPNONGAAPFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_GAAP_NONGAAP) && a.c_GAAP_NONGAAP.Contains(GAAPNONGAAPFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(SourceFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.Source) && a.Source.Contains(SourceFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(EBITDARollupFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_EBITDARollup) && a.c_EBITDARollup.Contains(EBITDARollupFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(ExtReportFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_ExtReport) && a.c_ExtReport.Contains(ExtReportFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(AccountSubgroupFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_AccountSubgroup) && a.c_AccountSubgroup.Contains(AccountSubgroupFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(FLUXRollup1Filter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_FLUXRollup1) && a.c_FLUXRollup1.Contains(FLUXRollup1Filter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(FLUXRollup2Filter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_FLUXRollup2) && a.c_FLUXRollup2.Contains(FLUXRollup2Filter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(RollupLevel0Filter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_RollupLevel0) && a.c_RollupLevel0.Contains(RollupLevel0Filter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(SignMultiplierFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_SignMultiplier) && a.c_SignMultiplier.Contains(SignMultiplierFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(NavisionGLCodeFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_NavisionGLCode) && a.c_NavisionGLCode.Contains(NavisionGLCodeFilter, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(AllocationRollupFilter))
            query = query.Where(a => !string.IsNullOrEmpty(a.c_AllocationRollup) && a.c_AllocationRollup.Contains(AllocationRollupFilter, StringComparison.OrdinalIgnoreCase));

        filteredAccounts = query.ToList();
        StateHasChanged();
    }

    // Filter change handlers
    private void OnCodeFilterChanged(string? value) { CodeFilter = value; ApplyFilters(); }
    private void OnCreatedByFilterChanged(string? value) { CreatedByFilter = value; ApplyFilters(); }
    private void OnRollupLevel2FilterChanged(string? value) { RollupLevel2Filter = value; ApplyFilters(); }
    private void OnDescriptionFilterChanged(string? value) { DescriptionFilter = value; ApplyFilters(); }
    private void OnAccountFunctionFilterChanged(string? value) { AccountFunctionFilter = value; ApplyFilters(); }
    private void OnAliasFilterChanged(string? value) { AliasFilter = value; ApplyFilters(); }
    private void OnUpdatedByFilterChanged(string? value) { UpdatedByFilter = value; ApplyFilters(); }
    private void OnSalesRollupLevel2FilterChanged(string? value) { SalesRollupLevel2Filter = value; ApplyFilters(); }
    private void OnAccountTypeFilterChanged(string? value) { AccountTypeFilter = value; ApplyFilters(); }
    private void OnOMSRevenueAccountCodeFilterChanged(string? value) { OMSRevenueAccountCodeFilter = value; ApplyFilters(); }
    private void OnDebitCreditFilterChanged(string? value) { DebitCreditFilter = value; ApplyFilters(); }
    private void OnOMSRevenueAccountDescriptionFilterChanged(string? value) { OMSRevenueAccountDescriptionFilter = value; ApplyFilters(); }
    private void OnAccountCategoryFilterChanged(string? value) { AccountCategoryFilter = value; ApplyFilters(); }
    private void OnGAAPNONGAAPFilterChanged(string? value) { GAAPNONGAAPFilter = value; ApplyFilters(); }
    private void OnSourceFilterChanged(string? value) { SourceFilter = value; ApplyFilters(); }
    private void OnEBITDARollupFilterChanged(string? value) { EBITDARollupFilter = value; ApplyFilters(); }
    private void OnExtReportFilterChanged(string? value) { ExtReportFilter = value; ApplyFilters(); }
    private void OnAccountSubgroupFilterChanged(string? value) { AccountSubgroupFilter = value; ApplyFilters(); }
    private void OnFLUXRollup1FilterChanged(string? value) { FLUXRollup1Filter = value; ApplyFilters(); }
    private void OnFLUXRollup2FilterChanged(string? value) { FLUXRollup2Filter = value; ApplyFilters(); }
    private void OnRollupLevel0FilterChanged(string? value) { RollupLevel0Filter = value; ApplyFilters(); }
    private void OnSignMultiplierFilterChanged(string? value) { SignMultiplierFilter = value; ApplyFilters(); }
    private void OnNavisionGLCodeFilterChanged(string? value) { NavisionGLCodeFilter = value; ApplyFilters(); }
    private void OnAllocationRollupFilterChanged(string? value) { AllocationRollupFilter = value; ApplyFilters(); }
}

