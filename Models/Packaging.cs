using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class Packaging
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rev { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public virtual ICollection<PackagingBuildSheet> PackagingBuildSheets { get; set; }
    }
    public class PackagingBuildSheet
    {
        public int PackagingId { get; set; }
        public Packaging Packaging { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
        public string Quantity { get; set; }
    }
}
