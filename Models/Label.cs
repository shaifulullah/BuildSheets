using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class Label
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public int Rev { get; set; }
        public string Description { get; set; }
        public virtual ICollection<LabelBuildSheet> LabelBuildSheets { get; set; }
    }
    public class LabelBuildSheet
    {
        public int LabelId { get; set; }
        public Label Label{ get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
