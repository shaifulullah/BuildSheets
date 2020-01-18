using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class TesterSoftware
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductCodeURL { get; set; }
        public string TesterVersion { get; set; }
        public string TesterVersionURL { get; set; }
        public virtual ICollection<TesterSoftwareBuildsheet> TesterSoftwareBuildsheets{ get; set; }
    }
    public class TesterSoftwareBuildsheet
    {
        public int TesterSoftwareId { get; set; }
        public TesterSoftware TesterSoftware { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
