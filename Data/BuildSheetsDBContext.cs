using BuildSheets.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildSheets.Data
{
    public class BuildSheetsDBContext :DbContext
    {
        public DbSet<BuildSheet> BuildSheets { get; set; }
        public DbSet<TesterParameter> TesterParameters { get; set; }
        public BuildSheetsDBContext(DbContextOptions<BuildSheetsDBContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InternalSubAssemblyBoardBuildSheet>()
             .HasKey(bb => new { bb.InternalSubAssemblyBoardId, bb.BuildSheetId });
            modelBuilder.Entity<InternalSubAssemblyBoardBuildSheet>()
            .HasOne(bb => bb.InternalSubAssemblyBoard)
            .WithMany(b => b.InternalSubAssemblyBoardBuildSheets)
            .HasForeignKey(bb => bb.InternalSubAssemblyBoardId);
            modelBuilder.Entity<InternalSubAssemblyBoardBuildSheet>()
            .HasOne(bb => bb.BuildSheet)
            .WithMany(b => b.BuildSheetsInternalSubAssemblyBoard)
            .HasForeignKey(b => b.BuildSheetId); modelBuilder.Entity<BaseBoardBuildSheet>().HasKey(bb => new { bb.BaseBoardBuildSheetId, bb.BuildSheetId });
            modelBuilder.Entity<BaseBoardBuildSheet>().HasOne(bb => bb.BaseBoard).WithMany(b => b.BaseBoardBuildSheets).HasForeignKey(b => b.BaseBoardBuildSheetId);
            modelBuilder.Entity<BaseBoardBuildSheet>().HasOne(bb => bb.BuildSheet).WithMany(b => b.BaseBoards).HasForeignKey(b => b.BuildSheetId); modelBuilder.Entity<SubBoardBuildSheet>().HasKey(sb => new { sb.SubBoardBuildSheetId, sb.BuildSheetId });
            modelBuilder.Entity<SubBoardBuildSheet>().HasOne(sb => sb.SubBoard).WithMany(sb => sb.SubBoardBuildSheets).HasForeignKey(sb => sb.SubBoardBuildSheetId);
            modelBuilder.Entity<SubBoardBuildSheet>().HasOne(sb => sb.BuildSheet).WithMany(sb => sb.SubBoards).HasForeignKey(sb => sb.BuildSheetId); modelBuilder.Entity<HardwareBuildSheet>().HasKey(t => new { t.HardwareId, t.BuildSheetId });
            modelBuilder.Entity<HardwareBuildSheet>().HasOne(h => h.Hardware).WithMany(hr => hr.HardwareBuildSheets).HasForeignKey(h => h.HardwareId);
            modelBuilder.Entity<HardwareBuildSheet>().HasOne(b => b.BuildSheet).WithMany(b => b.OtherHardwares).HasForeignKey(b => b.BuildSheetId); modelBuilder.Entity<InsertBuildsheet>().HasKey(t => new { t.InsertId, t.BuildSheetId });
            modelBuilder.Entity<InsertBuildsheet>().HasOne(i => i.Insert).WithMany(i => i.InsertBuildSheets).HasForeignKey(i => i.InsertId);
            modelBuilder.Entity<InsertBuildsheet>().HasOne(i => i.BuildSheet).WithMany(i => i.Inserts).HasForeignKey(i => i.BuildSheetId); modelBuilder.Entity<LabelBuildSheet>().HasKey(t => new { t.LabelId, t.BuildSheetId });
            modelBuilder.Entity<LabelBuildSheet>().HasOne(lb => lb.Label).WithMany(lb => lb.LabelBuildSheets).HasForeignKey(lb => lb.LabelId);
            modelBuilder.Entity<LabelBuildSheet>().HasOne(lb => lb.BuildSheet).WithMany(lb => lb.Labels).HasForeignKey(lb => lb.BuildSheetId); modelBuilder.Entity<PackagingBuildSheet>().HasKey(t => new { t.PackagingId, t.BuildSheetId });
            modelBuilder.Entity<PackagingBuildSheet>().HasOne(p => p.Packaging).WithMany(p => p.PackagingBuildSheets).HasForeignKey(p => p.PackagingId);
            modelBuilder.Entity<PackagingBuildSheet>().HasOne(p => p.BuildSheet).WithMany(p => p.Packagings).HasForeignKey(p => p.BuildSheetId); modelBuilder.Entity<DocumentBuildSheet>().HasKey(t => new { t.DocumentId, t.BuildSheetId });
            modelBuilder.Entity<DocumentBuildSheet>().HasOne(dc => dc.Document).WithMany(dc => dc.DocumentBuildSheets).HasForeignKey(dc => dc.DocumentId);
            modelBuilder.Entity<DocumentBuildSheet>().HasOne(dc => dc.BuildSheet).WithMany(dc => dc.Documents).HasForeignKey(dc => dc.BuildSheetId); modelBuilder.Entity<WorkInstructionBuildSheet>().HasKey(t => new { t.WorkInstructionId, t.BuildSheetId });
            modelBuilder.Entity<WorkInstructionBuildSheet>().HasOne(w => w.WorkInstruction).WithMany(w => w.WorkInstructionBuildSheets).HasForeignKey(w => w.WorkInstructionId);
            modelBuilder.Entity<WorkInstructionBuildSheet>().HasOne(w => w.BuildSheet).WithMany(w => w.WorkInstructions).HasForeignKey(w => w.BuildSheetId); modelBuilder.Entity<GeotabAssemblyDrawingBuildSheet>().HasKey(t => new { t.GeotabAssemblyDrawingId, t.BuildSheetId });
            modelBuilder.Entity<GeotabAssemblyDrawingBuildSheet>().HasOne(g => g.GeotabAssemblyDrawing).WithMany(g => g.GeotabAssemblyDrawingBuildSheets).HasForeignKey(g => g.GeotabAssemblyDrawingId);
            modelBuilder.Entity<GeotabAssemblyDrawingBuildSheet>().HasOne(g => g.BuildSheet).WithMany(g => g.GeotabAssemblyDrawings).HasForeignKey(g => g.BuildSheetId); modelBuilder.Entity<ContractManufactureAssemblyDrawingBuildSheet>().HasKey(t => new { t.ContractManufactureAssemblyDrawingId, t.BuildSheetId });
            modelBuilder.Entity<ContractManufactureAssemblyDrawingBuildSheet>().HasOne(c => c.ContractManufactureAssemblyDrawing).WithMany(c => c.ContractManufactureAssemblyDrawingBuildSheets).HasForeignKey(c => c.ContractManufactureAssemblyDrawingId);
            modelBuilder.Entity<ContractManufactureAssemblyDrawingBuildSheet>().HasOne(c => c.BuildSheet).WithMany(c => c.ContractManufactureAssemblyDrawings).HasForeignKey(c => c.BuildSheetId); modelBuilder.Entity<TesterSoftwareBuildsheet>().HasKey(t => new { t.TesterSoftwareId, t.BuildSheetId });
            modelBuilder.Entity<TesterSoftwareBuildsheet>().HasOne(t => t.TesterSoftware).WithMany(t => t.TesterSoftwareBuildsheets).HasForeignKey(t => t.TesterSoftwareId);
            modelBuilder.Entity<TesterSoftwareBuildsheet>().HasOne(t => t.BuildSheet).WithMany(t => t.TesterSoftwares).HasForeignKey(t => t.BuildSheetId); modelBuilder.Entity<CertificationLabelRequirementBuildSheet>().HasKey(t => new { t.CertificationLabelRequirementId, t.BuildSheetId });
            modelBuilder.Entity<CertificationLabelRequirementBuildSheet>().HasOne(t => t.CertificationLabelRequirement).WithMany(t => t.CertificationLabelRequirementBuildSheets).HasForeignKey(t => t.CertificationLabelRequirementId);
            modelBuilder.Entity<CertificationLabelRequirementBuildSheet>().HasOne(t => t.BuildSheet).WithMany(t => t.CertificationLabelRequirements).HasForeignKey(t => t.BuildSheetId);
            modelBuilder.Entity<TesterParameter>(e =>
            {
                e.ToTable("TesterParameters");

                e.HasKey(x => x.Id);
                e.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                e.Ignore(x => x.TesterParameterCode);
            });
        }
        
    }
}
