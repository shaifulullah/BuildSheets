﻿// <auto-generated />
using System;
using BuildSheets.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuildSheets.Migrations
{
    [DbContext(typeof(BuildSheetsDBContext))]
    [Migration("20200129023943_ModifiedFewTable")]
    partial class ModifiedFewTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BuildSheets.Models.BaseBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Rev");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.ToTable("BaseBoards");
                });

            modelBuilder.Entity("BuildSheets.Models.BaseBoardBuildSheet", b =>
                {
                    b.Property<int>("BaseBoardBuildSheetId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("BaseBoardBuildSheetId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("BaseBoardBuildSheets");
                });

            modelBuilder.Entity("BuildSheets.Models.BuildSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("APN");

                    b.Property<string>("CustomerGateway");

                    b.Property<string>("Description");

                    b.Property<int?>("ECOId");

                    b.Property<string>("ProductImageURL");

                    b.Property<DateTime>("ProductLaunchDate");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<string>("ProductOwner");

                    b.Property<int>("ProductStatus");

                    b.Property<DateTime>("ProductUpdatedOn");

                    b.Property<string>("ProvisioningPackage");

                    b.Property<string>("Revision");

                    b.Property<string>("RevisionURL");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("BuildSheets");
                });

            modelBuilder.Entity("BuildSheets.Models.CertificationLabelRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FCC");

                    b.Property<string>("IC");

                    b.Property<string>("SideA");

                    b.Property<string>("SideADescription");

                    b.Property<string>("SideAURL");

                    b.Property<string>("SideB");

                    b.Property<string>("SideBDescription");

                    b.Property<string>("SideBURL");

                    b.HasKey("Id");

                    b.ToTable("CertificationLabelRequirements");
                });

            modelBuilder.Entity("BuildSheets.Models.CertificationLabelRequirementBuildSheet", b =>
                {
                    b.Property<int>("CertificationLabelRequirementId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("CertificationLabelRequirementId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("CertificationLabelRequirementBuildSheets");
                });

            modelBuilder.Entity("BuildSheets.Models.ContractManufactureAssemblyDrawing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Rev");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.ToTable("ContractManufactureAssemblyDrawings");
                });

            modelBuilder.Entity("BuildSheets.Models.ContractManufactureAssemblyDrawingBuildSheet", b =>
                {
                    b.Property<int>("ContractManufactureAssemblyDrawingId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("ContractManufactureAssemblyDrawingId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("ContractManufactureAssemblyDrawingBuildSheets");
                });

            modelBuilder.Entity("BuildSheets.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Rev");

                    b.Property<DateTime>("RevDate");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("BuildSheets.Models.DocumentBuildSheet", b =>
                {
                    b.Property<int>("DocumentId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("DocumentId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("DocumentBuildSheets");
                });

            modelBuilder.Entity("BuildSheets.Models.GeotabAssemblyDrawing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Rev");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.ToTable("GeotabAssemblyDrawings");
                });

            modelBuilder.Entity("BuildSheets.Models.GeotabAssemblyDrawingBuildSheet", b =>
                {
                    b.Property<int>("GeotabAssemblyDrawingId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("GeotabAssemblyDrawingId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("GeotabAssemblyDrawingBuildSheets");
                });

            modelBuilder.Entity("BuildSheets.Models.Hardware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Rev");

                    b.HasKey("Id");

                    b.ToTable("Hardwares");
                });

            modelBuilder.Entity("BuildSheets.Models.HardwareBuildSheet", b =>
                {
                    b.Property<int>("HardwareId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("HardwareId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("HardwareBuildSheets");
                });

            modelBuilder.Entity("BuildSheets.Models.Insert", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Rev");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.ToTable("Inserts");
                });

            modelBuilder.Entity("BuildSheets.Models.InsertBuildsheet", b =>
                {
                    b.Property<string>("InsertId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("InsertId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("InsertBuildsheets");
                });

            modelBuilder.Entity("BuildSheets.Models.InternalSubAssemblyBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Rev");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.ToTable("InternalSubAssemblyBoards");
                });

            modelBuilder.Entity("BuildSheets.Models.InternalSubAssemblyBoardBuildSheet", b =>
                {
                    b.Property<int>("InternalSubAssemblyBoardId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("InternalSubAssemblyBoardId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("InternalSubAssemblyBoardBuildSheets");
                });

            modelBuilder.Entity("BuildSheets.Models.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Rev");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("BuildSheets.Models.LabelBuildSheet", b =>
                {
                    b.Property<int>("LabelId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("LabelId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("LabelBuildSheets");
                });

            modelBuilder.Entity("BuildSheets.Models.Packaging", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Rev");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.ToTable("Packagings");
                });

            modelBuilder.Entity("BuildSheets.Models.PackagingBuildSheet", b =>
                {
                    b.Property<int>("PackagingId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("PackagingId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("PackagingBuildSheets");
                });

            modelBuilder.Entity("BuildSheets.Models.SubBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Rev");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.ToTable("SubBoards");
                });

            modelBuilder.Entity("BuildSheets.Models.SubBoardBuildSheet", b =>
                {
                    b.Property<int>("SubBoardBuildSheetId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("SubBoardBuildSheetId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("SubBoardBuildSheets");
                });

            modelBuilder.Entity("BuildSheets.Models.TesterParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeviceName");

                    b.Property<string>("Parameter")
                        .HasColumnType("varchar(MAX)");

                    b.HasKey("Id");

                    b.ToTable("TesterParameters");
                });

            modelBuilder.Entity("BuildSheets.Models.TesterSoftware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductCode");

                    b.Property<string>("ProductCodeURL");

                    b.Property<string>("TesterVersion");

                    b.Property<string>("TesterVersionURL");

                    b.HasKey("Id");

                    b.ToTable("TesterSoftwares");
                });

            modelBuilder.Entity("BuildSheets.Models.TesterSoftwareBuildsheet", b =>
                {
                    b.Property<int>("TesterSoftwareId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("TesterSoftwareId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("TesterSoftwareBuildsheets");
                });

            modelBuilder.Entity("BuildSheets.Models.WorkInstruction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Rev");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.ToTable("WorkInstructions");
                });

            modelBuilder.Entity("BuildSheets.Models.WorkInstructionBuildSheet", b =>
                {
                    b.Property<int>("WorkInstructionId");

                    b.Property<int>("BuildSheetId");

                    b.HasKey("WorkInstructionId", "BuildSheetId");

                    b.HasIndex("BuildSheetId");

                    b.ToTable("WorkInstructionBuildSheets");
                });

            modelBuilder.Entity("BuildSheets.Models.BaseBoardBuildSheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BaseBoard", "BaseBoard")
                        .WithMany("BaseBoardBuildSheets")
                        .HasForeignKey("BaseBoardBuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("BaseBoards")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuildSheets.Models.CertificationLabelRequirementBuildSheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("CertificationLabelRequirements")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.CertificationLabelRequirement", "CertificationLabelRequirement")
                        .WithMany("CertificationLabelRequirementBuildSheets")
                        .HasForeignKey("CertificationLabelRequirementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuildSheets.Models.ContractManufactureAssemblyDrawingBuildSheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("ContractManufactureAssemblyDrawings")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.ContractManufactureAssemblyDrawing", "ContractManufactureAssemblyDrawing")
                        .WithMany("ContractManufactureAssemblyDrawingBuildSheets")
                        .HasForeignKey("ContractManufactureAssemblyDrawingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuildSheets.Models.DocumentBuildSheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("Documents")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.Document", "Document")
                        .WithMany("DocumentBuildSheets")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuildSheets.Models.GeotabAssemblyDrawingBuildSheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("GeotabAssemblyDrawings")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.GeotabAssemblyDrawing", "GeotabAssemblyDrawing")
                        .WithMany("GeotabAssemblyDrawingBuildSheets")
                        .HasForeignKey("GeotabAssemblyDrawingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuildSheets.Models.HardwareBuildSheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("OtherHardwares")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.Hardware", "Hardware")
                        .WithMany("HardwareBuildSheets")
                        .HasForeignKey("HardwareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuildSheets.Models.InsertBuildsheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("Inserts")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.Insert", "Insert")
                        .WithMany("InsertBuildSheets")
                        .HasForeignKey("InsertId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuildSheets.Models.InternalSubAssemblyBoardBuildSheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("BuildSheetsInternalSubAssemblyBoard")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.InternalSubAssemblyBoard", "InternalSubAssemblyBoard")
                        .WithMany("InternalSubAssemblyBoardBuildSheets")
                        .HasForeignKey("InternalSubAssemblyBoardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuildSheets.Models.LabelBuildSheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("Labels")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.Label", "Label")
                        .WithMany("LabelBuildSheets")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuildSheets.Models.PackagingBuildSheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("Packagings")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.Packaging", "Packaging")
                        .WithMany("PackagingBuildSheets")
                        .HasForeignKey("PackagingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuildSheets.Models.SubBoardBuildSheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("SubBoards")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.SubBoard", "SubBoard")
                        .WithMany("SubBoardBuildSheets")
                        .HasForeignKey("SubBoardBuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuildSheets.Models.TesterSoftwareBuildsheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("TesterSoftwares")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.TesterSoftware", "TesterSoftware")
                        .WithMany("TesterSoftwareBuildsheets")
                        .HasForeignKey("TesterSoftwareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuildSheets.Models.WorkInstructionBuildSheet", b =>
                {
                    b.HasOne("BuildSheets.Models.BuildSheet", "BuildSheet")
                        .WithMany("WorkInstructions")
                        .HasForeignKey("BuildSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuildSheets.Models.WorkInstruction", "WorkInstruction")
                        .WithMany("WorkInstructionBuildSheets")
                        .HasForeignKey("WorkInstructionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
