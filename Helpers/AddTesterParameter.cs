using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Helpers
{
    public class AddTesterParameter
    {
        [Required(ErrorMessage = "Please enter the device name.")]
        public string DeviceName { get; set; }

        public AddProductDeviceParameters DeviceParameters { get; set; }

        public AddProductModemIncludeList ModemIncludeList { get; set; }

        public AddProductFirmwareGates FirmwareGates { get; set; }
    }
    public class AddProductDeviceParameters
    {
        public KeyValuePair<string, string>[] Parameters { get; set; }
    }

    public class AddProductModemIncludeList
    {
        public KeyValuePair<string, string>[] Parameters { get; set; }
    }

    public class AddProductFirmwareGates
    {
        public KeyValuePair<string, string>[] Parameters { get; set; }
    }
}
