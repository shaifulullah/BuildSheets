using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildSheets.Migrations
{
    public partial class AddedURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Hardwares",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Hardwares");
        }
    }
}
