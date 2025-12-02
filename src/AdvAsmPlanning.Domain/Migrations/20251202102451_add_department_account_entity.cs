using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvAsmPlanning.Domain.Migrations
{
    /// <inheritdoc />
    public partial class add_department_account_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    MemberId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebitCredit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CRollupLevel1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CRollupLevel2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CAccountFunction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSalesRollupLevel2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COMSRevenueAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COMSRevenueAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CGAAP_NONGAAP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEBITDARollup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CExtReport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CAccountSubgroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CFLUXRollup1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CFLUXRollup2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CRollupLevel0 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSignMultiplier = table.Column<long>(type: "bigint", nullable: true),
                    CNavisionGLCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CAllocationRollup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CDemoSubgroup1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CDemoSubgroup2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CDemoSubgroup3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CForeignCurrencyRevaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CAcctWaterfall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMockEPML1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMockEPML2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMockEPML3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMockEPML4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSAP_GL_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIsSuspended = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    MemberId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMPCCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEntity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CInitialOrganicPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COMSRevenueAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CBoardorGAAP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CBusinessUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CComponent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CDateAcquired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CDivision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CFinanceOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIncludedInBoard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIncludedInGAAP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIsLeaf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMarket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COrganizationGroup1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COrganizationGroup2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COrganizationGroup3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPeriodAcquired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPshReportRollup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSalesLeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSegment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPassthrough = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHRBusinessPartner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPartition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COperatingSegment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COperatingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.MemberId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
