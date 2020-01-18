using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using BuildSheets.Data;
using BuildSheets.Helpers;
using BuildSheets.Models;
using BuildSheets.Repository;
using BuildSheets.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BuildSheets.Controllers
{
    public class TesterParametersController : Controller
    {
        private readonly BuildSheetsDBContext _context;
        private readonly ITesterParameters testerParametersRepository;
        public TesterParametersController(BuildSheetsDBContext context, ITesterParameters testerParameters)
        {
            _context = context;
            testerParametersRepository = testerParameters;
        }
        public IActionResult Main(string name)
        {
            var testerParameter = testerParametersRepository.Main(name);
            if (!string.IsNullOrWhiteSpace(name) && testerParameter == null)
            {
                ViewBag.ErrorMessage = "No Result found";
                return View(testerParameter);
            }
            else
            {
                ViewBag.SearchString = name;
                return View(testerParameter);
            }
        }

        public IActionResult Details(string name)
        {
            var DetailTesterParameter = testerParametersRepository.Details(name);

            return View(DetailTesterParameter);
        }
        public IActionResult Create()
        {
            var dropDownListForDeviceParam = new List<SelectListItem>();
            var dropDownListForFirmwareGates = new List<SelectListItem>();
            var dropDownListForModemInclude = new List<SelectListItem>();

            dropDownListForDeviceParam.Add(new SelectListItem
            {
                Text = "Please Select",
                Value = ""
            });
            dropDownListForFirmwareGates.Add(new SelectListItem
            {
                Text = "Please Select",
                Value = ""
            });
            dropDownListForModemInclude.Add(new SelectListItem
            {
                Text = "Please Select",
                Value = ""
            });
            foreach (DeviceParametersName paramName in Enum.GetValues(typeof(DeviceParametersName)))
            {
                dropDownListForDeviceParam.Add(new SelectListItem
                {
                    Text = Enum.GetName(typeof(DeviceParametersName), paramName),
                    Value = paramName.ToString()
                });
            }
            foreach (FirmwareGatesName paramName in Enum.GetValues(typeof(FirmwareGatesName)))
            {
                dropDownListForFirmwareGates.Add(new SelectListItem
                {
                    Text = Enum.GetName(typeof(FirmwareGatesName), paramName),
                    Value = paramName.ToString()
                });
            }
            foreach (ModemIncludeList paramName in Enum.GetValues(typeof(ModemIncludeList)))
            {
                dropDownListForModemInclude.Add(new SelectListItem
                {
                    Text = Enum.GetName(typeof(ModemIncludeList), paramName),
                    Value = paramName.ToString()
                });
            }
            ViewBag.DeviceParameterName = dropDownListForDeviceParam;
            ViewBag.FirmwareGatesName = dropDownListForFirmwareGates;
            ViewBag.ModemIncludeList = dropDownListForModemInclude;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddTesterParameter model)
        {
            if (ModelState.IsValid)
            {
                var isDeviceExists = _context.TesterParameters.Where(t => t.DeviceName.Equals(model.DeviceName)).Select(n => n.DeviceName).FirstOrDefault();
                if (isDeviceExists != null)
                {
                    ViewBag.DeviceAlreadyExists = "This device is already exists in the database";
                    return View(model);
                }
                else
                {
                    var addedmodel = testerParametersRepository.Create(model);
                    _context.TesterParameters.Add(addedmodel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { name = addedmodel.DeviceName });
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id, TesterParameterCodeType type, string parameterName, string parameterValue, int index)
        {
            var product = await _context.TesterParameters.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new EditTesterParameter
            {
                Id = id,
                Type = type,
                ParameterName = parameterName,
                ParameterValue = parameterValue,// GetParameter(type, product.Parameter, parameterName, index),
                Index = index
            };

            ViewBag.DeviceName = product.DeviceName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string oldParameterName, string oldParameterValue, EditTesterParameter model)
        {
            if (ModelState.IsValid)
            {
                var product = testerParametersRepository.Edit(oldParameterName, oldParameterValue, model);
                _context.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { name = product.DeviceName });
            }

            return View(model);
        }

        public async Task<IActionResult> Add(int id, TesterParameterCodeType type)
        {
            var product = await _context.TesterParameters.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new EditTesterParameter
            {
                Id = id,
                Type = type
            };

            ViewBag.DeviceName = product.DeviceName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(EditTesterParameter model)
        {
            if (ModelState.IsValid)
            {
                var newParameter = testerParametersRepository.Add(model);
                _context.Update(newParameter);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Main), new { name = product.DeviceName });
                return RedirectToAction("Details", new { name = newParameter.DeviceName });
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id, TesterParameterCodeType type, string parameterName, int index, string parameterValue)
        {
            var product = await _context.TesterParameters.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new EditTesterParameter
            {
                Id = id,
                Type = type,
                ParameterName = parameterName,
                ParameterValue = parameterValue,// GetParameter(type, product.Parameter, parameterName, index),
                Index = index
            };

            ViewBag.DeviceName = product.DeviceName;
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(EditTesterParameter model)
        {
            var device = testerParametersRepository.Delete(model);

            return RedirectToAction("Details", new { name = device.DeviceName });
        }

        private string GetParameter(TesterParameterCodeType type, string sourceXml, string parameterName, int index)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(sourceXml);

            var parameterNode = xmlDocument.SelectNodes($"//ProductCode/{type}/{parameterName}");
            return parameterNode[index]?.InnerText;
        }

        #region Web API
        // GET: TesterParameter/Details/5
        //Sample Query String https://localhost/BuildSheetsArea/TesterParameters/GetTesterParameterJson?searchTerms=ATT-GO9LTE
        [HttpGet]
        public JsonResult GetTesterParameterJson(string searchTerms)
        {
            var deviceList = _context.TesterParameters.Where(n => n.DeviceName == searchTerms.ToUpper()).Select(n => n.Parameter).FirstOrDefault();
            return Json(deviceList);
        }


        //GET: TesterParameter/Details/5
        //Sample Query String https://localhost/BuildSheetsArea/TesterParameters/GetTesterParameterXml?searchTerms=ATT-GO9LTE
        //Sample Query String https://automationtest.geotab.com/BuildSheetsArea/TesterParameters/GetTesterParameterxml?searchTerms=ATT-GO73G1
        [HttpGet]
        public IActionResult GetTesterParameterXml1(string searchTerms)
        {
            var deviceList = _context.TesterParameters.Where(n => n.DeviceName == searchTerms.ToUpper()).Select(n => n.Parameter).FirstOrDefault();
            OkObjectResult result = Ok(deviceList);
            result.Formatters.Clear();

            result.Formatters.Add(new Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter());
            return result;
        }

        [HttpGet]
        public IActionResult GetTesterParameterXml(string searchTerms)
        {
            TesterParameter testerParameter = null;
            testerParameter = _context.TesterParameters.FirstOrDefault(x => x.DeviceName.ToLower() == searchTerms.ToLower());
            if (testerParameter == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
            var xmlSerializer = new XmlSerializer(typeof(TesterParameterCode));
            testerParameter.TesterParameterCode = (TesterParameterCode)xmlSerializer.Deserialize(new StringReader(testerParameter.Parameter));

            var sb = new StringBuilder();
            if (testerParameter.TesterParameterCode.DeviceParameters.Parameters != null)
            {
                foreach (var param in testerParameter.TesterParameterCode.DeviceParameters.Parameters)
                {
                    sb.Append($"<{param.Name}>{param.InnerText}</{ param.Name}> ");
                }
            }

            if (testerParameter.TesterParameterCode.FirmwareGates.Parameters != null)
            {
                foreach (var param in testerParameter.TesterParameterCode.FirmwareGates.Parameters)
                {
                    sb.Append($"<{param.Name}>{param.InnerText}</{ param.Name}>");
                }
            }
            if (testerParameter.TesterParameterCode.ModemIncludeList.Parameters != null)
            {
                foreach (var param in testerParameter.TesterParameterCode.ModemIncludeList.Parameters)
                {
                    sb.Append($"<{param.Name}>{param.InnerText}</{ param.Name}>");
                }
            }
            if (testerParameter.TesterParameterCode.ModemExcludeList.Parameters != null)
            {
                foreach (var param in testerParameter.TesterParameterCode.ModemExcludeList.Parameters)
                {
                    sb.Append($"<{param.Name}>{param.InnerText}</{ param.Name}>");
                }
            }
            //var test = string.Join("<>", sb);
            //var xmlDocument = new XmlDocument();
            //xmlDocument.LoadXml(sb.ToString());

            OkObjectResult result = Ok(sb.ToString());
            result.Formatters.Clear();

            result.Formatters.Add(new Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter());
            return result;
        }
        #endregion
    }

}














































//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;
//using System.Xml.Serialization;
//using BuildSheets.Data;
//using BuildSheets.Helpers;
//using BuildSheets.Models;
//using BuildSheets.Repository;
//using BuildSheets.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace BuildSheets.Controllers
//{
//    [Area("BuildSheetsArea")]
//    public class TesterParametersController : Controller
//    {
//        private readonly BuildSheetsDBContext _context;
//        private readonly ITesterParameters testerParametersRepository;
//        public TesterParametersController(BuildSheetsDBContext context, ITesterParameters testerParameters)
//        {
//            _context = context;
//            testerParametersRepository = testerParameters;
//        }
//        public IActionResult Main(string name)
//        {
//            var testerParameter = testerParametersRepository.Main(name);
//            if (!string.IsNullOrWhiteSpace(name) && testerParameter == null)
//            {
//                ViewBag.ErrorMessage = "No Result found";
//                return View(testerParameter);
//            }
//            else
//            {
//                return View(testerParameter);
//            }
//            //TesterParameter testerParameter = null;
//            //if (!string.IsNullOrWhiteSpace(name))
//            //{
//            //    testerParameter = await _context.TesterParameters.FirstOrDefaultAsync(x => x.DeviceName.ToLower() == name.ToLower());
//            //    if (testerParameter == null)
//            //    {
//            //        ViewBag.ErrorMessage = "No Result found";
//            //        return View(testerParameter);
//            //    }
//            //    else
//            //    {
//            //        if (!string.IsNullOrEmpty(testerParameter.Parameter))
//            //        {
//            //            var xmlSerializer = new XmlSerializer(typeof(TesterParameterCode));
//            //            testerParameter.TesterParameterCode = (TesterParameterCode)xmlSerializer.Deserialize(new StringReader(testerParameter.Parameter));
//            //        }
//            //    }
//            //}

//            //return View(testerParameter);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(AddTesterParameter model)//string any=""
//        {
//            if (ModelState.IsValid)
//            {
//                var isDeviceExists = _context.TesterParameters.Where(t => t.DeviceName.Equals(model.DeviceName)).Select(n => n.DeviceName).FirstOrDefault();
//                if (isDeviceExists != null)
//                {
//                    ViewBag.DeviceAlreadyExists = "This device is already exists in the database";
//                    return View(model);
//                }
//                else
//                {
//                    var deviceParameters = $"<{TesterParameterCodeType.DeviceParameters}>" +
//                        $"{string.Join("", model.DeviceParameters.Parameters.Where(x => !string.IsNullOrWhiteSpace(x.Key)).Select(x => $"<{x.Key}>{x.Value}</{x.Key}>"))}" +
//                        $"</{TesterParameterCodeType.DeviceParameters}>";

//                    var firmwareGatesParameters = $"<{TesterParameterCodeType.FirmwareGates}>" +
//                        $"{string.Join("", model.FirmwareGates.Parameters.Where(x => !string.IsNullOrWhiteSpace(x.Key)).Select(x => $"<{x.Key}>{x.Value}</{x.Key}>"))}" +
//                        $"</{TesterParameterCodeType.FirmwareGates}>";

//                    var modemIncludeList = $"<{TesterParameterCodeType.ModemIncludeList}>" +
//                        $"{string.Join("", model.ModemIncludeList.Parameters.Where(x => !string.IsNullOrWhiteSpace(x.Key)).Select(x => $"<{x.Key}>{x.Value}</{x.Key}>"))}" +
//                        $"</{TesterParameterCodeType.ModemIncludeList}>";


//                    var testerParameter = new TesterParameter
//                    {
//                        DeviceName = model.DeviceName,
//                        Parameter = $"<ProductCode>{deviceParameters}{firmwareGatesParameters}{modemIncludeList}</ProductCode>"
//                    };
//                    _context.TesterParameters.Add(testerParameter);
//                    await _context.SaveChangesAsync();
//                    return RedirectToAction(nameof(Main), new { name = testerParameter.DeviceName });
//                }
//            }

//            return View(model);
//            //for (int i = 0; i <= Request.Form.Count; i++)
//            //{
//            //    var ClientSampleID = Request.Form["DeviceParameters.Parameters[" + i + "]"];
//            //    var additionalComments = Request.Form["DeviceParameters.Parameters[" + i + "]"];


//            //    //if (!String.IsNullOrEmpty(ClientSampleID))
//            //    //{
//            //    //    // _TableForm.Add(new TableForm { ClientSampleID = ClientSampleID, AcidStables = acidStables, AdditionalComments = additionalComments });
//            //    //}
//            //}
//            //return View();
//        }

//        public async Task<IActionResult> Edit(int id, TesterParameterCodeType type, string parameterName)
//        {
//            var product = await _context.TesterParameters.FindAsync(id);
//            if (product == null)
//            {
//                return NotFound();
//            }

//            var model = new EditTesterParameter
//            {
//                Id = id,
//                Type = type,
//                ParameterName = parameterName,
//                ParameterValue = GetParameter(type, product.Parameter, parameterName)
//            };

//            ViewBag.DeviceName = product.DeviceName;
//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(string oldParameterName, EditTesterParameter model)
//        {
//            if (ModelState.IsValid)
//            {
//                var product = await _context.TesterParameters.FirstOrDefaultAsync(x => x.Id == model.Id);
//                product.Parameter = EditParameter(model.Type, product.Parameter,
//                    oldParameterName, model.ParameterName, model.ParameterValue);
//                _context.Update(product);
//                await _context.SaveChangesAsync();
//                //return RedirectToAction(nameof(Main), new { name = product.DeviceName });
//                return RedirectToAction("Main", new { name = product.DeviceName });
//            }

//            return View(model);
//        }

//        public async Task<IActionResult> Add(int id, TesterParameterCodeType type)
//        {
//            var product = await _context.TesterParameters.FindAsync(id);
//            if (product == null)
//            {
//                return NotFound();
//            }

//            var model = new EditTesterParameter
//            {
//                Id = id,
//                Type = type
//            };

//            ViewBag.DeviceName = product.DeviceName;
//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Add(EditTesterParameter model)
//        {
//            if (ModelState.IsValid)
//            {
//                var product = await _context.TesterParameters.FirstOrDefaultAsync(x => x.Id == model.Id);
//                product.Parameter = AddParameter(model.Type, product.Parameter,
//                    model.ParameterName, model.ParameterValue);
//                _context.Update(product);
//                await _context.SaveChangesAsync();
//                //return RedirectToAction(nameof(Main), new { name = product.DeviceName });
//                return RedirectToAction("Main", new { name = product.DeviceName });
//            }

//            return View(model);
//        }

//        public async Task<IActionResult> Delete(int id, TesterParameterCodeType type, string parameterName)
//        {
//            var product = await _context.TesterParameters.FirstOrDefaultAsync(x => x.Id == id);
//            if (product == null)
//            {
//                return NotFound();
//            }

//            var model = new EditTesterParameter
//            {
//                Id = id,
//                Type = type,
//                ParameterName = parameterName,
//                ParameterValue = GetParameter(type, product.Parameter, parameterName)
//            };

//            ViewBag.DeviceName = product.DeviceName;
//            return View(model);
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(EditTesterParameter model)
//        {
//            var product = await _context.TesterParameters.FindAsync(model.Id);
//            if (product == null)
//            {
//                return NotFound();
//            }

//            product.Parameter = RemoveParameter(model.Type, product.Parameter, model.ParameterName);

//            await _context.SaveChangesAsync();
//            //return RedirectToAction(nameof(Main), new { name = product.DeviceName });
//            return RedirectToAction("Main", new { name = product.DeviceName });
//        }

//        private string AddParameter(TesterParameterCodeType type, string sourceXml, string parameterName, string parameterValue)
//        {
//            if (string.IsNullOrWhiteSpace(sourceXml))
//            {
//                sourceXml = $"<ProductCode><{type}></{type}></ProductCode>";
//            }

//            var xmlDocument = new XmlDocument();
//            xmlDocument.LoadXml(sourceXml);
//            var deviceParametersNode = xmlDocument.SelectSingleNode($"//ProductCode/{type}");

//            if (deviceParametersNode == null)
//            {
//                var rootNode = xmlDocument.SelectSingleNode($"//ProductCode");
//                deviceParametersNode = xmlDocument.CreateElement(type.ToString());
//                rootNode.AppendChild(deviceParametersNode);
//            }

//            var newParameter = xmlDocument.CreateElement(parameterName);
//            newParameter.InnerText = parameterValue;
//            deviceParametersNode.AppendChild(newParameter);

//            var stringWriter = new StringWriter();
//            xmlDocument.Save(stringWriter);
//            return stringWriter.ToString();
//        }
//        private string GetParameter(TesterParameterCodeType type, string sourceXml, string parameterName)
//        {
//            var xmlDocument = new XmlDocument();
//            xmlDocument.LoadXml(sourceXml);

//            var parameterNode = xmlDocument.SelectSingleNode($"//ProductCode/{type}/{parameterName}");
//            return parameterNode?.InnerText;
//        }
//        private string EditParameter(TesterParameterCodeType type, string sourceXml, string oldParameterName, string newParameterName, string parameterValue)
//        {
//            var xmlDocument = new XmlDocument();
//            xmlDocument.LoadXml(sourceXml);

//            var parameterNode = xmlDocument.SelectSingleNode($"//ProductCode/{type}/{oldParameterName}");
//            if (parameterNode == null) return sourceXml;

//            var deviceParametersNode = parameterNode.ParentNode;

//            parameterNode.ParentNode.RemoveChild(parameterNode);

//            var newParameter = xmlDocument.CreateElement(newParameterName);
//            newParameter.InnerText = parameterValue;
//            deviceParametersNode.AppendChild(newParameter);

//            var stringWriter = new StringWriter();
//            xmlDocument.Save(stringWriter);
//            return stringWriter.ToString();
//        }
//        private string RemoveParameter(TesterParameterCodeType type, string sourceXml, string parameterName)
//        {
//            var xmlDocument = new XmlDocument();
//            xmlDocument.LoadXml(sourceXml);

//            var parameterNode = xmlDocument.SelectSingleNode($"//ProductCode/{type}/{parameterName}");
//            if (parameterNode == null) return sourceXml;

//            parameterNode.ParentNode.RemoveChild(parameterNode);

//            var stringWriter = new StringWriter();
//            xmlDocument.Save(stringWriter);
//            return stringWriter.ToString();
//        }

//        #region Web API
//        // GET: TesterParameter/Details/5
//        //Sample Query String https://localhost/BuildSheetsArea/TesterParametersHome/GetTesterParameterJson?searchTerms=ATT-GO9LTE
//        [HttpGet]
//        public JsonResult GetTesterParameterJson(string searchTerms)
//        {
//            var deviceList = _context.TesterParameters.Where(n => n.DeviceName == searchTerms.ToUpper()).Select(n => n.Parameter).FirstOrDefault();
//            return Json(deviceList);
//        }


//        //GET: TesterParameter/Details/5
//        //Sample Query String https://localhost/BuildSheetsArea/TesterParametersHome/GetTesterParameterXml?searchTerms=sample1
//        [HttpGet]
//        public IActionResult GetTesterParameterXml1(string searchTerms)
//        {
//            var deviceList = _context.TesterParameters.Where(n => n.DeviceName == searchTerms.ToUpper()).Select(n => n.Parameter).FirstOrDefault();
//            OkObjectResult result = Ok(deviceList);
//            result.Formatters.Clear();

//            result.Formatters.Add(new Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter());
//            return result;
//        }

//        [HttpGet]
//        public IActionResult GetTesterParameterXml(string searchTerms)
//        {
//            TesterParameter testerParameter = null;
//            testerParameter = _context.TesterParameters.FirstOrDefault(x => x.DeviceName.ToLower() == searchTerms.ToLower());
//            if (testerParameter == null)
//            {
//                Response.StatusCode = 404;
//                return View("NotFound");
//            }
//            var xmlSerializer = new XmlSerializer(typeof(TesterParameterCode));
//            testerParameter.TesterParameterCode = (TesterParameterCode)xmlSerializer.Deserialize(new StringReader(testerParameter.Parameter));

//            var sb = new StringBuilder();
//            if (testerParameter.TesterParameterCode.DeviceParameters.Parameters != null)
//            {
//                foreach (var param in testerParameter.TesterParameterCode.DeviceParameters.Parameters)
//                {
//                    sb.Append($"<{param.Name}>{param.InnerText}</{ param.Name}> ");
//                }
//            }

//            if (testerParameter.TesterParameterCode.FirmwareGates.Parameters != null)
//            {
//                foreach (var param in testerParameter.TesterParameterCode.FirmwareGates.Parameters)
//                {
//                    sb.Append($"<{param.Name}>{param.InnerText}</{ param.Name}>");
//                }
//            }
//            if (testerParameter.TesterParameterCode.ModemIncludeList.Parameters != null)
//            {
//                foreach (var param in testerParameter.TesterParameterCode.ModemIncludeList.Parameters)
//                {
//                    sb.Append($"<{param.Name}>{param.InnerText}</{ param.Name}>");
//                }
//            }
//            if (testerParameter.TesterParameterCode.ModemExcludeList.Parameters != null)
//            {
//                foreach (var param in testerParameter.TesterParameterCode.ModemExcludeList.Parameters)
//                {
//                    sb.Append($"<{param.Name}>{param.InnerText}</{ param.Name}>");
//                }
//            }
//            //var test = string.Join("<>", sb);
//            //var xmlDocument = new XmlDocument();
//            //xmlDocument.LoadXml(sb.ToString());

//            OkObjectResult result = Ok(sb.ToString());
//            result.Formatters.Clear();

//            result.Formatters.Add(new Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter());
//            return result;
//        }
//        #endregion
//    }

//}