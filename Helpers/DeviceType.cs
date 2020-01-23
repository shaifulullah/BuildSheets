using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Helpers
{
    public class DeviceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GetDeviceType
    {
        private List<DeviceType> _devices;
        public GetDeviceType()
        {
            _devices = new List<DeviceType>()
            {
                new DeviceType(){Id =1, Name = "GO7"},
                new DeviceType(){Id =2, Name = "GO8"},
                new DeviceType(){Id =3, Name = "GO9"}
            };
        }

        public IEnumerable<DeviceType> ListofDevices()
        {
            return _devices;
        }
    }

    public class ListOfDevices
    {
        public int Id { get; set; }
        public List<SelectListItem> Name { get; set; }
        public string attr { get; set; }
    }

    public class GetListOfDevices
    {
        private List<ListOfDevices> _devicesList;

        public GetListOfDevices()
        {
            SelectListGroup deviceGroup = new SelectListGroup() { Name = "Device Parameter" };
            List<SelectListItem> deviceItemList = Enum.GetValues(typeof(DeviceParametersName)).Cast<DeviceParametersName>()
                .Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = "DeviceParameters|" + v.ToString(),
                    //Value = ((int)v).ToString(),
                    Group = deviceGroup
                }).ToList();

            SelectListGroup firmGroup = new SelectListGroup() { Name = "Firmware Gates" };
            List<SelectListItem> firmItemList = Enum.GetValues(typeof(FirmwareGatesName)).Cast<FirmwareGatesName>()
                .Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = "FirmwareGates|" + v.ToString(),
                    //Value = ((int)v).ToString(),
                    Group = firmGroup
                }).ToList();

            SelectListGroup modemGroup = new SelectListGroup() { Name = "Modem Include" };
            List<SelectListItem> modemIncludeList = Enum.GetValues(typeof(ModemIncludeList)).Cast<ModemIncludeList>()
                .Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = "ModemIncludeList|"+v.ToString(),
                    //Value = ((int)v).ToString(),
                    Group = modemGroup
                }).ToList();

            SelectListGroup modemExcludeGroup = new SelectListGroup() { Name = "Modem Exclude" };
            List<SelectListItem> modemExcludeList = Enum.GetValues(typeof(ModemExcludeList)).Cast<ModemExcludeList>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = "ModemExcludeList|"+v.ToString(),
                //Value = ((int)v).ToString(),
                Group = modemExcludeGroup
            }).ToList();

            List<SelectListItem> GO7 = new List<SelectListItem>();
            GO7.AddRange(deviceItemList);
            GO7.AddRange(firmItemList);
            GO7.AddRange(modemExcludeList);

            List<SelectListItem> GO8 = new List<SelectListItem>();
            GO8.AddRange(deviceItemList);
            GO8.AddRange(firmItemList);
            GO8.AddRange(modemIncludeList);

            List<SelectListItem> GO9 = new List<SelectListItem>();
            GO9.AddRange(deviceItemList);
            GO9.AddRange(firmItemList);
            GO9.AddRange(modemIncludeList);

            _devicesList = new List<ListOfDevices>()
            {
                new ListOfDevices(){Id =1, Name = GO7, attr="GO7"},
                new ListOfDevices(){Id =2, Name = GO8, attr="GO8"},
                new ListOfDevices(){Id =3, Name = GO9, attr="GO9"}
            };
        }

        public IEnumerable<ListOfDevices> GetListofDevices()
        {
            return _devicesList;
        }
    }
}
