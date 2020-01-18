using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildSheets.Migrations
{
    public partial class InitialMigrationWithAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "CertificationLabelRequirement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Side = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ModemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationLabelRequirement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractManufactureAssemblyDrawing",
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
                    table.PrimaryKey("PK_ContractManufactureAssemblyDrawing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Rev = table.Column<int>(nullable: false),
                    RevDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeotabAssemblyDrawing",
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
                    table.PrimaryKey("PK_GeotabAssemblyDrawing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hardware",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rev = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hardware", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insert",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Rev = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insert", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rev = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modem",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IMEIRange = table.Column<string>(nullable: true),
                    IMEIId = table.Column<string>(nullable: true),
                    HardwareVersion = table.Column<string>(nullable: true),
                    HardwareRevision = table.Column<int>(nullable: false),
                    FirmwareVersion = table.Column<string>(nullable: true),
                    FirmwareRevision = table.Column<string>(nullable: true),
                    DefaultChannel = table.Column<int>(nullable: false),
                    FCC = table.Column<string>(nullable: true),
                    IC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packaging",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rev = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packaging", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MyProperty = table.Column<int>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    Launch = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TesterParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceName = table.Column<string>(nullable: true),
                    Parameter = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesterParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TesterSoftware",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductCode = table.Column<string>(nullable: true),
                    ProductCodeURL = table.Column<string>(nullable: true),
                    TesterVersion = table.Column<string>(nullable: true),
                    TesterVersionURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesterSoftware", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkInstruction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rev = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkInstruction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceFirmware",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Version = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceFirmware", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceFirmware_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildSheets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    APN = table.Column<string>(nullable: true),
                    CustomerGateway = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    DeviceFirmwareId = table.Column<int>(nullable: true),
                    DeviceModemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildSheets_DeviceFirmware_DeviceFirmwareId",
                        column: x => x.DeviceFirmwareId,
                        principalTable: "DeviceFirmware",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuildSheets_Modem_DeviceModemId",
                        column: x => x.DeviceModemId,
                        principalTable: "Modem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuildSheets_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "CertificationLabelRequirementBuildSheet",
                columns: table => new
                {
                    CertificationLabelRequirementId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationLabelRequirementBuildSheet", x => new { x.CertificationLabelRequirementId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_CertificationLabelRequirementBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificationLabelRequirementBuildSheet_CertificationLabelRequirement_CertificationLabelRequirementId",
                        column: x => x.CertificationLabelRequirementId,
                        principalTable: "CertificationLabelRequirement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractManufactureAssemblyDrawingBuildSheet",
                columns: table => new
                {
                    ContractManufactureAssemblyDrawingId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractManufactureAssemblyDrawingBuildSheet", x => new { x.ContractManufactureAssemblyDrawingId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_ContractManufactureAssemblyDrawingBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractManufactureAssemblyDrawingBuildSheet_ContractManufactureAssemblyDrawing_ContractManufactureAssemblyDrawingId",
                        column: x => x.ContractManufactureAssemblyDrawingId,
                        principalTable: "ContractManufactureAssemblyDrawing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentBuildSheet",
                columns: table => new
                {
                    DocumentId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentBuildSheet", x => new { x.DocumentId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_DocumentBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentBuildSheet_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeotabAssemblyDrawingBuildSheet",
                columns: table => new
                {
                    GeotabAssemblyDrawingId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeotabAssemblyDrawingBuildSheet", x => new { x.GeotabAssemblyDrawingId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_GeotabAssemblyDrawingBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeotabAssemblyDrawingBuildSheet_GeotabAssemblyDrawing_GeotabAssemblyDrawingId",
                        column: x => x.GeotabAssemblyDrawingId,
                        principalTable: "GeotabAssemblyDrawing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HardwareBuildSheet",
                columns: table => new
                {
                    HardwareId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareBuildSheet", x => new { x.HardwareId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_HardwareBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HardwareBuildSheet_Hardware_HardwareId",
                        column: x => x.HardwareId,
                        principalTable: "Hardware",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsertBuildSheet",
                columns: table => new
                {
                    InsertId = table.Column<string>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsertBuildSheet", x => new { x.InsertId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_InsertBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsertBuildSheet_Insert_InsertId",
                        column: x => x.InsertId,
                        principalTable: "Insert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabelBuildSheet",
                columns: table => new
                {
                    LabelId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelBuildSheet", x => new { x.LabelId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_LabelBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabelBuildSheet_Label_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Label",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackagingBuildSheet",
                columns: table => new
                {
                    PackagingId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagingBuildSheet", x => new { x.PackagingId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_PackagingBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackagingBuildSheet_Packaging_PackagingId",
                        column: x => x.PackagingId,
                        principalTable: "Packaging",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TesterSoftwareBuildsheet",
                columns: table => new
                {
                    TesterSoftwareId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesterSoftwareBuildsheet", x => new { x.TesterSoftwareId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_TesterSoftwareBuildsheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TesterSoftwareBuildsheet_TesterSoftware_TesterSoftwareId",
                        column: x => x.TesterSoftwareId,
                        principalTable: "TesterSoftware",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkInstructionBuildSheet",
                columns: table => new
                {
                    WorkInstructionId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkInstructionBuildSheet", x => new { x.WorkInstructionId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_WorkInstructionBuildSheet_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkInstructionBuildSheet_WorkInstruction_WorkInstructionId",
                        column: x => x.WorkInstructionId,
                        principalTable: "WorkInstruction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardBuildSheet_BuildSheetId",
                table: "BoardBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildSheets_DeviceFirmwareId",
                table: "BuildSheets",
                column: "DeviceFirmwareId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildSheets_DeviceModemId",
                table: "BuildSheets",
                column: "DeviceModemId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildSheets_ProductId",
                table: "BuildSheets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationLabelRequirementBuildSheet_BuildSheetId",
                table: "CertificationLabelRequirementBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractManufactureAssemblyDrawingBuildSheet_BuildSheetId",
                table: "ContractManufactureAssemblyDrawingBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceFirmware_ProductId",
                table: "DeviceFirmware",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentBuildSheet_BuildSheetId",
                table: "DocumentBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_GeotabAssemblyDrawingBuildSheet_BuildSheetId",
                table: "GeotabAssemblyDrawingBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareBuildSheet_BuildSheetId",
                table: "HardwareBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_InsertBuildSheet_BuildSheetId",
                table: "InsertBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelBuildSheet_BuildSheetId",
                table: "LabelBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingBuildSheet_BuildSheetId",
                table: "PackagingBuildSheet",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TesterSoftwareBuildsheet_BuildSheetId",
                table: "TesterSoftwareBuildsheet",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkInstructionBuildSheet_BuildSheetId",
                table: "WorkInstructionBuildSheet",
                column: "BuildSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardBuildSheet");

            migrationBuilder.DropTable(
                name: "CertificationLabelRequirementBuildSheet");

            migrationBuilder.DropTable(
                name: "ContractManufactureAssemblyDrawingBuildSheet");

            migrationBuilder.DropTable(
                name: "DocumentBuildSheet");

            migrationBuilder.DropTable(
                name: "GeotabAssemblyDrawingBuildSheet");

            migrationBuilder.DropTable(
                name: "HardwareBuildSheet");

            migrationBuilder.DropTable(
                name: "InsertBuildSheet");

            migrationBuilder.DropTable(
                name: "LabelBuildSheet");

            migrationBuilder.DropTable(
                name: "PackagingBuildSheet");

            migrationBuilder.DropTable(
                name: "TesterParameters");

            migrationBuilder.DropTable(
                name: "TesterSoftwareBuildsheet");

            migrationBuilder.DropTable(
                name: "WorkInstructionBuildSheet");

            migrationBuilder.DropTable(
                name: "Board");

            migrationBuilder.DropTable(
                name: "CertificationLabelRequirement");

            migrationBuilder.DropTable(
                name: "ContractManufactureAssemblyDrawing");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "GeotabAssemblyDrawing");

            migrationBuilder.DropTable(
                name: "Hardware");

            migrationBuilder.DropTable(
                name: "Insert");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "Packaging");

            migrationBuilder.DropTable(
                name: "TesterSoftware");

            migrationBuilder.DropTable(
                name: "BuildSheets");

            migrationBuilder.DropTable(
                name: "WorkInstruction");

            migrationBuilder.DropTable(
                name: "DeviceFirmware");

            migrationBuilder.DropTable(
                name: "Modem");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
