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
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Product Owner")]
        public string ProductOwner { get; set; }
        [Display(Name = "Product Launch Date")]
        public DateTime ProductLaunchDate { get; set; }
        [Display(Name = "Provisioning Package")]
        public string ProvisioningPackage { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public string Revision { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime ProductUpdatedOn { get; set; }
        public int? ECOId { get; set; }
        public string APN { get; set; }
        public string CustomerGateway { get; set; }
        public string ProductImageURL { get; set; }        //one to many relationships:
        //public Product Product{ get; set; }
        //public DeviceFirmware DeviceFirmware { get; set; }
        //public Modem DeviceModem { get; set; }        //many to many relationships will have their linking table inside their own class.
        //all the linking tables were created.
        [Display(Name = "Internal Sub Assembly Boards", GroupName = "Hardware")]
        public virtual ICollection<InternalSubAssemblyBoardBuildSheet> BuildSheetsInternalSubAssemblyBoard { get; set; }
        [Display(Name = "Base Board", GroupName = "Hardware")]
        public virtual ICollection<BaseBoardBuildSheet> BaseBoards { get; set; }
        [Display(Name = "Sub Board 1", GroupName = "Hardware")]
        public virtual ICollection<SubBoardBuildSheet> SubBoards { get; set; }
        [Display(Name = "Other Hardware", GroupName = "Hardware")]
        public virtual ICollection<HardwareBuildSheet> OtherHardwares { get; set; }
        [Display(GroupName = "Hardware")]
        public virtual ICollection<InsertBuildsheet> Inserts { get; set; }
        [Display(GroupName = "Hardware")]
        public virtual ICollection<LabelBuildSheet> Labels { get; set; }
        [Display(Name = "Packaging", GroupName = "Hardware")]
        public virtual ICollection<PackagingBuildSheet> Packagings { get; set; }
        [Display(Name = "Support Document", GroupName = "Software")]
        public virtual ICollection<DocumentBuildSheet> Documents { get; set; }
        [Display(Name = "Work Instructions", GroupName = "Software")]
        public virtual ICollection<WorkInstructionBuildSheet> WorkInstructions { get; set; }
        [Display(Name = "Geotab Assembly Drawings", GroupName = "Software")]
        public virtual ICollection<GeotabAssemblyDrawingBuildSheet> GeotabAssemblyDrawings { get; set; }
        [Display(Name = "Contract Manufacture Assembly Drawings", GroupName = "Software")]
        public virtual ICollection<ContractManufactureAssemblyDrawingBuildSheet> ContractManufactureAssemblyDrawings { get; set; }
        [Display(Name = "Tester Software", GroupName = "Software")]
        public virtual ICollection<TesterSoftwareBuildsheet> TesterSoftwares { get; set; }
        [Display(Name = "Certification Label Requirements", GroupName = "Software")]
        public virtual ICollection<CertificationLabelRequirementBuildSheet> CertificationLabelRequirements { get; set; }
    }
    public enum ProductStatus
    {
        Preliminary,
        Release,
        Change
    }
}
