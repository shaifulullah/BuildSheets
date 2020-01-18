using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int Rev { get; set; }
        public DateTime RevDate { get; set; }
        public virtual ICollection<DocumentBuildSheet> DocumentBuildSheets { get; set; }
    }
    public class DocumentBuildSheet
    {
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public int BuildSheetId { get; set; }
        public BuildSheet BuildSheet { get; set; }
    }
}
