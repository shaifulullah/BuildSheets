using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class SubBoard
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rev { get; set; }
        public string URL { get; set; }
        public virtual ICollection<SubBoardBuildSheet> SubBoardBuildSheets { get; set; }
    }

    public class SubBoardBuildSheet
    {
        public int SubBoardBuildSheetId { get; set; }
        public SubBoard SubBoard { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
