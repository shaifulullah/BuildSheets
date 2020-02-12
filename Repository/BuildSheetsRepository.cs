using BuildSheets.Data;
using BuildSheets.Models;
using BuildSheets.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BuildSheets.Helpers;

namespace BuildSheets.Repository
{
    public class BuildSheetsRepository : IBuildSheets
    {
        private BuildSheetsDBContext _buildSheetsContext;

        public BuildSheetsRepository(BuildSheetsDBContext context)
        {
            _buildSheetsContext = context;
        }

        public IEnumerable<BuildSheet> Main(string name)
        {
            List<BuildSheet> buildSheets = null;
            if (!string.IsNullOrWhiteSpace(name))
            {
                buildSheets = _buildSheetsContext.BuildSheets.Where(b => b.ProductName.ToLower().Contains(name.ToLower().Trim())).ToList();
            }
            return buildSheets;
        }
        public BuildSheet Details(int? id)
        {
            var buildSheetDetails = _buildSheetsContext.BuildSheets
                .Include(b => b.BuildSheetsInternalSubAssemblyBoard)
                    .ThenInclude(bb => bb.InternalSubAssemblyBoard)
                .Include(bb => bb.BaseBoards)
                    .ThenInclude(bb => bb.BaseBoard)
                .Include(sb => sb.SubBoards)
                    .ThenInclude(sb => sb.SubBoard)
                .Include(b => b.OtherHardwares)
                    .ThenInclude(hw => hw.Hardware)
                .Include(b => b.Inserts)
                    .ThenInclude(hw => hw.Insert)
                .Include(l => l.Labels)
                    .ThenInclude(l => l.Label)
                .Include(p => p.Packagings)
                    .ThenInclude(p => p.Packaging)
                .Include(sd => sd.Documents)
                    .ThenInclude(d => d.Document)
                .Include(wi => wi.WorkInstructions)
                    .ThenInclude(d => d.WorkInstruction)
                 .Include(ad => ad.GeotabAssemblyDrawings)
                    .ThenInclude(d => d.GeotabAssemblyDrawing)
                 .Include(cm => cm.ContractManufactureAssemblyDrawings)
                    .ThenInclude(cm => cm.ContractManufactureAssemblyDrawing)
                 .Include(ts => ts.TesterSoftwares)
                    .ThenInclude(ts => ts.TesterSoftware)
                 .Include(clr => clr.CertificationLabelRequirements)
                    .ThenInclude(clr => clr.CertificationLabelRequirement)
                 .Include(tc => tc.CertificationTypes)
                    .ThenInclude(tc => tc.CertificationType)
                //.Include(tp=>tp.TesterParameter).Where(bs=>bs.ProductName==bs.TesterParameter.DeviceName)
                .FirstOrDefault(b => b.Id == id);

            var testerParameter = _buildSheetsContext.TesterParameters.Where(g => g.Id == buildSheetDetails.TesterParameterId).FirstOrDefault();

            if (testerParameter != null)
            {
                if (!string.IsNullOrEmpty(testerParameter.Parameter))
                {
                    var xmlSerializer = new XmlSerializer(typeof(TesterParameterCode));
                    //testerParameter.TesterParameterCode = (TesterParameterCode)xmlSerializer.Deserialize(new StringReader(testerParameter.Parameter));
                    var TesterParameterCode = (TesterParameterCode)xmlSerializer.Deserialize(new StringReader(testerParameter.Parameter));

                    if (TesterParameterCode.ModemIncludeList.Parameters.Length > 0)
                    {
                        foreach (var parameter in TesterParameterCode.ModemIncludeList.Parameters)
                        {
                            if (parameter.Name.ToLower() == "modem")
                            {
                                buildSheetDetails.ModemHwName = parameter.InnerText;
                            }
                            else if (parameter.Name.ToLower() == "modemfirmware")
                            {
                                buildSheetDetails.ModemFirmware = parameter.InnerText;
                            }
                        }
                    }

                    if (TesterParameterCode.FirmwareGates.Parameters.Length > 0)
                    {
                        foreach (var parameter in TesterParameterCode.FirmwareGates.Parameters)
                        {
                            if (parameter.Name.ToLower() == "firmware")
                            {
                                buildSheetDetails.DeviceFirmware = parameter.InnerText;
                            }
                        }
                    }

                    if (TesterParameterCode.DeviceParameters.Parameters.Length > 0)
                    {
                        foreach (var parameter in TesterParameterCode.DeviceParameters.Parameters)
                        {
                            if (parameter.Name.ToLower() == "imeigate")
                            {
                                buildSheetDetails.ImeiGate = parameter.InnerText;
                            }
                        }
                    }
                }
            }
            return buildSheetDetails;
        }
    }
}
