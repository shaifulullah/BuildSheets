using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class GeotabAssemblyDrawing
    {
        public int Id { get; set; }
        public string  Name{ get; set; }
        public string Rev { get; set; }
        public string URL { get; set; }
        public virtual ICollection<GeotabAssemblyDrawingBuildSheet> GeotabAssemblyDrawingBuildSheets { get; set; }
    }
    public class GeotabAssemblyDrawingBuildSheet
    {
        public int GeotabAssemblyDrawingId { get; set; }
        public GeotabAssemblyDrawing GeotabAssemblyDrawing { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
