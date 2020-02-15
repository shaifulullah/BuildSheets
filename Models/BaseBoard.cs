using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class BaseBoard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Revision Number"),Required]
        public string Rev { get; set; }
        public string URL { get; set; }
        public virtual ICollection<BaseBoardBuildSheet> BaseBoardBuildSheets { get; set; }
    }
    public class BaseBoardBuildSheet
    {
        public int BaseBoardBuildSheetId { get; set; }
        public BaseBoard BaseBoard { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
