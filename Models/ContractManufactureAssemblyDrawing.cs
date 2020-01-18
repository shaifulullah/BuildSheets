using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class ContractManufactureAssemblyDrawing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rev { get; set; }
        public string URL { get; set; }
        public virtual ICollection<ContractManufactureAssemblyDrawingBuildSheet> ContractManufactureAssemblyDrawingBuildSheets { get; set; }
    }
    public class ContractManufactureAssemblyDrawingBuildSheet
    {
        public int ContractManufactureAssemblyDrawingId { get; set; }
        public ContractManufactureAssemblyDrawing ContractManufactureAssemblyDrawing { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }

}
