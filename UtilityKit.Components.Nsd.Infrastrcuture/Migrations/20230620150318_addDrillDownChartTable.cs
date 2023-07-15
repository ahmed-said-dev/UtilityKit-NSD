using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityKit.Components.Nsd.Infrastrcuture.Migrations
{
    public partial class addDrillDownChartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Charts",
                table: "Charts");

            migrationBuilder.RenameTable(
                name: "Charts",
                newName: "DrillDownCharts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrillDownCharts",
                table: "DrillDownCharts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DrillDownCharts",
                table: "DrillDownCharts");

            migrationBuilder.RenameTable(
                name: "DrillDownCharts",
                newName: "Charts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Charts",
                table: "Charts",
                column: "Id");
        }
    }
}
