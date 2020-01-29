using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildSheets.Migrations
{
    public partial class ModifiedFewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseBoardBuildSheet_BaseBoard_BaseBoardBuildSheetId",
                table: "BaseBoardBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseBoardBuildSheet_BuildSheets_BuildSheetId",
                table: "BaseBoardBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificationLabelRequirementBuildSheet_BuildSheets_BuildSheetId",
                table: "CertificationLabelRequirementBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificationLabelRequirementBuildSheet_CertificationLabelRequirement_CertificationLabelRequirementId",
                table: "CertificationLabelRequirementBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractManufactureAssemblyDrawingBuildSheet_BuildSheets_BuildSheetId",
                table: "ContractManufactureAssemblyDrawingBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractManufactureAssemblyDrawingBuildSheet_ContractManufactureAssemblyDrawing_ContractManufactureAssemblyDrawingId",
                table: "ContractManufactureAssemblyDrawingBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentBuildSheet_BuildSheets_BuildSheetId",
                table: "DocumentBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentBuildSheet_Document_DocumentId",
                table: "DocumentBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_GeotabAssemblyDrawingBuildSheet_BuildSheets_BuildSheetId",
                table: "GeotabAssemblyDrawingBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_GeotabAssemblyDrawingBuildSheet_GeotabAssemblyDrawing_GeotabAssemblyDrawingId",
                table: "GeotabAssemblyDrawingBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareBuildSheet_BuildSheets_BuildSheetId",
                table: "HardwareBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareBuildSheet_Hardware_HardwareId",
                table: "HardwareBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertBuildsheet_BuildSheets_BuildSheetId",
                table: "InsertBuildsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertBuildsheet_Insert_InsertId",
                table: "InsertBuildsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalSubAssemblyBoardBuildSheet_BuildSheets_BuildSheetId",
                table: "InternalSubAssemblyBoardBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalSubAssemblyBoardBuildSheet_InternalSubAssemblyBoard_InternalSubAssemblyBoardId",
                table: "InternalSubAssemblyBoardBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_LabelBuildSheet_BuildSheets_BuildSheetId",
                table: "LabelBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_LabelBuildSheet_Label_LabelId",
                table: "LabelBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagingBuildSheet_BuildSheets_BuildSheetId",
                table: "PackagingBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagingBuildSheet_Packaging_PackagingId",
                table: "PackagingBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_SubBoardBuildSheet_BuildSheets_BuildSheetId",
                table: "SubBoardBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_SubBoardBuildSheet_SubBoard_SubBoardBuildSheetId",
                table: "SubBoardBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_TesterSoftwareBuildsheet_BuildSheets_BuildSheetId",
                table: "TesterSoftwareBuildsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_TesterSoftwareBuildsheet_TesterSoftware_TesterSoftwareId",
                table: "TesterSoftwareBuildsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInstructionBuildSheet_BuildSheets_BuildSheetId",
                table: "WorkInstructionBuildSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInstructionBuildSheet_WorkInstruction_WorkInstructionId",
                table: "WorkInstructionBuildSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkInstructionBuildSheet",
                table: "WorkInstructionBuildSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkInstruction",
                table: "WorkInstruction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TesterSoftwareBuildsheet",
                table: "TesterSoftwareBuildsheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TesterSoftware",
                table: "TesterSoftware");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubBoardBuildSheet",
                table: "SubBoardBuildSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubBoard",
                table: "SubBoard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackagingBuildSheet",
                table: "PackagingBuildSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packaging",
                table: "Packaging");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LabelBuildSheet",
                table: "LabelBuildSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Label",
                table: "Label");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternalSubAssemblyBoardBuildSheet",
                table: "InternalSubAssemblyBoardBuildSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternalSubAssemblyBoard",
                table: "InternalSubAssemblyBoard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsertBuildsheet",
                table: "InsertBuildsheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insert",
                table: "Insert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HardwareBuildSheet",
                table: "HardwareBuildSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hardware",
                table: "Hardware");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeotabAssemblyDrawingBuildSheet",
                table: "GeotabAssemblyDrawingBuildSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeotabAssemblyDrawing",
                table: "GeotabAssemblyDrawing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentBuildSheet",
                table: "DocumentBuildSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractManufactureAssemblyDrawingBuildSheet",
                table: "ContractManufactureAssemblyDrawingBuildSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractManufactureAssemblyDrawing",
                table: "ContractManufactureAssemblyDrawing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificationLabelRequirementBuildSheet",
                table: "CertificationLabelRequirementBuildSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificationLabelRequirement",
                table: "CertificationLabelRequirement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseBoardBuildSheet",
                table: "BaseBoardBuildSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseBoard",
                table: "BaseBoard");

            migrationBuilder.RenameTable(
                name: "WorkInstructionBuildSheet",
                newName: "WorkInstructionBuildSheets");

            migrationBuilder.RenameTable(
                name: "WorkInstruction",
                newName: "WorkInstructions");

            migrationBuilder.RenameTable(
                name: "TesterSoftwareBuildsheet",
                newName: "TesterSoftwareBuildsheets");

            migrationBuilder.RenameTable(
                name: "TesterSoftware",
                newName: "TesterSoftwares");

            migrationBuilder.RenameTable(
                name: "SubBoardBuildSheet",
                newName: "SubBoardBuildSheets");

            migrationBuilder.RenameTable(
                name: "SubBoard",
                newName: "SubBoards");

            migrationBuilder.RenameTable(
                name: "PackagingBuildSheet",
                newName: "PackagingBuildSheets");

            migrationBuilder.RenameTable(
                name: "Packaging",
                newName: "Packagings");

            migrationBuilder.RenameTable(
                name: "LabelBuildSheet",
                newName: "LabelBuildSheets");

            migrationBuilder.RenameTable(
                name: "Label",
                newName: "Labels");

            migrationBuilder.RenameTable(
                name: "InternalSubAssemblyBoardBuildSheet",
                newName: "InternalSubAssemblyBoardBuildSheets");

            migrationBuilder.RenameTable(
                name: "InternalSubAssemblyBoard",
                newName: "InternalSubAssemblyBoards");

            migrationBuilder.RenameTable(
                name: "InsertBuildsheet",
                newName: "InsertBuildsheets");

            migrationBuilder.RenameTable(
                name: "Insert",
                newName: "Inserts");

            migrationBuilder.RenameTable(
                name: "HardwareBuildSheet",
                newName: "HardwareBuildSheets");

            migrationBuilder.RenameTable(
                name: "Hardware",
                newName: "Hardwares");

            migrationBuilder.RenameTable(
                name: "GeotabAssemblyDrawingBuildSheet",
                newName: "GeotabAssemblyDrawingBuildSheets");

            migrationBuilder.RenameTable(
                name: "GeotabAssemblyDrawing",
                newName: "GeotabAssemblyDrawings");

            migrationBuilder.RenameTable(
                name: "DocumentBuildSheet",
                newName: "DocumentBuildSheets");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documents");

            migrationBuilder.RenameTable(
                name: "ContractManufactureAssemblyDrawingBuildSheet",
                newName: "ContractManufactureAssemblyDrawingBuildSheets");

            migrationBuilder.RenameTable(
                name: "ContractManufactureAssemblyDrawing",
                newName: "ContractManufactureAssemblyDrawings");

            migrationBuilder.RenameTable(
                name: "CertificationLabelRequirementBuildSheet",
                newName: "CertificationLabelRequirementBuildSheets");

            migrationBuilder.RenameTable(
                name: "CertificationLabelRequirement",
                newName: "CertificationLabelRequirements");

            migrationBuilder.RenameTable(
                name: "BaseBoardBuildSheet",
                newName: "BaseBoardBuildSheets");

            migrationBuilder.RenameTable(
                name: "BaseBoard",
                newName: "BaseBoards");

            migrationBuilder.RenameIndex(
                name: "IX_WorkInstructionBuildSheet_BuildSheetId",
                table: "WorkInstructionBuildSheets",
                newName: "IX_WorkInstructionBuildSheets_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_TesterSoftwareBuildsheet_BuildSheetId",
                table: "TesterSoftwareBuildsheets",
                newName: "IX_TesterSoftwareBuildsheets_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_SubBoardBuildSheet_BuildSheetId",
                table: "SubBoardBuildSheets",
                newName: "IX_SubBoardBuildSheets_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_PackagingBuildSheet_BuildSheetId",
                table: "PackagingBuildSheets",
                newName: "IX_PackagingBuildSheets_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_LabelBuildSheet_BuildSheetId",
                table: "LabelBuildSheets",
                newName: "IX_LabelBuildSheets_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_InternalSubAssemblyBoardBuildSheet_BuildSheetId",
                table: "InternalSubAssemblyBoardBuildSheets",
                newName: "IX_InternalSubAssemblyBoardBuildSheets_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_InsertBuildsheet_BuildSheetId",
                table: "InsertBuildsheets",
                newName: "IX_InsertBuildsheets_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_HardwareBuildSheet_BuildSheetId",
                table: "HardwareBuildSheets",
                newName: "IX_HardwareBuildSheets_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_GeotabAssemblyDrawingBuildSheet_BuildSheetId",
                table: "GeotabAssemblyDrawingBuildSheets",
                newName: "IX_GeotabAssemblyDrawingBuildSheets_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentBuildSheet_BuildSheetId",
                table: "DocumentBuildSheets",
                newName: "IX_DocumentBuildSheets_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractManufactureAssemblyDrawingBuildSheet_BuildSheetId",
                table: "ContractManufactureAssemblyDrawingBuildSheets",
                newName: "IX_ContractManufactureAssemblyDrawingBuildSheets_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_CertificationLabelRequirementBuildSheet_BuildSheetId",
                table: "CertificationLabelRequirementBuildSheets",
                newName: "IX_CertificationLabelRequirementBuildSheets_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseBoardBuildSheet_BuildSheetId",
                table: "BaseBoardBuildSheets",
                newName: "IX_BaseBoardBuildSheets_BuildSheetId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "BuildSheets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RevisionURL",
                table: "BuildSheets",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rev",
                table: "Packagings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Packagings",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rev",
                table: "Labels",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Labels",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkInstructionBuildSheets",
                table: "WorkInstructionBuildSheets",
                columns: new[] { "WorkInstructionId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkInstructions",
                table: "WorkInstructions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TesterSoftwareBuildsheets",
                table: "TesterSoftwareBuildsheets",
                columns: new[] { "TesterSoftwareId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TesterSoftwares",
                table: "TesterSoftwares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubBoardBuildSheets",
                table: "SubBoardBuildSheets",
                columns: new[] { "SubBoardBuildSheetId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubBoards",
                table: "SubBoards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackagingBuildSheets",
                table: "PackagingBuildSheets",
                columns: new[] { "PackagingId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packagings",
                table: "Packagings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabelBuildSheets",
                table: "LabelBuildSheets",
                columns: new[] { "LabelId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labels",
                table: "Labels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternalSubAssemblyBoardBuildSheets",
                table: "InternalSubAssemblyBoardBuildSheets",
                columns: new[] { "InternalSubAssemblyBoardId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternalSubAssemblyBoards",
                table: "InternalSubAssemblyBoards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsertBuildsheets",
                table: "InsertBuildsheets",
                columns: new[] { "InsertId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inserts",
                table: "Inserts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HardwareBuildSheets",
                table: "HardwareBuildSheets",
                columns: new[] { "HardwareId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hardwares",
                table: "Hardwares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeotabAssemblyDrawingBuildSheets",
                table: "GeotabAssemblyDrawingBuildSheets",
                columns: new[] { "GeotabAssemblyDrawingId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeotabAssemblyDrawings",
                table: "GeotabAssemblyDrawings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentBuildSheets",
                table: "DocumentBuildSheets",
                columns: new[] { "DocumentId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractManufactureAssemblyDrawingBuildSheets",
                table: "ContractManufactureAssemblyDrawingBuildSheets",
                columns: new[] { "ContractManufactureAssemblyDrawingId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractManufactureAssemblyDrawings",
                table: "ContractManufactureAssemblyDrawings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificationLabelRequirementBuildSheets",
                table: "CertificationLabelRequirementBuildSheets",
                columns: new[] { "CertificationLabelRequirementId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificationLabelRequirements",
                table: "CertificationLabelRequirements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseBoardBuildSheets",
                table: "BaseBoardBuildSheets",
                columns: new[] { "BaseBoardBuildSheetId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseBoards",
                table: "BaseBoards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseBoardBuildSheets_BaseBoards_BaseBoardBuildSheetId",
                table: "BaseBoardBuildSheets",
                column: "BaseBoardBuildSheetId",
                principalTable: "BaseBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseBoardBuildSheets_BuildSheets_BuildSheetId",
                table: "BaseBoardBuildSheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationLabelRequirementBuildSheets_BuildSheets_BuildSheetId",
                table: "CertificationLabelRequirementBuildSheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationLabelRequirementBuildSheets_CertificationLabelRequirements_CertificationLabelRequirementId",
                table: "CertificationLabelRequirementBuildSheets",
                column: "CertificationLabelRequirementId",
                principalTable: "CertificationLabelRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractManufactureAssemblyDrawingBuildSheets_BuildSheets_BuildSheetId",
                table: "ContractManufactureAssemblyDrawingBuildSheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractManufactureAssemblyDrawingBuildSheets_ContractManufactureAssemblyDrawings_ContractManufactureAssemblyDrawingId",
                table: "ContractManufactureAssemblyDrawingBuildSheets",
                column: "ContractManufactureAssemblyDrawingId",
                principalTable: "ContractManufactureAssemblyDrawings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentBuildSheets_BuildSheets_BuildSheetId",
                table: "DocumentBuildSheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentBuildSheets_Documents_DocumentId",
                table: "DocumentBuildSheets",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeotabAssemblyDrawingBuildSheets_BuildSheets_BuildSheetId",
                table: "GeotabAssemblyDrawingBuildSheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeotabAssemblyDrawingBuildSheets_GeotabAssemblyDrawings_GeotabAssemblyDrawingId",
                table: "GeotabAssemblyDrawingBuildSheets",
                column: "GeotabAssemblyDrawingId",
                principalTable: "GeotabAssemblyDrawings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareBuildSheets_BuildSheets_BuildSheetId",
                table: "HardwareBuildSheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareBuildSheets_Hardwares_HardwareId",
                table: "HardwareBuildSheets",
                column: "HardwareId",
                principalTable: "Hardwares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsertBuildsheets_BuildSheets_BuildSheetId",
                table: "InsertBuildsheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsertBuildsheets_Inserts_InsertId",
                table: "InsertBuildsheets",
                column: "InsertId",
                principalTable: "Inserts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalSubAssemblyBoardBuildSheets_BuildSheets_BuildSheetId",
                table: "InternalSubAssemblyBoardBuildSheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalSubAssemblyBoardBuildSheets_InternalSubAssemblyBoards_InternalSubAssemblyBoardId",
                table: "InternalSubAssemblyBoardBuildSheets",
                column: "InternalSubAssemblyBoardId",
                principalTable: "InternalSubAssemblyBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabelBuildSheets_BuildSheets_BuildSheetId",
                table: "LabelBuildSheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabelBuildSheets_Labels_LabelId",
                table: "LabelBuildSheets",
                column: "LabelId",
                principalTable: "Labels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackagingBuildSheets_BuildSheets_BuildSheetId",
                table: "PackagingBuildSheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackagingBuildSheets_Packagings_PackagingId",
                table: "PackagingBuildSheets",
                column: "PackagingId",
                principalTable: "Packagings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubBoardBuildSheets_BuildSheets_BuildSheetId",
                table: "SubBoardBuildSheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubBoardBuildSheets_SubBoards_SubBoardBuildSheetId",
                table: "SubBoardBuildSheets",
                column: "SubBoardBuildSheetId",
                principalTable: "SubBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TesterSoftwareBuildsheets_BuildSheets_BuildSheetId",
                table: "TesterSoftwareBuildsheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TesterSoftwareBuildsheets_TesterSoftwares_TesterSoftwareId",
                table: "TesterSoftwareBuildsheets",
                column: "TesterSoftwareId",
                principalTable: "TesterSoftwares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInstructionBuildSheets_BuildSheets_BuildSheetId",
                table: "WorkInstructionBuildSheets",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInstructionBuildSheets_WorkInstructions_WorkInstructionId",
                table: "WorkInstructionBuildSheets",
                column: "WorkInstructionId",
                principalTable: "WorkInstructions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseBoardBuildSheets_BaseBoards_BaseBoardBuildSheetId",
                table: "BaseBoardBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseBoardBuildSheets_BuildSheets_BuildSheetId",
                table: "BaseBoardBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificationLabelRequirementBuildSheets_BuildSheets_BuildSheetId",
                table: "CertificationLabelRequirementBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificationLabelRequirementBuildSheets_CertificationLabelRequirements_CertificationLabelRequirementId",
                table: "CertificationLabelRequirementBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractManufactureAssemblyDrawingBuildSheets_BuildSheets_BuildSheetId",
                table: "ContractManufactureAssemblyDrawingBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractManufactureAssemblyDrawingBuildSheets_ContractManufactureAssemblyDrawings_ContractManufactureAssemblyDrawingId",
                table: "ContractManufactureAssemblyDrawingBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentBuildSheets_BuildSheets_BuildSheetId",
                table: "DocumentBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentBuildSheets_Documents_DocumentId",
                table: "DocumentBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_GeotabAssemblyDrawingBuildSheets_BuildSheets_BuildSheetId",
                table: "GeotabAssemblyDrawingBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_GeotabAssemblyDrawingBuildSheets_GeotabAssemblyDrawings_GeotabAssemblyDrawingId",
                table: "GeotabAssemblyDrawingBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareBuildSheets_BuildSheets_BuildSheetId",
                table: "HardwareBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareBuildSheets_Hardwares_HardwareId",
                table: "HardwareBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertBuildsheets_BuildSheets_BuildSheetId",
                table: "InsertBuildsheets");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertBuildsheets_Inserts_InsertId",
                table: "InsertBuildsheets");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalSubAssemblyBoardBuildSheets_BuildSheets_BuildSheetId",
                table: "InternalSubAssemblyBoardBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalSubAssemblyBoardBuildSheets_InternalSubAssemblyBoards_InternalSubAssemblyBoardId",
                table: "InternalSubAssemblyBoardBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LabelBuildSheets_BuildSheets_BuildSheetId",
                table: "LabelBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LabelBuildSheets_Labels_LabelId",
                table: "LabelBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagingBuildSheets_BuildSheets_BuildSheetId",
                table: "PackagingBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagingBuildSheets_Packagings_PackagingId",
                table: "PackagingBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_SubBoardBuildSheets_BuildSheets_BuildSheetId",
                table: "SubBoardBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_SubBoardBuildSheets_SubBoards_SubBoardBuildSheetId",
                table: "SubBoardBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_TesterSoftwareBuildsheets_BuildSheets_BuildSheetId",
                table: "TesterSoftwareBuildsheets");

            migrationBuilder.DropForeignKey(
                name: "FK_TesterSoftwareBuildsheets_TesterSoftwares_TesterSoftwareId",
                table: "TesterSoftwareBuildsheets");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInstructionBuildSheets_BuildSheets_BuildSheetId",
                table: "WorkInstructionBuildSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInstructionBuildSheets_WorkInstructions_WorkInstructionId",
                table: "WorkInstructionBuildSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkInstructions",
                table: "WorkInstructions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkInstructionBuildSheets",
                table: "WorkInstructionBuildSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TesterSoftwares",
                table: "TesterSoftwares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TesterSoftwareBuildsheets",
                table: "TesterSoftwareBuildsheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubBoards",
                table: "SubBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubBoardBuildSheets",
                table: "SubBoardBuildSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packagings",
                table: "Packagings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackagingBuildSheets",
                table: "PackagingBuildSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labels",
                table: "Labels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LabelBuildSheets",
                table: "LabelBuildSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternalSubAssemblyBoards",
                table: "InternalSubAssemblyBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternalSubAssemblyBoardBuildSheets",
                table: "InternalSubAssemblyBoardBuildSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inserts",
                table: "Inserts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsertBuildsheets",
                table: "InsertBuildsheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hardwares",
                table: "Hardwares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HardwareBuildSheets",
                table: "HardwareBuildSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeotabAssemblyDrawings",
                table: "GeotabAssemblyDrawings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeotabAssemblyDrawingBuildSheets",
                table: "GeotabAssemblyDrawingBuildSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentBuildSheets",
                table: "DocumentBuildSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractManufactureAssemblyDrawings",
                table: "ContractManufactureAssemblyDrawings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractManufactureAssemblyDrawingBuildSheets",
                table: "ContractManufactureAssemblyDrawingBuildSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificationLabelRequirements",
                table: "CertificationLabelRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificationLabelRequirementBuildSheets",
                table: "CertificationLabelRequirementBuildSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseBoards",
                table: "BaseBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseBoardBuildSheets",
                table: "BaseBoardBuildSheets");

            migrationBuilder.DropColumn(
                name: "RevisionURL",
                table: "BuildSheets");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Packagings");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Labels");

            migrationBuilder.RenameTable(
                name: "WorkInstructions",
                newName: "WorkInstruction");

            migrationBuilder.RenameTable(
                name: "WorkInstructionBuildSheets",
                newName: "WorkInstructionBuildSheet");

            migrationBuilder.RenameTable(
                name: "TesterSoftwares",
                newName: "TesterSoftware");

            migrationBuilder.RenameTable(
                name: "TesterSoftwareBuildsheets",
                newName: "TesterSoftwareBuildsheet");

            migrationBuilder.RenameTable(
                name: "SubBoards",
                newName: "SubBoard");

            migrationBuilder.RenameTable(
                name: "SubBoardBuildSheets",
                newName: "SubBoardBuildSheet");

            migrationBuilder.RenameTable(
                name: "Packagings",
                newName: "Packaging");

            migrationBuilder.RenameTable(
                name: "PackagingBuildSheets",
                newName: "PackagingBuildSheet");

            migrationBuilder.RenameTable(
                name: "Labels",
                newName: "Label");

            migrationBuilder.RenameTable(
                name: "LabelBuildSheets",
                newName: "LabelBuildSheet");

            migrationBuilder.RenameTable(
                name: "InternalSubAssemblyBoards",
                newName: "InternalSubAssemblyBoard");

            migrationBuilder.RenameTable(
                name: "InternalSubAssemblyBoardBuildSheets",
                newName: "InternalSubAssemblyBoardBuildSheet");

            migrationBuilder.RenameTable(
                name: "Inserts",
                newName: "Insert");

            migrationBuilder.RenameTable(
                name: "InsertBuildsheets",
                newName: "InsertBuildsheet");

            migrationBuilder.RenameTable(
                name: "Hardwares",
                newName: "Hardware");

            migrationBuilder.RenameTable(
                name: "HardwareBuildSheets",
                newName: "HardwareBuildSheet");

            migrationBuilder.RenameTable(
                name: "GeotabAssemblyDrawings",
                newName: "GeotabAssemblyDrawing");

            migrationBuilder.RenameTable(
                name: "GeotabAssemblyDrawingBuildSheets",
                newName: "GeotabAssemblyDrawingBuildSheet");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Document");

            migrationBuilder.RenameTable(
                name: "DocumentBuildSheets",
                newName: "DocumentBuildSheet");

            migrationBuilder.RenameTable(
                name: "ContractManufactureAssemblyDrawings",
                newName: "ContractManufactureAssemblyDrawing");

            migrationBuilder.RenameTable(
                name: "ContractManufactureAssemblyDrawingBuildSheets",
                newName: "ContractManufactureAssemblyDrawingBuildSheet");

            migrationBuilder.RenameTable(
                name: "CertificationLabelRequirements",
                newName: "CertificationLabelRequirement");

            migrationBuilder.RenameTable(
                name: "CertificationLabelRequirementBuildSheets",
                newName: "CertificationLabelRequirementBuildSheet");

            migrationBuilder.RenameTable(
                name: "BaseBoards",
                newName: "BaseBoard");

            migrationBuilder.RenameTable(
                name: "BaseBoardBuildSheets",
                newName: "BaseBoardBuildSheet");

            migrationBuilder.RenameIndex(
                name: "IX_WorkInstructionBuildSheets_BuildSheetId",
                table: "WorkInstructionBuildSheet",
                newName: "IX_WorkInstructionBuildSheet_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_TesterSoftwareBuildsheets_BuildSheetId",
                table: "TesterSoftwareBuildsheet",
                newName: "IX_TesterSoftwareBuildsheet_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_SubBoardBuildSheets_BuildSheetId",
                table: "SubBoardBuildSheet",
                newName: "IX_SubBoardBuildSheet_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_PackagingBuildSheets_BuildSheetId",
                table: "PackagingBuildSheet",
                newName: "IX_PackagingBuildSheet_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_LabelBuildSheets_BuildSheetId",
                table: "LabelBuildSheet",
                newName: "IX_LabelBuildSheet_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_InternalSubAssemblyBoardBuildSheets_BuildSheetId",
                table: "InternalSubAssemblyBoardBuildSheet",
                newName: "IX_InternalSubAssemblyBoardBuildSheet_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_InsertBuildsheets_BuildSheetId",
                table: "InsertBuildsheet",
                newName: "IX_InsertBuildsheet_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_HardwareBuildSheets_BuildSheetId",
                table: "HardwareBuildSheet",
                newName: "IX_HardwareBuildSheet_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_GeotabAssemblyDrawingBuildSheets_BuildSheetId",
                table: "GeotabAssemblyDrawingBuildSheet",
                newName: "IX_GeotabAssemblyDrawingBuildSheet_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentBuildSheets_BuildSheetId",
                table: "DocumentBuildSheet",
                newName: "IX_DocumentBuildSheet_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractManufactureAssemblyDrawingBuildSheets_BuildSheetId",
                table: "ContractManufactureAssemblyDrawingBuildSheet",
                newName: "IX_ContractManufactureAssemblyDrawingBuildSheet_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_CertificationLabelRequirementBuildSheets_BuildSheetId",
                table: "CertificationLabelRequirementBuildSheet",
                newName: "IX_CertificationLabelRequirementBuildSheet_BuildSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseBoardBuildSheets_BuildSheetId",
                table: "BaseBoardBuildSheet",
                newName: "IX_BaseBoardBuildSheet_BuildSheetId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "BuildSheets",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Rev",
                table: "Packaging",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rev",
                table: "Label",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkInstruction",
                table: "WorkInstruction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkInstructionBuildSheet",
                table: "WorkInstructionBuildSheet",
                columns: new[] { "WorkInstructionId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TesterSoftware",
                table: "TesterSoftware",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TesterSoftwareBuildsheet",
                table: "TesterSoftwareBuildsheet",
                columns: new[] { "TesterSoftwareId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubBoard",
                table: "SubBoard",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubBoardBuildSheet",
                table: "SubBoardBuildSheet",
                columns: new[] { "SubBoardBuildSheetId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packaging",
                table: "Packaging",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackagingBuildSheet",
                table: "PackagingBuildSheet",
                columns: new[] { "PackagingId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Label",
                table: "Label",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabelBuildSheet",
                table: "LabelBuildSheet",
                columns: new[] { "LabelId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternalSubAssemblyBoard",
                table: "InternalSubAssemblyBoard",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternalSubAssemblyBoardBuildSheet",
                table: "InternalSubAssemblyBoardBuildSheet",
                columns: new[] { "InternalSubAssemblyBoardId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insert",
                table: "Insert",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsertBuildsheet",
                table: "InsertBuildsheet",
                columns: new[] { "InsertId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hardware",
                table: "Hardware",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HardwareBuildSheet",
                table: "HardwareBuildSheet",
                columns: new[] { "HardwareId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeotabAssemblyDrawing",
                table: "GeotabAssemblyDrawing",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeotabAssemblyDrawingBuildSheet",
                table: "GeotabAssemblyDrawingBuildSheet",
                columns: new[] { "GeotabAssemblyDrawingId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentBuildSheet",
                table: "DocumentBuildSheet",
                columns: new[] { "DocumentId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractManufactureAssemblyDrawing",
                table: "ContractManufactureAssemblyDrawing",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractManufactureAssemblyDrawingBuildSheet",
                table: "ContractManufactureAssemblyDrawingBuildSheet",
                columns: new[] { "ContractManufactureAssemblyDrawingId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificationLabelRequirement",
                table: "CertificationLabelRequirement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificationLabelRequirementBuildSheet",
                table: "CertificationLabelRequirementBuildSheet",
                columns: new[] { "CertificationLabelRequirementId", "BuildSheetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseBoard",
                table: "BaseBoard",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseBoardBuildSheet",
                table: "BaseBoardBuildSheet",
                columns: new[] { "BaseBoardBuildSheetId", "BuildSheetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BaseBoardBuildSheet_BaseBoard_BaseBoardBuildSheetId",
                table: "BaseBoardBuildSheet",
                column: "BaseBoardBuildSheetId",
                principalTable: "BaseBoard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseBoardBuildSheet_BuildSheets_BuildSheetId",
                table: "BaseBoardBuildSheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationLabelRequirementBuildSheet_BuildSheets_BuildSheetId",
                table: "CertificationLabelRequirementBuildSheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationLabelRequirementBuildSheet_CertificationLabelRequirement_CertificationLabelRequirementId",
                table: "CertificationLabelRequirementBuildSheet",
                column: "CertificationLabelRequirementId",
                principalTable: "CertificationLabelRequirement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractManufactureAssemblyDrawingBuildSheet_BuildSheets_BuildSheetId",
                table: "ContractManufactureAssemblyDrawingBuildSheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractManufactureAssemblyDrawingBuildSheet_ContractManufactureAssemblyDrawing_ContractManufactureAssemblyDrawingId",
                table: "ContractManufactureAssemblyDrawingBuildSheet",
                column: "ContractManufactureAssemblyDrawingId",
                principalTable: "ContractManufactureAssemblyDrawing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentBuildSheet_BuildSheets_BuildSheetId",
                table: "DocumentBuildSheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentBuildSheet_Document_DocumentId",
                table: "DocumentBuildSheet",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeotabAssemblyDrawingBuildSheet_BuildSheets_BuildSheetId",
                table: "GeotabAssemblyDrawingBuildSheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeotabAssemblyDrawingBuildSheet_GeotabAssemblyDrawing_GeotabAssemblyDrawingId",
                table: "GeotabAssemblyDrawingBuildSheet",
                column: "GeotabAssemblyDrawingId",
                principalTable: "GeotabAssemblyDrawing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareBuildSheet_BuildSheets_BuildSheetId",
                table: "HardwareBuildSheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareBuildSheet_Hardware_HardwareId",
                table: "HardwareBuildSheet",
                column: "HardwareId",
                principalTable: "Hardware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_InternalSubAssemblyBoardBuildSheet_BuildSheets_BuildSheetId",
                table: "InternalSubAssemblyBoardBuildSheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalSubAssemblyBoardBuildSheet_InternalSubAssemblyBoard_InternalSubAssemblyBoardId",
                table: "InternalSubAssemblyBoardBuildSheet",
                column: "InternalSubAssemblyBoardId",
                principalTable: "InternalSubAssemblyBoard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabelBuildSheet_BuildSheets_BuildSheetId",
                table: "LabelBuildSheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabelBuildSheet_Label_LabelId",
                table: "LabelBuildSheet",
                column: "LabelId",
                principalTable: "Label",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackagingBuildSheet_BuildSheets_BuildSheetId",
                table: "PackagingBuildSheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackagingBuildSheet_Packaging_PackagingId",
                table: "PackagingBuildSheet",
                column: "PackagingId",
                principalTable: "Packaging",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubBoardBuildSheet_BuildSheets_BuildSheetId",
                table: "SubBoardBuildSheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubBoardBuildSheet_SubBoard_SubBoardBuildSheetId",
                table: "SubBoardBuildSheet",
                column: "SubBoardBuildSheetId",
                principalTable: "SubBoard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TesterSoftwareBuildsheet_BuildSheets_BuildSheetId",
                table: "TesterSoftwareBuildsheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TesterSoftwareBuildsheet_TesterSoftware_TesterSoftwareId",
                table: "TesterSoftwareBuildsheet",
                column: "TesterSoftwareId",
                principalTable: "TesterSoftware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInstructionBuildSheet_BuildSheets_BuildSheetId",
                table: "WorkInstructionBuildSheet",
                column: "BuildSheetId",
                principalTable: "BuildSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInstructionBuildSheet_WorkInstruction_WorkInstructionId",
                table: "WorkInstructionBuildSheet",
                column: "WorkInstructionId",
                principalTable: "WorkInstruction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
