using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildSheets.Migrations
{
    public partial class AddedRevisionColmnInTPandTPIDcolmninBS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Revision",
                table: "TesterParameters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TesterParameterId",
                table: "BuildSheets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Revision",
                table: "TesterParameters");

            migrationBuilder.DropColumn(
                name: "TesterParameterId",
                table: "BuildSheets");
        }
    }
}
