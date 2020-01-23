using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class InternalSubAssemblyBoard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rev { get; set; }
        public string URL { get; set; }
        public virtual ICollection<InternalSubAssemblyBoardBuildSheet> InternalSubAssemblyBoardBuildSheets { get; set; }
    }
    public class InternalSubAssemblyBoardBuildSheet
    {
        public int InternalSubAssemblyBoardId { get; set; }
        public InternalSubAssemblyBoard InternalSubAssemblyBoard { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
