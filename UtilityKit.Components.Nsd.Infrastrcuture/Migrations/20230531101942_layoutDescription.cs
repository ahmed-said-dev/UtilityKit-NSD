using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityKit.Components.Nsd.Infrastrcuture.Migrations
{
    public partial class layoutDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Layouts");

            migrationBuilder.AddColumn<string>(
                name: "LayoutsDescriptions",
                table: "Layouts",
                type: "jsonb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LayoutsDescriptions",
                table: "Layouts");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Layouts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
