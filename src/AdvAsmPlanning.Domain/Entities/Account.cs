using System.ComponentModel.DataAnnotations;

namespace AdvAsmPlanning.Domain.Entities;

public class Account
{
    [Key]
    public long MemberId { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public string? Alias { get; set; }
    public string? AccountType { get; set; }
    public string? DebitCredit { get; set; }
    public string? AccountCategory { get; set; }
    public bool? Active { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public DateTime? ActivatedOn { get; set; }
    public DateTime? DeactivatedOn { get; set; }
    public string? Source { get; set; }
    public string? c_RollupLevel1 { get; set; }
    public string? c_RollupLevel2 { get; set; }
    public string? c_AccountFunction { get; set; }
    public string? c_SalesRollupLevel2 { get; set; }
    public string? c_OMSRevenueAccountCode { get; set; }
    public string? c_OMSRevenueAccountDescription { get; set; }
    public string? c_GAAP_NONGAAP { get; set; }
    public string? c_EBITDARollup { get; set; }
    public string? c_ExtReport { get; set; }
    public string? c_AccountSubgroup { get; set; }
    public string? c_FLUXRollup1 { get; set; }
    public string? c_FLUXRollup2 { get; set; }
    public string? c_RollupLevel0 { get; set; }
    public long? c_SignMultiplier { get; set; }
    public string? c_NavisionGLCode { get; set; }
    public string? c_AllocationRollup { get; set; }
    public string? c_DemoSubgroup1 { get; set; }
    public string? c_DemoSubgroup2 { get; set; }
    public string? c_DemoSubgroup3 { get; set; }
    public string? c_ForeignCurrencyRevaluation { get; set; }
    public string? c_AcctWaterfall { get; set; }
    public string? c_MockEPML1 { get; set; }
    public string? c_MockEPML2 { get; set; }
    public string? c_MockEPML3 { get; set; }
    public string? c_MockEPML4 { get; set; }
    public string? c_SAP_GL_Code { get; set; }
    public string? c_IsSuspended { get; set; }
}

