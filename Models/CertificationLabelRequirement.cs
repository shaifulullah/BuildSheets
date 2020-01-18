using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class CertificationLabelRequirement
    {
        public int Id { get; set; }
        public int Side { get; set; }
        public string Description { get; set; }
        public string ModemId { get; set; }
        public virtual ICollection<CertificationLabelRequirementBuildSheet> CertificationLabelRequirementBuildSheets{ get; set; }
    }
    public class CertificationLabelRequirementBuildSheet
    {
        public int CertificationLabelRequirementId { get; set; }
        public CertificationLabelRequirement CertificationLabelRequirement { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
