using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class Modem
    {
        public string Id { get; set; }
        public string IMEIRange { get; set; }
        public string IMEIId { get; set; }
        public string HardwareVersion{ get; set; }
        public int HardwareRevision { get; set; }
        public string FirmwareVersion{ get; set; }
        public string FirmwareRevision{ get; set; }
        public int DefaultChannel { get; set; }
        public string FCC { get; set; }
        public string IC{ get; set; }
    }
}
