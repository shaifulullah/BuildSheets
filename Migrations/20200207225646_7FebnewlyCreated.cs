using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildSheets.Migrations
{
    public partial class _7FebnewlyCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseBoards",
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
                    table.PrimaryKey("PK_BaseBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildSheets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductOwner = table.Column<string>(nullable: true),
                    ProductLaunchDate = table.Column<DateTime>(nullable: false),
                    ProvisioningPackage = table.Column<string>(nullable: true),
                    ProductStatus = table.Column<int>(nullable: false),
                    Revision = table.Column<string>(nullable: true),
                    RevisionURL = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    ProductUpdatedOn = table.Column<DateTime>(nullable: false),
                    ECOId = table.Column<int>(nullable: true),
                    APN = table.Column<string>(nullable: true),
                    CustomerGateway = table.Column<string>(nullable: true),
                    ProductImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildSheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificationLabelRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SideA = table.Column<string>(nullable: true),
                    SideADescription = table.Column<string>(nullable: true),
                    SideAURL = table.Column<string>(nullable: true),
                    SideB = table.Column<string>(nullable: true),
                    SideBDescription = table.Column<string>(nullable: true),
                    SideBURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationLabelRequirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeofCertificate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractManufactureAssemblyDrawings",
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
                    table.PrimaryKey("PK_ContractManufactureAssemblyDrawings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Rev = table.Column<string>(nullable: true),
                    RevDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeotabAssemblyDrawings",
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
                    table.PrimaryKey("PK_GeotabAssemblyDrawings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hardwares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rev = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hardwares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inserts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rev = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inserts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalSubAssemblyBoards",
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
                    table.PrimaryKey("PK_InternalSubAssemblyBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rev = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packagings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rev = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packagings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubBoards",
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
                    table.PrimaryKey("PK_SubBoards", x => x.Id);
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
                name: "TesterSoftwares",
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
                    table.PrimaryKey("PK_TesterSoftwares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkInstructions",
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
                    table.PrimaryKey("PK_WorkInstructions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseBoardBuildSheets",
                columns: table => new
                {
                    BaseBoardBuildSheetId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseBoardBuildSheets", x => new { x.BaseBoardBuildSheetId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_BaseBoardBuildSheets_BaseBoards_BaseBoardBuildSheetId",
                        column: x => x.BaseBoardBuildSheetId,
                        principalTable: "BaseBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseBoardBuildSheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificationLabelRequirementBuildSheets",
                columns: table => new
                {
                    CertificationLabelRequirementId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationLabelRequirementBuildSheets", x => new { x.CertificationLabelRequirementId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_CertificationLabelRequirementBuildSheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificationLabelRequirementBuildSheets_CertificationLabelRequirements_CertificationLabelRequirementId",
                        column: x => x.CertificationLabelRequirementId,
                        principalTable: "CertificationLabelRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificationTypeBuildSheets",
                columns: table => new
                {
                    CertificationTypeId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationTypeBuildSheets", x => new { x.CertificationTypeId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_CertificationTypeBuildSheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificationTypeBuildSheets_CertificationTypes_CertificationTypeId",
                        column: x => x.CertificationTypeId,
                        principalTable: "CertificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractManufactureAssemblyDrawingBuildSheets",
                columns: table => new
                {
                    ContractManufactureAssemblyDrawingId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractManufactureAssemblyDrawingBuildSheets", x => new { x.ContractManufactureAssemblyDrawingId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_ContractManufactureAssemblyDrawingBuildSheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractManufactureAssemblyDrawingBuildSheets_ContractManufactureAssemblyDrawings_ContractManufactureAssemblyDrawingId",
                        column: x => x.ContractManufactureAssemblyDrawingId,
                        principalTable: "ContractManufactureAssemblyDrawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentBuildSheets",
                columns: table => new
                {
                    DocumentId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentBuildSheets", x => new { x.DocumentId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_DocumentBuildSheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentBuildSheets_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeotabAssemblyDrawingBuildSheets",
                columns: table => new
                {
                    GeotabAssemblyDrawingId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeotabAssemblyDrawingBuildSheets", x => new { x.GeotabAssemblyDrawingId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_GeotabAssemblyDrawingBuildSheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeotabAssemblyDrawingBuildSheets_GeotabAssemblyDrawings_GeotabAssemblyDrawingId",
                        column: x => x.GeotabAssemblyDrawingId,
                        principalTable: "GeotabAssemblyDrawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HardwareBuildSheets",
                columns: table => new
                {
                    HardwareId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false),
                    Quantity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareBuildSheets", x => new { x.HardwareId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_HardwareBuildSheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HardwareBuildSheets_Hardwares_HardwareId",
                        column: x => x.HardwareId,
                        principalTable: "Hardwares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsertBuildsheets",
                columns: table => new
                {
                    InsertId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false),
                    Quantity = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "InternalSubAssemblyBoardBuildSheets",
                columns: table => new
                {
                    InternalSubAssemblyBoardId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalSubAssemblyBoardBuildSheets", x => new { x.InternalSubAssemblyBoardId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_InternalSubAssemblyBoardBuildSheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalSubAssemblyBoardBuildSheets_InternalSubAssemblyBoards_InternalSubAssemblyBoardId",
                        column: x => x.InternalSubAssemblyBoardId,
                        principalTable: "InternalSubAssemblyBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabelBuildSheets",
                columns: table => new
                {
                    LabelId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false),
                    Quantity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelBuildSheets", x => new { x.LabelId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_LabelBuildSheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabelBuildSheets_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackagingBuildSheets",
                columns: table => new
                {
                    PackagingId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false),
                    Quantity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagingBuildSheets", x => new { x.PackagingId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_PackagingBuildSheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackagingBuildSheets_Packagings_PackagingId",
                        column: x => x.PackagingId,
                        principalTable: "Packagings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubBoardBuildSheets",
                columns: table => new
                {
                    SubBoardBuildSheetId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubBoardBuildSheets", x => new { x.SubBoardBuildSheetId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_SubBoardBuildSheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubBoardBuildSheets_SubBoards_SubBoardBuildSheetId",
                        column: x => x.SubBoardBuildSheetId,
                        principalTable: "SubBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TesterSoftwareBuildsheets",
                columns: table => new
                {
                    TesterSoftwareId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesterSoftwareBuildsheets", x => new { x.TesterSoftwareId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_TesterSoftwareBuildsheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TesterSoftwareBuildsheets_TesterSoftwares_TesterSoftwareId",
                        column: x => x.TesterSoftwareId,
                        principalTable: "TesterSoftwares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkInstructionBuildSheets",
                columns: table => new
                {
                    WorkInstructionId = table.Column<int>(nullable: false),
                    BuildSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkInstructionBuildSheets", x => new { x.WorkInstructionId, x.BuildSheetId });
                    table.ForeignKey(
                        name: "FK_WorkInstructionBuildSheets_BuildSheets_BuildSheetId",
                        column: x => x.BuildSheetId,
                        principalTable: "BuildSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkInstructionBuildSheets_WorkInstructions_WorkInstructionId",
                        column: x => x.WorkInstructionId,
                        principalTable: "WorkInstructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseBoardBuildSheets_BuildSheetId",
                table: "BaseBoardBuildSheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationLabelRequirementBuildSheets_BuildSheetId",
                table: "CertificationLabelRequirementBuildSheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationTypeBuildSheets_BuildSheetId",
                table: "CertificationTypeBuildSheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractManufactureAssemblyDrawingBuildSheets_BuildSheetId",
                table: "ContractManufactureAssemblyDrawingBuildSheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentBuildSheets_BuildSheetId",
                table: "DocumentBuildSheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_GeotabAssemblyDrawingBuildSheets_BuildSheetId",
                table: "GeotabAssemblyDrawingBuildSheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareBuildSheets_BuildSheetId",
                table: "HardwareBuildSheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_InsertBuildsheets_BuildSheetId",
                table: "InsertBuildsheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalSubAssemblyBoardBuildSheets_BuildSheetId",
                table: "InternalSubAssemblyBoardBuildSheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelBuildSheets_BuildSheetId",
                table: "LabelBuildSheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingBuildSheets_BuildSheetId",
                table: "PackagingBuildSheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_SubBoardBuildSheets_BuildSheetId",
                table: "SubBoardBuildSheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TesterSoftwareBuildsheets_BuildSheetId",
                table: "TesterSoftwareBuildsheets",
                column: "BuildSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkInstructionBuildSheets_BuildSheetId",
                table: "WorkInstructionBuildSheets",
                column: "BuildSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseBoardBuildSheets");

            migrationBuilder.DropTable(
                name: "CertificationLabelRequirementBuildSheets");

            migrationBuilder.DropTable(
                name: "CertificationTypeBuildSheets");

            migrationBuilder.DropTable(
                name: "ContractManufactureAssemblyDrawingBuildSheets");

            migrationBuilder.DropTable(
                name: "DocumentBuildSheets");

            migrationBuilder.DropTable(
                name: "GeotabAssemblyDrawingBuildSheets");

            migrationBuilder.DropTable(
                name: "HardwareBuildSheets");

            migrationBuilder.DropTable(
                name: "InsertBuildsheets");

            migrationBuilder.DropTable(
                name: "InternalSubAssemblyBoardBuildSheets");

            migrationBuilder.DropTable(
                name: "LabelBuildSheets");

            migrationBuilder.DropTable(
                name: "PackagingBuildSheets");

            migrationBuilder.DropTable(
                name: "SubBoardBuildSheets");

            migrationBuilder.DropTable(
                name: "TesterParameters");

            migrationBuilder.DropTable(
                name: "TesterSoftwareBuildsheets");

            migrationBuilder.DropTable(
                name: "WorkInstructionBuildSheets");

            migrationBuilder.DropTable(
                name: "BaseBoards");

            migrationBuilder.DropTable(
                name: "CertificationLabelRequirements");

            migrationBuilder.DropTable(
                name: "CertificationTypes");

            migrationBuilder.DropTable(
                name: "ContractManufactureAssemblyDrawings");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "GeotabAssemblyDrawings");

            migrationBuilder.DropTable(
                name: "Hardwares");

            migrationBuilder.DropTable(
                name: "Inserts");

            migrationBuilder.DropTable(
                name: "InternalSubAssemblyBoards");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Packagings");

            migrationBuilder.DropTable(
                name: "SubBoards");

            migrationBuilder.DropTable(
                name: "TesterSoftwares");

            migrationBuilder.DropTable(
                name: "BuildSheets");

            migrationBuilder.DropTable(
                name: "WorkInstructions");
        }
    }
}
