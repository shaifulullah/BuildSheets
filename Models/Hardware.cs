using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class Hardware
    {
        [Key]
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Rev { get; set; }
        public string Description { get; set; }
        public virtual ICollection<HardwareBuildSheet> HardwareBuildSheets{ get; set; }
    }
    public class HardwareBuildSheet
    {
        public int HardwareId { get; set; }
        public Hardware Hardware{ get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
