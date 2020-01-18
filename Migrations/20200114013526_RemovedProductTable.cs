using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildSheets.Migrations
{
    public partial class RemovedProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildSheets_Product_ProductId",
                table: "BuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceFirmware_Product_ProductId",
                table: "DeviceFirmware");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropIndex(
                name: "IX_DeviceFirmware_ProductId",
                table: "DeviceFirmware");

            migrationBuilder.DropIndex(
                name: "IX_BuildSheets_ProductId",
                table: "BuildSheets");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "BuildSheets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "BuildSheets",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Launch = table.Column<DateTime>(nullable: false),
                    MyProperty = table.Column<int>(nullable: false),
                    Owner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceFirmware_ProductId",
                table: "DeviceFirmware",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildSheets_ProductId",
                table: "BuildSheets",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildSheets_Product_ProductId",
                table: "BuildSheets",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceFirmware_Product_ProductId",
                table: "DeviceFirmware",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
