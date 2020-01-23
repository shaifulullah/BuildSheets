using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildSheets.Migrations
{
    public partial class ModifiedAlltableOfBuildSheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildSheets_DeviceFirmware_DeviceFirmwareId",
                table: "BuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildSheets_Modem_DeviceModemId",
                table: "BuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertBuildSheet_BuildSheets_BuildSheetId",
                table: "InsertBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertBuildSheet_Insert_InsertId",
                table: "InsertBuildSheet");

            migrationBuilder.DropTable(
                name: "BoardBuildSheet");

            migrationBuilder.DropTable(
                name: "DeviceFirmware");

            migrationBuilder.DropTable(
                name: "Modem");

            migrationBuilder.DropTable(
                name: "Board");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsertBuildSheet",
                table: "InsertBuildSheet");

            migrationBuilder.DropIndex(
                name: "IX_BuildSheets_DeviceFirmwareId",
                table: "BuildSheets");

            migrationBuilder.DropIndex(
                name: "IX_BuildSheets_DeviceModemId",
                table: "BuildSheets");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "WorkInstruction");

            migrationBuilder.DropColumn(
                name: "Side",
                table: "CertificationLabelRequirement");

            migrationBuilder.RenameTable(
                name: "InsertBuildSheet",
                newName: "InsertBuildsheet");

            migrationBuilder.RenameIndex(
                name: "IX_InsertBuildSheet_BuildSheetId",
                table: "InsertBuildsheet",
                newName: "IX_InsertBuildsheet_BuildSheetId");

            migrationBuilder.RenameColumn(
                name: "ModemId",
                table: "CertificationLabelRequirement",
                newName: "SideBURL");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CertificationLabelRequirement",
                newName: "SideBDescription");

            migrationBuilder.RenameColumn(
                name: "DeviceModemId",
                table: "BuildSheets",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "DeviceFirmwareId",
                table: "BuildSheets",
                newName: "ECOId");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Insert",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rev",
                table: "Document",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "FCC",
                table: "CertificationLabelRequirement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IC",
                table: "CertificationLabelRequirement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SideA",
                table: "CertificationLabelRequirement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SideADescription",
                table: "CertificationLabelRequirement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SideAURL",
                table: "CertificationLabelRequirement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SideB",
                table: "CertificationLabelRequirement",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "BuildSheets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BuildSheets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductImageURL",
                table: "BuildSheets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductLaunchDate",
                table: "BuildSheets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "BuildSheets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductOwner",
                table: "BuildSheets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductStatus",
                table: "BuildSheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductUpdatedOn",
                table: "BuildSheets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProvisioningPackage",
                table: "BuildSheets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Revision",
                table: "BuildSheets",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsertBuildsheet",
                table: "InsertBuildsheet",
                columns: new[] { "InsertId", "BuildSheetId" });

            migrationBuilder.CreateTable(
                name: "BaseBoard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rev = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseBoard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalSubAssemblyBoard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rev = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalSubAssemblyBoard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubBoard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rev = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubBoard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseBoardBuildSheet",
                columns: table => new
                {
                    BaseBoardBuildSheetId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseBoardBuildSheet", x => new { x.BaseBoardBuildSheetId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_BaseBoardBuildSheet_BaseBoard_BaseBoardBuildSheetId",
                        column: x => x.BaseBoardBuildSheetId,
                        principalTable: "BaseBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseBoardBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalSubAssemblyBoardBuildSheet",
                columns: table => new
                {
                    InternalSubAssemblyBoardId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalSubAssemblyBoardBuildSheet", x => new { x.InternalSubAssemblyBoardId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_InternalSubAssemblyBoardBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalSubAssemblyBoardBuildSheet_InternalSubAssemblyBoard_InternalSubAssemblyBoardId",
                        column: x => x.InternalSubAssemblyBoardId,
                        principalTable: "InternalSubAssemblyBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubBoardBuildSheet",
                columns: table => new
                {
                    SubBoardBuildSheetId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubBoardBuildSheet", x => new { x.SubBoardBuildSheetId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_SubBoardBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubBoardBuildSheet_SubBoard_SubBoardBuildSheetId",
                        column: x => x.SubBoardBuildSheetId,
                        principalTable: "SubBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseBoardBuildSheet_BuildSheetId",
                table: "BaseBoardBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalSubAssemblyBoardBuildSheet_BuildSheetId",
                table: "InternalSubAssemblyBoardBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_SubBoardBuildSheet_BuildSheetId",
                table: "SubBoardBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsertBuildsheet_BuildSheets_BuildSheetId",
                table: "InsertBuildsheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsertBuildsheet_Insert_InsertId",
                table: "InsertBuildsheet",
                column: "InsertId",
                principalTable: "Insert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsertBuildsheet_BuildSheets_BuildSheetId",
                table: "InsertBuildsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertBuildsheet_Insert_InsertId",
                table: "InsertBuildsheet");

            migrationBuilder.DropTable(
                name: "BaseBoardBuildSheet");

            migrationBuilder.DropTable(
                name: "InternalSubAssemblyBoardBuildSheet");

            migrationBuilder.DropTable(
                name: "SubBoardBuildSheet");

            migrationBuilder.DropTable(
                name: "BaseBoard");

            migrationBuilder.DropTable(
                name: "InternalSubAssemblyBoard");

            migrationBuilder.DropTable(
                name: "SubBoard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsertBuildsheet",
                table: "InsertBuildsheet");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Insert");

            migrationBuilder.DropColumn(
                name: "FCC",
                table: "CertificationLabelRequirement");

            migrationBuilder.DropColumn(
                name: "IC",
                table: "CertificationLabelRequirement");

            migrationBuilder.DropColumn(
                name: "SideA",
                table: "CertificationLabelRequirement");

            migrationBuilder.DropColumn(
                name: "SideADescription",
                table: "CertificationLabelRequirement");

            migrationBuilder.DropColumn(
                name: "SideAURL",
                table: "CertificationLabelRequirement");

            migrationBuilder.DropColumn(
                name: "SideB",
                table: "CertificationLabelRequirement");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BuildSheets");

            migrationBuilder.DropColumn(
                name: "ProductImageURL",
                table: "BuildSheets");

            migrationBuilder.DropColumn(
                name: "ProductLaunchDate",
                table: "BuildSheets");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "BuildSheets");

            migrationBuilder.DropColumn(
                name: "ProductOwner",
                table: "BuildSheets");

            migrationBuilder.DropColumn(
                name: "ProductStatus",
                table: "BuildSheets");

            migrationBuilder.DropColumn(
                name: "ProductUpdatedOn",
                table: "BuildSheets");

            migrationBuilder.DropColumn(
                name: "ProvisioningPackage",
                table: "BuildSheets");

            migrationBuilder.DropColumn(
                name: "Revision",
                table: "BuildSheets");

            migrationBuilder.RenameTable(
                name: "InsertBuildsheet",
                newName: "InsertBuildSheet");

            migrationBuilder.RenameIndex(
                name: "IX_InsertBuildsheet_BuildSheetId",
                table: "InsertBuildSheet",
                newName: "IX_InsertBuildSheet_BuildSheetId");

            migrationBuilder.RenameColumn(
                name: "SideBURL",
                table: "CertificationLabelRequirement",
                newName: "ModemId");

            migrationBuilder.RenameColumn(
                name: "SideBDescription",
                table: "CertificationLabelRequirement",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "BuildSheets",
                newName: "DeviceModemId");

            migrationBuilder.RenameColumn(
                name: "ECOId",
                table: "BuildSheets",
                newName: "DeviceFirmwareId");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "WorkInstruction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Rev",
                table: "Document",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Side",
                table: "CertificationLabelRequirement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceModemId",
                table: "BuildSheets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsertBuildSheet",
                table: "InsertBuildSheet",
                columns: new[] { "InsertId", "BuildSheetId" });

            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rev = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceFirmware",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceFirmware", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modem",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DefaultChannel = table.Column<int>(nullable: false),
                    FCC = table.Column<string>(nullable: true),
                    FirmwareRevision = table.Column<string>(nullable: true),
                    FirmwareVersion = table.Column<string>(nullable: true),
                    HardwareRevision = table.Column<int>(nullable: false),
                    HardwareVersion = table.Column<string>(nullable: true),
                    IC = table.Column<string>(nullable: true),
                    IMEIId = table.Column<string>(nullable: true),
                    IMEIRange = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardBuildSheet",
                columns: table => new
                {
                    BoardId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardBuildSheet", x => new { x.BoardId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_BoardBuildSheet_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildSheets_DeviceFirmwareId",
                table: "BuildSheets",
                column: "DeviceFirmwareId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildSheets_DeviceModemId",
                table: "BuildSheets",
                column: "DeviceModemId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardBuildSheet_BuildSheetId",
                table: "BoardBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildSheets_DeviceFirmware_DeviceFirmwareId",
                table: "BuildSheets",
                column: "DeviceFirmwareId",
                principalTable: "DeviceFirmware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildSheets_Modem_DeviceModemId",
                table: "BuildSheets",
                column: "DeviceModemId",
                principalTable: "Modem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsertBuildSheet_BuildSheets_BuildSheetId",
                table: "InsertBuildSheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsertBuildSheet_Insert_InsertId",
                table: "InsertBuildSheet",
                column: "InsertId",
                principalTable: "Insert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
