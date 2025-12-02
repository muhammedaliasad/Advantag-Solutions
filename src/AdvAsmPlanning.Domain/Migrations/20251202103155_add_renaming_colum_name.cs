using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvAsmPlanning.Domain.Migrations
{
    /// <inheritdoc />
    public partial class add_renaming_colum_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CSegment",
                table: "Department",
                newName: "c_Segment");

            migrationBuilder.RenameColumn(
                name: "CSalesLeader",
                table: "Department",
                newName: "c_SalesLeader");

            migrationBuilder.RenameColumn(
                name: "CPshReportRollup",
                table: "Department",
                newName: "c_PshReportRollup");

            migrationBuilder.RenameColumn(
                name: "CPeriodAcquired",
                table: "Department",
                newName: "c_PeriodAcquired");

            migrationBuilder.RenameColumn(
                name: "CPassthrough",
                table: "Department",
                newName: "c_Passthrough");

            migrationBuilder.RenameColumn(
                name: "CPartition",
                table: "Department",
                newName: "c_Partition");

            migrationBuilder.RenameColumn(
                name: "COrganizationGroup3",
                table: "Department",
                newName: "c_OrganizationGroup3");

            migrationBuilder.RenameColumn(
                name: "COrganizationGroup2",
                table: "Department",
                newName: "c_OrganizationGroup2");

            migrationBuilder.RenameColumn(
                name: "COrganizationGroup1",
                table: "Department",
                newName: "c_OrganizationGroup1");

            migrationBuilder.RenameColumn(
                name: "COperatingUnit",
                table: "Department",
                newName: "c_OperatingUnit");

            migrationBuilder.RenameColumn(
                name: "COperatingSegment",
                table: "Department",
                newName: "c_OperatingSegment");

            migrationBuilder.RenameColumn(
                name: "COMSRevenueAccountCode",
                table: "Department",
                newName: "c_OMSRevenueAccountCode");

            migrationBuilder.RenameColumn(
                name: "CMarket",
                table: "Department",
                newName: "c_Market");

            migrationBuilder.RenameColumn(
                name: "CMPCCurrency",
                table: "Department",
                newName: "c_MPCCurrency");

            migrationBuilder.RenameColumn(
                name: "CIsLeaf",
                table: "Department",
                newName: "c_IsLeaf");

            migrationBuilder.RenameColumn(
                name: "CInitialOrganicPeriod",
                table: "Department",
                newName: "c_InitialOrganicPeriod");

            migrationBuilder.RenameColumn(
                name: "CIncludedInGAAP",
                table: "Department",
                newName: "c_IncludedInGAAP");

            migrationBuilder.RenameColumn(
                name: "CIncludedInBoard",
                table: "Department",
                newName: "c_IncludedInBoard");

            migrationBuilder.RenameColumn(
                name: "CHRBusinessPartner",
                table: "Department",
                newName: "c_HRBusinessPartner");

            migrationBuilder.RenameColumn(
                name: "CGroup",
                table: "Department",
                newName: "c_Group");

            migrationBuilder.RenameColumn(
                name: "CFinanceOwner",
                table: "Department",
                newName: "c_FinanceOwner");

            migrationBuilder.RenameColumn(
                name: "CEntity",
                table: "Department",
                newName: "c_Entity");

            migrationBuilder.RenameColumn(
                name: "CDivision",
                table: "Department",
                newName: "c_Division");

            migrationBuilder.RenameColumn(
                name: "CDateAcquired",
                table: "Department",
                newName: "c_DateAcquired");

            migrationBuilder.RenameColumn(
                name: "CCountry",
                table: "Department",
                newName: "c_Country");

            migrationBuilder.RenameColumn(
                name: "CComponent",
                table: "Department",
                newName: "c_Component");

            migrationBuilder.RenameColumn(
                name: "CBusinessUnit",
                table: "Department",
                newName: "c_BusinessUnit");

            migrationBuilder.RenameColumn(
                name: "CBranch",
                table: "Department",
                newName: "c_Branch");

            migrationBuilder.RenameColumn(
                name: "CBoardorGAAP",
                table: "Department",
                newName: "c_BoardorGAAP");

            migrationBuilder.RenameColumn(
                name: "CSignMultiplier",
                table: "Account",
                newName: "c_SignMultiplier");

            migrationBuilder.RenameColumn(
                name: "CSalesRollupLevel2",
                table: "Account",
                newName: "c_SalesRollupLevel2");

            migrationBuilder.RenameColumn(
                name: "CSAP_GL_Code",
                table: "Account",
                newName: "c_SAP_GL_Code");

            migrationBuilder.RenameColumn(
                name: "CRollupLevel2",
                table: "Account",
                newName: "c_RollupLevel2");

            migrationBuilder.RenameColumn(
                name: "CRollupLevel1",
                table: "Account",
                newName: "c_RollupLevel1");

            migrationBuilder.RenameColumn(
                name: "CRollupLevel0",
                table: "Account",
                newName: "c_RollupLevel0");

            migrationBuilder.RenameColumn(
                name: "COMSRevenueAccountDescription",
                table: "Account",
                newName: "c_OMSRevenueAccountDescription");

            migrationBuilder.RenameColumn(
                name: "COMSRevenueAccountCode",
                table: "Account",
                newName: "c_OMSRevenueAccountCode");

            migrationBuilder.RenameColumn(
                name: "CNavisionGLCode",
                table: "Account",
                newName: "c_NavisionGLCode");

            migrationBuilder.RenameColumn(
                name: "CMockEPML4",
                table: "Account",
                newName: "c_MockEPML4");

            migrationBuilder.RenameColumn(
                name: "CMockEPML3",
                table: "Account",
                newName: "c_MockEPML3");

            migrationBuilder.RenameColumn(
                name: "CMockEPML2",
                table: "Account",
                newName: "c_MockEPML2");

            migrationBuilder.RenameColumn(
                name: "CMockEPML1",
                table: "Account",
                newName: "c_MockEPML1");

            migrationBuilder.RenameColumn(
                name: "CIsSuspended",
                table: "Account",
                newName: "c_IsSuspended");

            migrationBuilder.RenameColumn(
                name: "CGAAP_NONGAAP",
                table: "Account",
                newName: "c_GAAP_NONGAAP");

            migrationBuilder.RenameColumn(
                name: "CForeignCurrencyRevaluation",
                table: "Account",
                newName: "c_ForeignCurrencyRevaluation");

            migrationBuilder.RenameColumn(
                name: "CFLUXRollup2",
                table: "Account",
                newName: "c_FLUXRollup2");

            migrationBuilder.RenameColumn(
                name: "CFLUXRollup1",
                table: "Account",
                newName: "c_FLUXRollup1");

            migrationBuilder.RenameColumn(
                name: "CExtReport",
                table: "Account",
                newName: "c_ExtReport");

            migrationBuilder.RenameColumn(
                name: "CEBITDARollup",
                table: "Account",
                newName: "c_EBITDARollup");

            migrationBuilder.RenameColumn(
                name: "CDemoSubgroup3",
                table: "Account",
                newName: "c_DemoSubgroup3");

            migrationBuilder.RenameColumn(
                name: "CDemoSubgroup2",
                table: "Account",
                newName: "c_DemoSubgroup2");

            migrationBuilder.RenameColumn(
                name: "CDemoSubgroup1",
                table: "Account",
                newName: "c_DemoSubgroup1");

            migrationBuilder.RenameColumn(
                name: "CAllocationRollup",
                table: "Account",
                newName: "c_AllocationRollup");

            migrationBuilder.RenameColumn(
                name: "CAcctWaterfall",
                table: "Account",
                newName: "c_AcctWaterfall");

            migrationBuilder.RenameColumn(
                name: "CAccountSubgroup",
                table: "Account",
                newName: "c_AccountSubgroup");

            migrationBuilder.RenameColumn(
                name: "CAccountFunction",
                table: "Account",
                newName: "c_AccountFunction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "c_Segment",
                table: "Department",
                newName: "CSegment");

            migrationBuilder.RenameColumn(
                name: "c_SalesLeader",
                table: "Department",
                newName: "CSalesLeader");

            migrationBuilder.RenameColumn(
                name: "c_PshReportRollup",
                table: "Department",
                newName: "CPshReportRollup");

            migrationBuilder.RenameColumn(
                name: "c_PeriodAcquired",
                table: "Department",
                newName: "CPeriodAcquired");

            migrationBuilder.RenameColumn(
                name: "c_Passthrough",
                table: "Department",
                newName: "CPassthrough");

            migrationBuilder.RenameColumn(
                name: "c_Partition",
                table: "Department",
                newName: "CPartition");

            migrationBuilder.RenameColumn(
                name: "c_OrganizationGroup3",
                table: "Department",
                newName: "COrganizationGroup3");

            migrationBuilder.RenameColumn(
                name: "c_OrganizationGroup2",
                table: "Department",
                newName: "COrganizationGroup2");

            migrationBuilder.RenameColumn(
                name: "c_OrganizationGroup1",
                table: "Department",
                newName: "COrganizationGroup1");

            migrationBuilder.RenameColumn(
                name: "c_OperatingUnit",
                table: "Department",
                newName: "COperatingUnit");

            migrationBuilder.RenameColumn(
                name: "c_OperatingSegment",
                table: "Department",
                newName: "COperatingSegment");

            migrationBuilder.RenameColumn(
                name: "c_OMSRevenueAccountCode",
                table: "Department",
                newName: "COMSRevenueAccountCode");

            migrationBuilder.RenameColumn(
                name: "c_Market",
                table: "Department",
                newName: "CMarket");

            migrationBuilder.RenameColumn(
                name: "c_MPCCurrency",
                table: "Department",
                newName: "CMPCCurrency");

            migrationBuilder.RenameColumn(
                name: "c_IsLeaf",
                table: "Department",
                newName: "CIsLeaf");

            migrationBuilder.RenameColumn(
                name: "c_InitialOrganicPeriod",
                table: "Department",
                newName: "CInitialOrganicPeriod");

            migrationBuilder.RenameColumn(
                name: "c_IncludedInGAAP",
                table: "Department",
                newName: "CIncludedInGAAP");

            migrationBuilder.RenameColumn(
                name: "c_IncludedInBoard",
                table: "Department",
                newName: "CIncludedInBoard");

            migrationBuilder.RenameColumn(
                name: "c_HRBusinessPartner",
                table: "Department",
                newName: "CHRBusinessPartner");

            migrationBuilder.RenameColumn(
                name: "c_Group",
                table: "Department",
                newName: "CGroup");

            migrationBuilder.RenameColumn(
                name: "c_FinanceOwner",
                table: "Department",
                newName: "CFinanceOwner");

            migrationBuilder.RenameColumn(
                name: "c_Entity",
                table: "Department",
                newName: "CEntity");

            migrationBuilder.RenameColumn(
                name: "c_Division",
                table: "Department",
                newName: "CDivision");

            migrationBuilder.RenameColumn(
                name: "c_DateAcquired",
                table: "Department",
                newName: "CDateAcquired");

            migrationBuilder.RenameColumn(
                name: "c_Country",
                table: "Department",
                newName: "CCountry");

            migrationBuilder.RenameColumn(
                name: "c_Component",
                table: "Department",
                newName: "CComponent");

            migrationBuilder.RenameColumn(
                name: "c_BusinessUnit",
                table: "Department",
                newName: "CBusinessUnit");

            migrationBuilder.RenameColumn(
                name: "c_Branch",
                table: "Department",
                newName: "CBranch");

            migrationBuilder.RenameColumn(
                name: "c_BoardorGAAP",
                table: "Department",
                newName: "CBoardorGAAP");

            migrationBuilder.RenameColumn(
                name: "c_SignMultiplier",
                table: "Account",
                newName: "CSignMultiplier");

            migrationBuilder.RenameColumn(
                name: "c_SalesRollupLevel2",
                table: "Account",
                newName: "CSalesRollupLevel2");

            migrationBuilder.RenameColumn(
                name: "c_SAP_GL_Code",
                table: "Account",
                newName: "CSAP_GL_Code");

            migrationBuilder.RenameColumn(
                name: "c_RollupLevel2",
                table: "Account",
                newName: "CRollupLevel2");

            migrationBuilder.RenameColumn(
                name: "c_RollupLevel1",
                table: "Account",
                newName: "CRollupLevel1");

            migrationBuilder.RenameColumn(
                name: "c_RollupLevel0",
                table: "Account",
                newName: "CRollupLevel0");

            migrationBuilder.RenameColumn(
                name: "c_OMSRevenueAccountDescription",
                table: "Account",
                newName: "COMSRevenueAccountDescription");

            migrationBuilder.RenameColumn(
                name: "c_OMSRevenueAccountCode",
                table: "Account",
                newName: "COMSRevenueAccountCode");

            migrationBuilder.RenameColumn(
                name: "c_NavisionGLCode",
                table: "Account",
                newName: "CNavisionGLCode");

            migrationBuilder.RenameColumn(
                name: "c_MockEPML4",
                table: "Account",
                newName: "CMockEPML4");

            migrationBuilder.RenameColumn(
                name: "c_MockEPML3",
                table: "Account",
                newName: "CMockEPML3");

            migrationBuilder.RenameColumn(
                name: "c_MockEPML2",
                table: "Account",
                newName: "CMockEPML2");

            migrationBuilder.RenameColumn(
                name: "c_MockEPML1",
                table: "Account",
                newName: "CMockEPML1");

            migrationBuilder.RenameColumn(
                name: "c_IsSuspended",
                table: "Account",
                newName: "CIsSuspended");

            migrationBuilder.RenameColumn(
                name: "c_GAAP_NONGAAP",
                table: "Account",
                newName: "CGAAP_NONGAAP");

            migrationBuilder.RenameColumn(
                name: "c_ForeignCurrencyRevaluation",
                table: "Account",
                newName: "CForeignCurrencyRevaluation");

            migrationBuilder.RenameColumn(
                name: "c_FLUXRollup2",
                table: "Account",
                newName: "CFLUXRollup2");

            migrationBuilder.RenameColumn(
                name: "c_FLUXRollup1",
                table: "Account",
                newName: "CFLUXRollup1");

            migrationBuilder.RenameColumn(
                name: "c_ExtReport",
                table: "Account",
                newName: "CExtReport");

            migrationBuilder.RenameColumn(
                name: "c_EBITDARollup",
                table: "Account",
                newName: "CEBITDARollup");

            migrationBuilder.RenameColumn(
                name: "c_DemoSubgroup3",
                table: "Account",
                newName: "CDemoSubgroup3");

            migrationBuilder.RenameColumn(
                name: "c_DemoSubgroup2",
                table: "Account",
                newName: "CDemoSubgroup2");

            migrationBuilder.RenameColumn(
                name: "c_DemoSubgroup1",
                table: "Account",
                newName: "CDemoSubgroup1");

            migrationBuilder.RenameColumn(
                name: "c_AllocationRollup",
                table: "Account",
                newName: "CAllocationRollup");

            migrationBuilder.RenameColumn(
                name: "c_AcctWaterfall",
                table: "Account",
                newName: "CAcctWaterfall");

            migrationBuilder.RenameColumn(
                name: "c_AccountSubgroup",
                table: "Account",
                newName: "CAccountSubgroup");

            migrationBuilder.RenameColumn(
                name: "c_AccountFunction",
                table: "Account",
                newName: "CAccountFunction");
        }
    }
}
