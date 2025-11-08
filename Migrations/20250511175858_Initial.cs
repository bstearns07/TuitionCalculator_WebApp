using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionCalculator_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollegeCost",
                columns: table => new
                {
                    CollegeCostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CostPerCreditHour = table.Column<decimal>(type: "TEXT", nullable: false),
                    Timeframe = table.Column<string>(type: "TEXT", nullable: false),
                    CreditHoursPerTerm = table.Column<int>(type: "INTEGER", nullable: false),
                    CostOfHousing = table.Column<decimal>(type: "TEXT", nullable: false),
                    CostOfBooks = table.Column<decimal>(type: "TEXT", nullable: false),
                    YearsToGraduate = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeCost", x => x.CollegeCostId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollegeCost");
        }
    }
}
