using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Helpers
{
    public enum DeviceCategory
    {
        GO7,
        GO8,
        GO9
    }
    public enum DeviceParametersName
    {
        P65,
        HWVersion,
        Imeigate
    }
    public enum FirmwareGatesName
    {
        Firmware,
        FirmwareVersion
    }
    public enum ModemIncludeList
    {
        Modem,
        ModemFirmware
    }

    public enum ModemExcludeList
    {
        Modem
    }
}
