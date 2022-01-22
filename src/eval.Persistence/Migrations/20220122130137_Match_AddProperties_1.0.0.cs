using Microsoft.EntityFrameworkCore.Migrations;

namespace eval.Persistence.Migrations
{
    public partial class Match_AddProperties_100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "MatchEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Opening",
                table: "MatchEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteForMatch",
                table: "MatchEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeControl",
                table: "MatchEntities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "MatchEntities");

            migrationBuilder.DropColumn(
                name: "Opening",
                table: "MatchEntities");

            migrationBuilder.DropColumn(
                name: "SiteForMatch",
                table: "MatchEntities");

            migrationBuilder.DropColumn(
                name: "TimeControl",
                table: "MatchEntities");
        }
    }
}
