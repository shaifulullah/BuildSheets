using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class DeviceFirmware
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public int ProductId { get; set; }
    }
}
