using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class Insert
    {
        [Key]
        public int Id { get; set; }
        public string Rev { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public virtual ICollection<InsertBuildsheet> InsertBuildSheets { get; set; }
    }
    public class InsertBuildsheet
    {
        public int InsertId { get; set; }
        public Insert Insert { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
