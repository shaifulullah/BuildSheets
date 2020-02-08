using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class CertificationLabelRequirement
    {
        public int Id { get; set; }
        public string SideA { get; set; }
        public string SideADescription { get; set; }
        public string SideAURL { get; set; }
        public string SideB { get; set; }
        public string SideBDescription { get; set; }
        public string SideBURL { get; set; }
        public virtual ICollection<CertificationLabelRequirementBuildSheet> CertificationLabelRequirementBuildSheets { get; set; }
    }
    public class CertificationLabelRequirementBuildSheet
    {
        public int CertificationLabelRequirementId { get; set; }
        public CertificationLabelRequirement CertificationLabelRequirement { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
