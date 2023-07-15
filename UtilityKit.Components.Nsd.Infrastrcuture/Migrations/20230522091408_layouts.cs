using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityKit.Components.Nsd.Infrastrcuture.Migrations
{
    public partial class layouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_Layout_LayoutId",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_LayoutCells_Layout_LayoutId",
                table: "LayoutCells");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Layout",
                table: "Layout");

            migrationBuilder.RenameTable(
                name: "Layout",
                newName: "Layouts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Layouts",
                table: "Layouts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Layouts_LayoutId",
                table: "Dashboards",
                column: "LayoutId",
                principalTable: "Layouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutCells_Layouts_LayoutId",
                table: "LayoutCells",
                column: "LayoutId",
                principalTable: "Layouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_Layouts_LayoutId",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_LayoutCells_Layouts_LayoutId",
                table: "LayoutCells");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Layouts",
                table: "Layouts");

            migrationBuilder.RenameTable(
                name: "Layouts",
                newName: "Layout");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Layout",
                table: "Layout",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Layout_LayoutId",
                table: "Dashboards",
                column: "LayoutId",
                principalTable: "Layout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutCells_Layout_LayoutId",
                table: "LayoutCells",
                column: "LayoutId",
                principalTable: "Layout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
