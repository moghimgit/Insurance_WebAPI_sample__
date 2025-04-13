using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Insurance_WebAPI_sample__.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coverages",
                columns: table => new
                {
                    CoverageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinInvestment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxInvestment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverages", x => x.CoverageId);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceRequests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequests", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "CoverageSelections",
                columns: table => new
                {
                    CoverageSelectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceRequestId = table.Column<int>(type: "int", nullable: false),
                    CoverageId = table.Column<int>(type: "int", nullable: false),
                    InvestmentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalculatedPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageSelections", x => x.CoverageSelectionId);
                    table.ForeignKey(
                        name: "FK_CoverageSelections_InsuranceRequests_InsuranceRequestId",
                        column: x => x.InsuranceRequestId,
                        principalTable: "InsuranceRequests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coverages",
                columns: new[] { "CoverageId", "CoverageName", "MaxInvestment", "MinInvestment", "Rate" },
                values: new object[,]
                {
                    { 1, "جراحی", 500000000m, 5000m, 0.0052m },
                    { 2, "دندانپزشکی", 400000000m, 4000m, 0.0042m },
                    { 3, "بستری", 200000000m, 2000m, 0.005m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoverageSelections_InsuranceRequestId",
                table: "CoverageSelections",
                column: "InsuranceRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coverages");

            migrationBuilder.DropTable(
                name: "CoverageSelections");

            migrationBuilder.DropTable(
                name: "InsuranceRequests");
        }
    }
}
