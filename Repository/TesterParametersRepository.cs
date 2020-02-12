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

        public TesterParameter Details(string name, int revision)
        {
            TesterParameter testerParameter = null;

            testerParameter = _context.TesterParameters.FirstOrDefault(x => x.DeviceName.ToLower() == name.ToLower() && x.Revision == revision);
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
                Parameter = $"<ProductCode>{deviceParameters}{firmwareGatesParameters}{modemIncludeList}</ProductCode>",
                Revision = 1
            };
            return testerParameter;
        }

        public TesterParameter Edit(string oldParameterName, string oldParameterValue, EditTesterParameter model)
        {
            var product = _context.TesterParameters.FirstOrDefault(x => x.Id == model.Id && x.Revision == model.Revision);

            //product.Parameter = EditParameter(model.Type, product.Parameter,
            //                oldParameterName, oldParameterValue, model.ParameterName, 
            //                model.ParameterValue/*, model.Index*/);
            var parameter = EditParameter(model.Type, product.Parameter,
                            oldParameterName, oldParameterValue, model.ParameterName,
                            model.ParameterValue);
            TesterParameter testerParameter = new TesterParameter()
            {
                DeviceName = product.DeviceName,
                Parameter = parameter,
                Revision = model.Revision + 1
            };
            return testerParameter;
        }

        public TesterParameter Add(EditTesterParameter model)
        {
            var newParameter = _context.TesterParameters.FirstOrDefault(x => x.Id == model.Id && x.Revision == model.Revision);
            //newParameter.Parameter = AddParameter(model.Type, newParameter.Parameter,
            //    model.ParameterName, model.ParameterValue);
            var parameter = AddParameter(model.Type, newParameter.Parameter,
                model.ParameterName, model.ParameterValue);

            TesterParameter testerParameter = new TesterParameter()
            {
                DeviceName = newParameter.DeviceName,
                Parameter = parameter,
                Revision = model.Revision + 1
            };

            return testerParameter;
        }

        public TesterParameter Delete(EditTesterParameter model)
        {
            var device = _context.TesterParameters.FirstOrDefault(x => x.Id == model.Id && x.Revision == model.Revision);
            if (device != null)
            {
                var parameter = RemoveParameter(model.Type, device.Parameter, model.ParameterName, model.ParameterValue);
                //device.Parameter = RemoveParameter(model.Type, device.Parameter, model.ParameterName, model.ParameterValue/*, model.Index*/);
                TesterParameter testerParameter = new TesterParameter()
                {
                    DeviceName = device.DeviceName,
                    Parameter = parameter,
                    Revision = model.Revision + 1
                };
                _context.TesterParameters.Add(testerParameter);
                _context.SaveChangesAsync();
                return testerParameter;
            }
            return device;
        }
        private string EditParameter(TesterParameterCodeType type, string sourceXml,
            string oldParameterName, string oldParameterValue, string newParameterName,
            string parameterValue/*, int index*/)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(sourceXml);

            var parameterNode = xmlDocument.GetElementsByTagName(oldParameterName);
            //var parameterNode = xmlDocument.SelectNodes($"//ProductCode/{type}/{oldParameterName}");
            if (parameterNode == null) return sourceXml;

            foreach (XmlNode node in parameterNode)
            {
                if (string.IsNullOrEmpty(oldParameterValue))
                {
                    node.InnerText = parameterValue;
                }
                else if (node.InnerText == oldParameterValue)
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

        private string RemoveParameter(TesterParameterCodeType type, string sourceXml, string parameterName, string parameterValue/*, int index*/)
        {
            XDocument doc = XDocument.Parse(sourceXml); // or XDocument.Parse(string)
            doc.Root.Descendants().Where(e => e.Name == parameterName && e.Value == parameterValue).Remove();

            //var xmlDocument = new XmlDocument();
            //xmlDocument.LoadXml(sourceXml);

            //var output = xmlDocument.GetElementsByTagName(parameterName);
            //var parameterNode = xmlDocument.SelectNodes($"//ProductCode/{type}/{parameterName}");
            //if (parameterNode == null) return sourceXml;

            //foreach (XmlNode node in output)
            //{
            //    if (node.InnerText == parameterValue)
            //    {
            //        //node.RemoveChild();
            //    }
            //}
            //parameterNode[index].ParentNode.RemoveChild(parameterNode[index]);

            var stringWriter = new StringWriter();
            doc.Save(stringWriter);
            return stringWriter.ToString();
        }
        #region Old
        //private string RemoveParameter(TesterParameterCodeType type, string sourceXml, string parameterName, string parameterValue, int index)
        //{
        //    XDocument doc = XDocument.Parse(sourceXml); // or XDocument.Parse(string)
        //    doc.Root.Descendants().Where(e => e.Name == parameterName && e.Value == parameterValue).Remove();

        //    //var xmlDocument = new XmlDocument();
        //    //xmlDocument.LoadXml(sourceXml);

        //    //var output = xmlDocument.GetElementsByTagName(parameterName);
        //    //var parameterNode = xmlDocument.SelectNodes($"//ProductCode/{type}/{parameterName}");
        //    //if (parameterNode == null) return sourceXml;

        //    //foreach (XmlNode node in output)
        //    //{
        //    //    if (node.InnerText == parameterValue)
        //    //    {
        //    //        //node.RemoveChild();
        //    //    }
        //    //}
        //    //parameterNode[index].ParentNode.RemoveChild(parameterNode[index]);

        //    var stringWriter = new StringWriter();
        //    doc.Save(stringWriter);
        //    return stringWriter.ToString();
        //}
        #endregion

        public IEnumerable<TesterParameter> GetAll()
        {
            List<TesterParameter> testerParameters = null;

            testerParameters = _context.TesterParameters.ToList();

            return testerParameters;
        }
    }
}
