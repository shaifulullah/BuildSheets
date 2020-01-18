using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class BuildSheet
    {
        //BuildSheets Attributes
        [Key]
        public int Id { get; set; }
        public string APN { get; set; }
        public string CustomerGateway { get; set; }

        //one to many relationships:
        public DeviceFirmware DeviceFirmware { get; set; }
        public Modem DeviceModem { get; set; }

        //many to many relationships will have their linking table inside their own class.
        //all the linking tables were created.
        [Display(Name = "Internal Sub Assembly Boards", GroupName = "Hardware")]
        public virtual ICollection<BoardBuildSheet> InternalSubAssemblyBoards { get; set; }

        [Display(Name ="Other Hardware", GroupName = "Hardware")]
        public virtual ICollection<HardwareBuildSheet> OtherHardware { get; set; }

        [Display(GroupName = "Hardware")] 
        public virtual ICollection<InsertBuildSheet> Inserts { get; set; }

        [Display(GroupName = "Hardware")]
        public virtual ICollection<LabelBuildSheet> Labels { get; set; }

        [Display(Name = "Packaging", GroupName = "Hardware")]
        public virtual ICollection<PackagingBuildSheet> Packagings { get; set; }

        [Display(Name = "Support Document", GroupName = "Software")]
        public virtual ICollection<DocumentBuildSheet> Documents{ get; set; }

        [Display(Name = "Work Instructions", GroupName = "Software")]
        public virtual ICollection<WorkInstructionBuildSheet> WorkInstructions{ get; set; }

        [Display(Name = "Geotab Assembly Drawings", GroupName = "Software")]
        public virtual ICollection<GeotabAssemblyDrawingBuildSheet> GeotabAssemblyDrawings{ get; set; }

        [Display(Name = "Contract Manufacture Assembly Drawings", GroupName = "Software")]
        public virtual ICollection<ContractManufactureAssemblyDrawingBuildSheet> ContractManufactureAssemblyDrawings{ get; set; }

        [Display(Name = "Tester Software", GroupName = "Software")]
        public virtual ICollection<TesterSoftwareBuildsheet> TesterSoftwares{ get; set; }

        [Display(Name = "Certification Label Requirements", GroupName = "Software")]
        public virtual ICollection<CertificationLabelRequirementBuildSheet> CertificationLabelRequirements{ get; set; }
        
    }
}
