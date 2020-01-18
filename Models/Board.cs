using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rev{ get; set; }
        public virtual ICollection<BoardBuildSheet> BoardBuildSheets { get; set; }
    }
    public class BoardBuildSheet
    {
        public int BoardId{ get; set; }
        public Board Board{ get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
