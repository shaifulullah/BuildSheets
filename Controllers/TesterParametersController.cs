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
        #region Variables
        private readonly BuildSheetsDBContext _context;
        private readonly ITesterParameters testerParametersRepository;
        #endregion

        #region Constructor
        public TesterParametersController(BuildSheetsDBContext context, ITesterParameters testerParameters)
        {
            _context = context;
            testerParametersRepository = testerParameters;
        }
        #endregion

        #region Checks
        public bool CheckIsEditable(string name, int revision)
        {
            bool isEditable = false;
            var nextRevision = _context.TesterParameters.FirstOrDefault(x => x.DeviceName.ToLower() == name.ToLower() && x.Revision == (revision + 1));

            if (nextRevision == null)
            {
                isEditable = true;
            }

            return isEditable;
        }

        public bool CanEnableUpdateBuildSheetButton(string name, int revision)
        {
            var testerParameterId = _context.TesterParameters.Where(tp => tp.DeviceName.ToLower() == name.ToLower() && tp.Revision == revision).FirstOrDefault().Id;
            var getBuildSheet = _context.BuildSheets.Where(bs => bs.ProductName.ToLower() == name.ToLower()).FirstOrDefault();
            if (getBuildSheet != null)
            {
                if (getBuildSheet.TesterParameterId == testerParameterId)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
        #endregion

        #region Coltroller Action Method

        #region Mass Editing
        public IActionResult MassEditing()
        {
            GetDeviceType devicetype = new GetDeviceType();
            ViewData["ChangeTypeId"] = new SelectList(devicetype.ListofDevices(), "Id", "Name");
            GetListOfDevices newdeviceList = new GetListOfDevices();
            var listing = newdeviceList.GetListofDevices();

            return View(listing);
        }
        [HttpPost]
        public async Task<IActionResult> MassEditing(string ChangeTypeId, string param, string ParameterValue = "")
        {
            if (ChangeTypeId != null && param != null)
            {
                GetDeviceType getDeviceType = new GetDeviceType();
                var listOfDevice = getDeviceType.ListofDevices().Where(d => d.Id == Convert.ToInt32(ChangeTypeId)).FirstOrDefault().Name;
                List<TesterParameter> deviceList = testerParametersRepository.Main(listOfDevice).ToList();
                List<TesterParameter> tp = testerParametersRepository.Main(listOfDevice).ToList();
                List<TesterParameter> tpList = new List<TesterParameter>();
                List<TesterParameter> finalList = new List<TesterParameter>();

                string[] parentChild = param.Split("|");
                string parentParameter = parentChild[0];
                string childParameter = parentChild[1];

                foreach (var device in deviceList)
                {
                    //var nextRevision = _context.TesterParameters.FirstOrDefault(x => x.DeviceName.ToLower() == device.DeviceName.ToLower() && x.Revision == (device.Revision + 1));
                    var nextRevision = tp.FirstOrDefault(x => x.DeviceName.ToLower() == device.DeviceName.ToLower() && x.Revision == (device.Revision + 1));
                    if (nextRevision == null)
                    {
                        tpList.Add(device);
                    }
                }
                foreach (TesterParameter testerParameter in tpList)
                {
                    var xmlSerializer = new XmlSerializer(typeof(TesterParameterCode));
                    var testerparametercodes = testerParameter.TesterParameterCode = (TesterParameterCode)xmlSerializer.Deserialize(new StringReader(testerParameter.Parameter));
                    if (parentParameter == "DeviceParameters")
                    {
                        if (testerparametercodes?.DeviceParameters?.Parameters != null)
                        {
                            foreach (var parameter in testerparametercodes?.DeviceParameters?.Parameters)
                            {
                                if (parameter.Name == childParameter && parameter.InnerText.ToLower() == ParameterValue.ToLower())
                                {
                                    finalList.Add(testerParameter);
                                }
                                else if (parameter.Name == childParameter && ParameterValue == null)
                                {
                                    finalList.Add(testerParameter);
                                }
                            }
                        }
                    }
                    else if (parentParameter == "FirmwareGates")
                    {
                        if (testerparametercodes?.FirmwareGates?.Parameters != null)
                        {
                            foreach (var parameter in testerparametercodes?.FirmwareGates?.Parameters)
                            {
                                if (parameter.Name == childParameter && parameter.InnerText.ToLower() == ParameterValue.ToLower())
                                {
                                    finalList.Add(testerParameter);
                                }
                                else if (parameter.Name == childParameter && ParameterValue == null)
                                {
                                    finalList.Add(testerParameter);
                                }
                            }
                        }
                    }
                    else if (parentParameter == "ModemIncludeList")
                    {
                        if (testerparametercodes?.ModemIncludeList?.Parameters != null)
                        {
                            foreach (var parameter in testerparametercodes?.ModemIncludeList?.Parameters)
                            {
                                if (parameter.Name == childParameter && parameter.InnerText.ToLower() == ParameterValue.ToLower())
                                {
                                    finalList.Add(testerParameter);
                                }
                                else if (parameter.Name == childParameter && ParameterValue == null)
                                {
                                    finalList.Add(testerParameter);
                                }
                            }
                        }
                    }
                    else if (parentParameter == "ModemExcludeList")
                    {
                        if (testerparametercodes?.ModemExcludeList?.Parameters != null)
                        {
                            foreach (var parameter in testerparametercodes?.ModemExcludeList?.Parameters)
                            {
                                if (parameter.Name == childParameter && parameter.InnerText.ToLower() == ParameterValue.ToLower())
                                {
                                    finalList.Add(testerParameter);
                                }
                                else if (parameter.Name == childParameter && ParameterValue == null)
                                {
                                    finalList.Add(testerParameter);
                                }
                            }
                        }
                    }
                }



                foreach (TesterParameter devices in tpList)
                {
                    EditTesterParameter editTesterParameter = new EditTesterParameter();
                    editTesterParameter.Id = devices.Id;
                    editTesterParameter.ParameterName = childParameter;
                    editTesterParameter.Revision = devices.Revision;
                    editTesterParameter.Type = (TesterParameterCodeType)System.Enum.Parse(typeof(TesterParameterCodeType), parentParameter);

                    var product = testerParametersRepository.Edit(childParameter, string.Empty, editTesterParameter);

                    _context.TesterParameters.Add(product);
                    //await _context.SaveChangesAsync();
                }
                return MassEditing();
            }
            else
            {
                ViewData["ErrorMessage"] = "Please make sure you have entered value in each of the field above.";
                return MassEditing();
            }

        }
        //[HttpPost]
        //public async Task<IActionResult> MassEditing(string ChangeTypeId, string param, string ParameterValue)
        //{
        //    if (ChangeTypeId != null && param != null && ParameterValue != null)
        //    {
        //        GetDeviceType getDeviceType = new GetDeviceType();
        //        var listOfDevice = getDeviceType.ListofDevices().Where(d => d.Id == Convert.ToInt32(ChangeTypeId)).FirstOrDefault().Name;
        //        List<TesterParameter> deviceList = testerParametersRepository.Main(listOfDevice).ToList();
        //        List<TesterParameter> tp = testerParametersRepository.Main(listOfDevice).ToList();
        //        List<TesterParameter> tpList = new List<TesterParameter>();

        //        foreach (var device in deviceList)
        //        {
        //            //var nextRevision = _context.TesterParameters.FirstOrDefault(x => x.DeviceName.ToLower() == device.DeviceName.ToLower() && x.Revision == (device.Revision + 1));
        //            var nextRevision = tp.FirstOrDefault(x => x.DeviceName.ToLower() == device.DeviceName.ToLower() && x.Revision == (device.Revision + 1));
        //            if (nextRevision == null)
        //            {
        //                tpList.Add(device);
        //            }
        //        }

        //        string[] parentChild = param.Split("|");
        //        string parentParameter = parentChild[0];
        //        string childParameter = parentChild[1];

        //        foreach (TesterParameter devices in tpList)
        //        {
        //            EditTesterParameter editTesterParameter = new EditTesterParameter();
        //            editTesterParameter.Id = devices.Id;
        //            editTesterParameter.ParameterName = childParameter;
        //            editTesterParameter.ParameterValue = ParameterValue;
        //            editTesterParameter.Revision = devices.Revision;
        //            editTesterParameter.Type = (TesterParameterCodeType)System.Enum.Parse(typeof(TesterParameterCodeType), parentParameter);

        //            var product = testerParametersRepository.Edit(childParameter, string.Empty, editTesterParameter);

        //            _context.TesterParameters.Add(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        return MassEditing();
        //    }
        //    else
        //    {
        //        ViewData["ErrorMessage"] = "Please make sure you have entered value in each of the field above.";
        //        return MassEditing();
        //    }

        //}
        #endregion
        //public IActionResult Main(string name)
        //{
        //    var testerParameter = testerParametersRepository.Main(name);
        //    if (!string.IsNullOrWhiteSpace(name) && testerParameter == null)
        //    {
        //        ViewBag.ErrorMessage = "No Result found";
        //        return View(testerParameter);
        //    }
        //    else
        //    {
        //        ViewBag.SearchString = name;
        //        return View(testerParameter);
        //    }
        //}
        public IActionResult Main()
        {
            var testerParameter = testerParametersRepository.GetAll();

            return View(testerParameter);

        }

        public IActionResult Details(string name, int revision)
        {
            var DetailTesterParameter = testerParametersRepository.Details(name, revision);
            bool isEditable = CheckIsEditable(name, revision);
            bool enableUpdateBuildSheetButton = CanEnableUpdateBuildSheetButton(name, revision);

            if (!string.IsNullOrWhiteSpace(TempData["AddBuildSheetConfirmation"] as string))
            {
                ViewData["AddBuildSheetConfirmation"] = TempData["AddBuildSheetConfirmation"];
            }

            ViewData["enableUpdateBuildSheetButton"] = enableUpdateBuildSheetButton;
            ViewData["isEditable"] = isEditable;
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

        public IActionResult Edit(int id, TesterParameterCodeType type, string parameterName, string parameterValue, int revision/*int index*/)
        {
            var product = _context.TesterParameters.Where(tp => tp.Id == id && tp.Revision == revision).FirstOrDefault();
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
                Revision = revision
                //Index = index
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

                _context.TesterParameters.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { name = product.DeviceName, revision = product.Revision });
            }

            return View(model);
        }

        public async Task<IActionResult> Add(int id, TesterParameterCodeType type, int revision)
        {
            var product = _context.TesterParameters.Where(tp => tp.Id == id && tp.Revision == revision).FirstOrDefault();
            //var product = await _context.TesterParameters.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new EditTesterParameter
            {
                Id = id,
                Type = type,
                Revision = revision
            };
            if (type == TesterParameterCodeType.DeviceParameters)
            {
                var dropDownListForDeviceParam = new List<SelectListItem>();
                dropDownListForDeviceParam.Add(new SelectListItem
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
                ViewBag.DeviceParameterName = dropDownListForDeviceParam;
            }
            else if (type == TesterParameterCodeType.FirmwareGates)
            {
                var dropDownListForFirmwareGates = new List<SelectListItem>();
                dropDownListForFirmwareGates.Add(new SelectListItem
                {
                    Text = "Please Select",
                    Value = ""
                });
                foreach (FirmwareGatesName paramName in Enum.GetValues(typeof(FirmwareGatesName)))
                {
                    dropDownListForFirmwareGates.Add(new SelectListItem
                    {
                        Text = Enum.GetName(typeof(FirmwareGatesName), paramName),
                        Value = paramName.ToString()
                    });
                }
                ViewBag.FirmwareGatesName = dropDownListForFirmwareGates;
            }
            else if (type == TesterParameterCodeType.ModemIncludeList)
            {
                var dropDownListForModemInclude = new List<SelectListItem>();
                dropDownListForModemInclude.Add(new SelectListItem
                {
                    Text = "Please Select",
                    Value = ""
                });
                foreach (ModemIncludeList paramName in Enum.GetValues(typeof(ModemIncludeList)))
                {
                    dropDownListForModemInclude.Add(new SelectListItem
                    {
                        Text = Enum.GetName(typeof(ModemIncludeList), paramName),
                        Value = paramName.ToString()
                    });
                }
                ViewBag.ModemIncludeList = dropDownListForModemInclude;
            }
            else
            {
                var dropDownListForModemExclude = new List<SelectListItem>();
                dropDownListForModemExclude.Add(new SelectListItem
                {
                    Text = "Please Select",
                    Value = ""
                });
                foreach (ModemExcludeList paramName in Enum.GetValues(typeof(ModemExcludeList)))
                {
                    dropDownListForModemExclude.Add(new SelectListItem
                    {
                        Text = Enum.GetName(typeof(ModemExcludeList), paramName),
                        Value = paramName.ToString()
                    });
                }
                ViewBag.ModemExcludeList = dropDownListForModemExclude;
            }
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
                //_context.Update(newParameter);
                _context.TesterParameters.Add(newParameter);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Main), new { name = product.DeviceName });
                return RedirectToAction("Details", new { name = newParameter.DeviceName, revision = newParameter.Revision });
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id, TesterParameterCodeType type, string parameterName, int revision, string parameterValue)
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
                Revision = revision
                //Index = index
            };

            ViewBag.DeviceName = product.DeviceName;
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(EditTesterParameter model)
        {
            var device = testerParametersRepository.Delete(model);

            return RedirectToAction("Details", new { name = device.DeviceName, revision = device.Revision });
        }
        public IActionResult UpdateBS(int id, string devicename, int revision)
        {

            var buildSheet = _context.BuildSheets.Where(bs => bs.ProductName.ToLower() == devicename.ToLower()).FirstOrDefault();
            if (buildSheet != null)
            {
                buildSheet.TesterParameterId = id;
                _context.Update(buildSheet);
                _context.SaveChanges();
                TempData["AddBuildSheetConfirmation"] = "Build Sheet has been updated";
            }
            else
            {
                TempData["AddBuildSheetConfirmation"] = "No buildsheet found to update";
            }

            return RedirectToAction("Details", new { name = devicename, revision = revision });
            //return RedirectToAction("Details", new { name = devicename, revision });
        }
        #endregion

        #region Helper Method
        private string GetParameter(TesterParameterCodeType type, string sourceXml, string parameterName, int index)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(sourceXml);

            var parameterNode = xmlDocument.SelectNodes($"//ProductCode/{type}/{parameterName}");
            return parameterNode[index]?.InnerText;
        }
        #endregion

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
        //Sample Query String https://localhost/BuildSheetsArea/TesterParameters/GetTesterParameterXml?searchTerms=test
        //Sample Query String https://localhost/BuildSheetsArea/TesterParameters/GetTesterParameterXml?searchTerms=test&revisionnumber=1
        //Sample Query String  https://automationtest.geotab.com/BuildSheetsArea/TesterParameters/GetTesterParameterXml?searchTerms=test
        //Sample Query String  https://automationtest.geotab.com/BuildSheetsArea/TesterParameters/GetTesterParameterXml?searchTerms=test&revisionnumber=1
        [HttpGet]
        public IActionResult GetTesterParameterXml(string searchTerms, int revisionnumber = 0)
        {
            OkObjectResult result = null;

            if (revisionnumber > 0)
            {
                var deviceList = _context.TesterParameters.Where(n => n.DeviceName.ToUpper() == searchTerms.ToUpper() && n.Revision == revisionnumber).Select(n => n.Parameter).FirstOrDefault();
                result = Ok(deviceList);
                result.Formatters.Clear();

                result.Formatters.Add(new Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter());
                return result;
            }
            else
            {
                var getDeviceList = _context.TesterParameters.Where(n => n.DeviceName.ToUpper() == searchTerms.ToUpper()).ToList();
                TesterParameter deviceToSend = new TesterParameter();
                foreach (var device in getDeviceList)
                {
                    if (deviceToSend.DeviceName == null)
                    {
                        deviceToSend = device;
                    }
                    else
                    {
                        if (device.Revision > deviceToSend.Revision)
                        {
                            deviceToSend = device;
                        }
                    }
                }
                var deviceList = deviceToSend.Parameter;
                result = Ok(deviceList);
                result.Formatters.Clear();

                result.Formatters.Add(new Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter());
                return result;
            }
        }

        //Sample Query String https://localhost/BuildSheetsArea/TesterParameters/GetTesterParameterXml1?searchTerms=test
        //Sample Query String https://localhost/BuildSheetsArea/TesterParameters/GetTesterParameterXml1?searchTerms=test&revisionnumber=1
        //Sample Query String  https://automationtest.geotab.com/BuildSheetsArea/TesterParameters/GetTesterParameterXml1?searchTerms=test
        //Sample Query String  https://automationtest.geotab.com/BuildSheetsArea/TesterParameters/GetTesterParameterXml1?searchTerms=test&revisionnumber=1
        [HttpGet]
        public IActionResult GetTesterParameterXml1(string searchTerms, int revisionnumber = 0)
        {
            OkObjectResult result = null;
            TesterParameter testerParameter = null;

            if (revisionnumber > 0)
            {
                testerParameter = _context.TesterParameters.FirstOrDefault(x => x.DeviceName.ToLower() == searchTerms.ToLower() && x.Revision == revisionnumber);
                if (testerParameter == null)
                {
                    Response.StatusCode = 404;
                    return View("NotFound");
                }
                else
                {
                    result = Build(testerParameter);
                    return result;
                }
            }
            else
            {
                var getDeviceList = _context.TesterParameters.Where(n => n.DeviceName.ToUpper() == searchTerms.ToUpper()).ToList();
                TesterParameter deviceToSend = new TesterParameter();
                foreach (var device in getDeviceList)
                {
                    if (deviceToSend.DeviceName == null)
                    {
                        deviceToSend = device;
                    }
                    else
                    {
                        if (device.Revision > deviceToSend.Revision)
                        {
                            deviceToSend = device;
                        }
                    }
                }
                result = Build(deviceToSend);
                return result;
            }
        }

        public OkObjectResult Build(TesterParameter testerParameter)
        {
            var xmlSerializer = new XmlSerializer(typeof(TesterParameterCode));
            testerParameter.TesterParameterCode = (TesterParameterCode)xmlSerializer.Deserialize(new StringReader(testerParameter.Parameter));

            var sb = new StringBuilder();
            if (testerParameter.TesterParameterCode.DeviceParameters != null)
            {
                if (testerParameter.TesterParameterCode.DeviceParameters.Parameters != null)
                {
                    foreach (var param in testerParameter.TesterParameterCode.DeviceParameters.Parameters)
                    {
                        sb.Append($"<{param.Name}>{param.InnerText}</{ param.Name}> ");
                    }
                }
            }

            if (testerParameter.TesterParameterCode.FirmwareGates.Parameters != null)
            {
                if (testerParameter.TesterParameterCode.FirmwareGates.Parameters != null)
                {
                    foreach (var param in testerParameter.TesterParameterCode.FirmwareGates.Parameters)
                    {
                        sb.Append($"<{param.Name}>{param.InnerText}</{ param.Name}>");
                    }
                }
            }


            if (testerParameter.TesterParameterCode.ModemIncludeList != null)
            {
                if (testerParameter.TesterParameterCode.ModemIncludeList.Parameters != null)
                {
                    foreach (var param in testerParameter.TesterParameterCode.ModemIncludeList.Parameters)
                    {
                        sb.Append($"<{param.Name}>{param.InnerText}</{ param.Name}>");
                    }
                }
            }
            if (testerParameter.TesterParameterCode.ModemExcludeList != null)
            {
                if (testerParameter.TesterParameterCode.ModemExcludeList.Parameters != null)
                {
                    foreach (var param in testerParameter.TesterParameterCode.ModemExcludeList.Parameters)
                    {
                        sb.Append($"<{param.Name}>{param.InnerText}</{ param.Name}>");
                    }
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