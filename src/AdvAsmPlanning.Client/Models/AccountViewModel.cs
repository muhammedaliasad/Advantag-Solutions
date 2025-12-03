namespace AdvAsmPlanning.Client.Models;

public class AccountViewModel
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? CreatedBy { get; set; }
    public string? c_RollupLevel2 { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime? CreatedOn { get; set; }
    public string? c_AccountFunction { get; set; }
    public string? Alias { get; set; }
    public string? UpdatedBy { get; set; }
    public string? c_SalesRollupLevel2 { get; set; }
    public string? AccountType { get; set; }
    public string? c_OMSRevenueAccountCode { get; set; }
    public string? DebitCredit { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string? c_OMSRevenueAccountDescription { get; set; }
    public string? AccountCategory { get; set; }
    public DateTime? ActivatedOn { get; set; }
    public string? c_GAAP_NONGAAP { get; set; }
    public string? Source { get; set; }
    public DateTime? DeactivatedOn { get; set; }
    public string? c_EBITDARollup { get; set; }
    public string? c_ExtReport { get; set; }
    public string? c_AccountSubgroup { get; set; }
    public string? c_FLUXRollup1 { get; set; }
    public string? c_FLUXRollup2 { get; set; }
    public string? c_RollupLevel0 { get; set; }
    public string? c_SignMultiplier { get; set; }
    public string? c_NavisionGLCode { get; set; }
    public string? c_AllocationRollup { get; set; }
}

