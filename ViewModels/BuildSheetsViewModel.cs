using BuildSheets.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.ViewModels
{
    public class BuildSheetsViewModel
    {
        public BuildSheetsViewModel()
        { }
        public BuildSheetsViewModel(Models.BuildSheet bs)
        {
            Id = bs.Id;
            ProductName = bs.ProductName;
            Description = bs.Description;
            ProductOwner = bs.ProductOwner;
            ProductLaunchDate = bs.ProductLaunchDate;
            ProvisioningPackage = bs.ProvisioningPackage;
            ProductStatus = bs.ProductStatus;
            Revision = bs.Revision;
            RevisionURL = bs.RevisionURL;
            UpdatedBy = bs.UpdatedBy;
            ProductUpdatedOn = bs.ProductUpdatedOn;
            ECOId = bs.ECOId;
            APN = bs.APN;
            CustomerGateway = bs.CustomerGateway;
            ProductImageURL = bs.ProductImageURL;
        }
        public int Id { get; set; }
        [Display(Name = "Product Name"), Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Product Owner")]
        public string ProductOwner { get; set; }
        [Display(Name = "Product Launch Date")]
        public DateTime ProductLaunchDate { get; set; } = DateTime.Now.AddDays(1);
        [Display(Name = "Provisioning Package")]
        public string ProvisioningPackage { get; set; }
        [Display(Name = "Product Status")]
        public ProductStatus ProductStatus { get; set; }
        public string Revision { get; set; }
        [Display(Name = "Revision URL")]
        public string RevisionURL { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime ProductUpdatedOn { get; set; } = DateTime.Now;
        [Display(Name = "ECO Id")]
        public int? ECOId { get; set; }
        public string APN { get; set; }
        [Display(Name = "Customer Gateway")]
        public string CustomerGateway { get; set; }
        [Display(Name = "Product Image Link")]
        public string ProductImageURL { get; set; }
        [Display(Name = "Internal Sub Assembly Board")]
        public SelectList InternalSubAssemblyBoardList { get; set; }
        public List<int> InternalSubAssemblyBoardId { get; set; }
        public virtual ICollection<InternalSubAssemblyBoardBuildSheet> BuildSheetsInternalSubAssemblyBoard { get; set; }
        [Display(Name = "Base Board", GroupName = "Hardware")]
        public SelectList BaseBoardList { get; set; }
        public List<int> BaseBoardId { get; set; }
        public virtual ICollection<BaseBoardBuildSheet> BaseBoards { get; set; }
        [Display(Name = "Sub Board 1", GroupName = "Hardware")]
        public SelectList SubBoardList { get; set; }
        public List<int> SubBoardId { get; set; }
        public virtual ICollection<SubBoardBuildSheet> SubBoards { get; set; }
        [Display(Name = "Other Hardware", GroupName = "Hardware")]
        public SelectList OtherHardwareList { get; set; }
        public List<int> OtherHardwareIds { get; set; }
        public virtual ICollection<HardwareBuildSheet> OtherHardwares { get; set; }
        [Display(Name = "Inserts", GroupName = "Hardware")]
        public SelectList InsertList { get; set; }
        public List<int> InsertIds { get; set; }
        public virtual ICollection<InsertBuildsheet> Inserts { get; set; }
        [Display(Name = "Labels", GroupName = "Hardware")]
        public SelectList LabelList { get; set; }
        public List<int> LabelIds { get; set; }
        public virtual ICollection<LabelBuildSheet> Labels { get; set; }
        [Display(Name = "Packaging", GroupName = "Hardware")]
        public SelectList PackagingList { get; set; }
        public List<int> PackagingIds { get; set; }
        public virtual ICollection<PackagingBuildSheet> Packagings { get; set; }
        [Display(Name = "Support Document", GroupName = "Software")]
        public SelectList DocumentList { get; set; }
        public List<int> DocumentIds { get; set; }
        public virtual ICollection<DocumentBuildSheet> Documents { get; set; }
        [Display(Name = "Work Instructions", GroupName = "Software")]
        public SelectList WorkInstructionList { get; set; }
        public List<int> WorkInstructionIds { get; set; }
        public virtual ICollection<WorkInstructionBuildSheet> WorkInstructions { get; set; }
        [Display(Name = "Geotab Assembly Drawings", GroupName = "Software")]
        public SelectList GeotabAssemblyDrawingList { get; set; }
        public List<int> GeotabAssemblyDrawingIds { get; set; }
        public virtual ICollection<GeotabAssemblyDrawingBuildSheet> GeotabAssemblyDrawings { get; set; }
        [Display(Name = "Contract Manufacture Assembly Drawings", GroupName = "Software")]
        public SelectList ContractManufactureAssemblyDrawingList { get; set; }
        public List<int> ContractManufactureAssemblyDrawingIds { get; set; }
        public virtual ICollection<ContractManufactureAssemblyDrawingBuildSheet> ContractManufactureAssemblyDrawings { get; set; }
        [Display(Name = "Tester Software", GroupName = "Software")]
        public SelectList TesterSoftwareList { get; set; }
        public List<int> TesterSoftwareIds { get; set; }
        public virtual ICollection<TesterSoftwareBuildsheet> TesterSoftwares { get; set; }
        [Display(Name = "Certification Label Requirements", GroupName = "Software")]
        public SelectList CertificationLabelRequirementList { get; set; }
        public List<int> CertificationLabelRequirementIds { get; set; }
        public virtual ICollection<CertificationLabelRequirementBuildSheet> CertificationLabelRequirements { get; set; }
    }
}
