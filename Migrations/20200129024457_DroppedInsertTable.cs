using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildSheets.Migrations
{
    public partial class DroppedInsertTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsertBuildsheets");

            migrationBuilder.DropTable(
                name: "Inserts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inserts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Rev = table.Column<int>(nullable: false),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inserts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsertBuildsheets",
                columns: table => new
                {
                    InsertId = table.Column<string>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsertBuildsheets", x => new { x.InsertId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_InsertBuildsheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsertBuildsheets_Inserts_InsertId",
                        column: x => x.InsertId,
                        principalTable: "Inserts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsertBuildsheets_BuildSheetId",
                table: "InsertBuildsheets",
                column: "BuildSheetId");
        }
    }
}
