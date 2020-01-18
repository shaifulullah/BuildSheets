using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BuildSheets.Helpers
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName ="ProductCode")]
    public partial class TesterParameterCode
    {
        [XmlElement("DeviceParameters")]
        public RootParameters DeviceParameters { get; set; }

        [XmlElement("ModemIncludeList")]
        public RootParameters ModemIncludeList { get; set; }

        [XmlElement("ModemExcludeList")]
        public RootParameters ModemExcludeList { get; set; }

        [XmlElement("FirmwareGates")]
        public RootParameters FirmwareGates { get; set; }
    }
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class RootParameters
    {
        [XmlAnyElement]
        public XmlNode[] Parameters { get; set; }
    }
}
