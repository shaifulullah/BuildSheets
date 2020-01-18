using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class WorkInstruction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rev { get; set; }
        public string URL { get; set; }
        public Location LocationId { get; set; }
        public virtual ICollection<WorkInstructionBuildSheet> WorkInstructionBuildSheets { get; set; }

    }
    public enum Location
    {
        Canada = 0,
        China = 1
    }
    public class WorkInstructionBuildSheet
    {
        public int WorkInstructionId{ get; set; }
        public WorkInstruction  WorkInstruction { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
