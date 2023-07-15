using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityKit.Components.Nsd.Infrastrcuture.Migrations
{
    public partial class layoutCellRelatedToDashboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LayoutCells_Layouts_LayoutId",
                table: "LayoutCells");

            migrationBuilder.RenameColumn(
                name: "LayoutId",
                table: "LayoutCells",
                newName: "DashboardId");

            migrationBuilder.RenameIndex(
                name: "IX_LayoutCells_LayoutId",
                table: "LayoutCells",
                newName: "IX_LayoutCells_DashboardId");

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutCells_Dashboards_DashboardId",
                table: "LayoutCells",
                column: "DashboardId",
                principalTable: "Dashboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LayoutCells_Dashboards_DashboardId",
                table: "LayoutCells");

            migrationBuilder.RenameColumn(
                name: "DashboardId",
                table: "LayoutCells",
                newName: "LayoutId");

            migrationBuilder.RenameIndex(
                name: "IX_LayoutCells_DashboardId",
                table: "LayoutCells",
                newName: "IX_LayoutCells_LayoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutCells_Layouts_LayoutId",
                table: "LayoutCells",
                column: "LayoutId",
                principalTable: "Layouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
