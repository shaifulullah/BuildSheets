using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class CertificationType
    {
        [Key]
        public int Id { get; set; }
        public string TypeofCertificate { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CertificationTypeBuildSheet> CertificationTypeBuildSheets { get; set; }
    }

    public class CertificationTypeBuildSheet
    {
        public int CertificationTypeId { get; set; }
        public CertificationType CertificationType { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
