using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UtilityKit.Components.Nsd.Infrastrcuture.Migrations
{
    public partial class chart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DomainName = table.Column<string>(type: "text", nullable: true),
                    AssetTableName = table.Column<string>(type: "text", nullable: true),
                    AssetGroup = table.Column<int>(type: "integer", nullable: false),
                    AssetType = table.Column<string>(type: "text", nullable: true),
                    IsBasic = table.Column<int>(type: "integer", nullable: false),
                    GovId = table.Column<string>(type: "text", nullable: true),
                    CityId = table.Column<string>(type: "text", nullable: true),
                    TotalLength = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Charts");
        }
    }
}
