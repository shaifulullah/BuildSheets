using BuildSheets.Data;
using BuildSheets.Helpers;
using BuildSheets.Models;
using BuildSheets.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BuildSheets.Repository
{
    public class TesterParametersRepository : ITesterParameters
    {
        private BuildSheetsDBContext _context;
        private object xmlDocument;

        public TesterParametersRepository(BuildSheetsDBContext context)
        {
            _context = context;
        }

        public IEnumerable<TesterParameter> Main(string name)
        {
            List<TesterParameter> testerParameters = null;
            if (!string.IsNullOrWhiteSpace(name))
            {
                testerParameters = _context.TesterParameters.Where(x => x.DeviceName.ToLower().Contains(name.ToLower().Trim())).ToList();
            }
            return testerParameters;
        }

        public TesterParameter Details(string name)
        {
            TesterParameter testerParameter = null;

            testerParameter = _context.TesterParameters.FirstOrDefault(x => x.DeviceName.ToLower() == name.ToLower());
            if (testerParameter == null)
            {
                return testerParameter;
            }
            else
            {
                if (!string.IsNullOrEmpty(testerParameter.Parameter))
                {
                    var xmlSerializer = new XmlSerializer(typeof(TesterParameterCode));
                    testerParameter.TesterParameterCode = (TesterParameterCode)xmlSerializer.Deserialize(new StringReader(testerParameter.Parameter));
                }
                return testerParameter;
            }
        }
        public TesterParameter Create(AddTesterParameter model)
        {
            var deviceParameters = $"<{TesterParameterCodeType.DeviceParameters}>" +
                $"{string.Join("", model.DeviceParameters.Parameters.Where(x => !string.IsNullOrWhiteSpace(x.Key)).Select(x => $"<{x.Key}>{x.Value}</{x.Key}>"))}" +
                $"</{TesterParameterCodeType.DeviceParameters}>";

            var firmwareGatesParameters = $"<{TesterParameterCodeType.FirmwareGates}>" +
                $"{string.Join("", model.FirmwareGates.Parameters.Where(x => !string.IsNullOrWhiteSpace(x.Key)).Select(x => $"<{x.Key}>{x.Value}</{x.Key}>"))}" +
                $"</{TesterParameterCodeType.FirmwareGates}>";

            var modemIncludeList = $"<{TesterParameterCodeType.ModemIncludeList}>" +
                $"{string.Join("", model.ModemIncludeList.Parameters.Where(x => !string.IsNullOrWhiteSpace(x.Key)).Select(x => $"<{x.Key}>{x.Value}</{x.Key}>"))}" +
                $"</{TesterParameterCodeType.ModemIncludeList}>";

            var testerParameter = new TesterParameter
            {
                DeviceName = model.DeviceName,
                Parameter = $"<ProductCode>{deviceParameters}{firmwareGatesParameters}{modemIncludeList}</ProductCode>"
            };
            return testerParameter;
        }

        public TesterParameter Edit(string oldParameterName, string oldParameterValue, EditTesterParameter model)
        {
            var product = _context.TesterParameters.FirstOrDefault(x => x.Id == model.Id);
            product.Parameter = EditParameter(model.Type, product.Parameter,
                                            oldParameterName, oldParameterValue, model.ParameterName, model.ParameterValue, model.Index);
            return product;
        }

        public TesterParameter Add(EditTesterParameter model)
        {
            var newParameter = _context.TesterParameters.FirstOrDefault(x => x.Id == model.Id);
            newParameter.Parameter = AddParameter(model.Type, newParameter.Parameter,
                model.ParameterName, model.ParameterValue);

            return newParameter;
        }

        public TesterParameter Delete(EditTesterParameter model)
        {
            var device = _context.TesterParameters.Find(model.Id);
            if (device != null)
            {
                device.Parameter = RemoveParameter(model.Type, device.Parameter, model.ParameterName, model.ParameterValue, model.Index);
            }
            _context.SaveChangesAsync();
            return device;
        }

        private string EditParameter(TesterParameterCodeType type, string sourceXml, string oldParameterName,
                string oldParameterValue, string newParameterName, string parameterValue, int Index)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(sourceXml);

            var parameterNode = xmlDocument.SelectNodes($"//ProductCode/{type}/{oldParameterName}");
            if (parameterNode == null) return sourceXml;

            foreach (XmlElement node in parameterNode)
            {
                if (node.InnerText == oldParameterValue)
                {
                    node.InnerText = parameterValue;
                }
            }
            var stringWriter = new StringWriter();
            xmlDocument.Save(stringWriter);

            return stringWriter.ToString();
        }
       

        private string AddParameter(TesterParameterCodeType type, string sourceXml, string parameterName, string parameterValue)
        {
            if (string.IsNullOrWhiteSpace(sourceXml))
            {
                sourceXml = $"<ProductCode><{type}></{type}></ProductCode>";
            }

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(sourceXml);
            var deviceParametersNode = xmlDocument.SelectSingleNode($"//ProductCode/{type}");

            if (deviceParametersNode == null)
            {
                var rootNode = xmlDocument.SelectSingleNode($"//ProductCode");
                deviceParametersNode = xmlDocument.CreateElement(type.ToString());
                rootNode.AppendChild(deviceParametersNode);
            }

            var newParameter = xmlDocument.CreateElement(parameterName);
            newParameter.InnerText = parameterValue;
            deviceParametersNode.AppendChild(newParameter);

            var stringWriter = new StringWriter();
            xmlDocument.Save(stringWriter);
            return stringWriter.ToString();
        }
        private string RemoveParameter(TesterParameterCodeType type, string sourceXml, string parameterName, string parameterValue, int index)
        {
            XDocument doc = XDocument.Parse(sourceXml); // or XDocument.Parse(string)
            doc.Root.Descendants().Where(e => e.Name == parameterName && e.Value == parameterValue).Remove();
            var stringWriter = new StringWriter();
            doc.Save(stringWriter);
            return stringWriter.ToString();
        }

        public IEnumerable<TesterParameter> GetAll()
        {
            List<TesterParameter> testerParameters = null;

            testerParameters = _context.TesterParameters.ToList();

            return testerParameters;
        }
    }
}
