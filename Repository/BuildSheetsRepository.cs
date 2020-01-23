﻿using BuildSheets.Data;
using BuildSheets.Models;
using BuildSheets.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Repository
{
    public class BuildSheetsRepository : IBuildSheets
    {
        private BuildSheetsDBContext _buildSheetsContext; public BuildSheetsRepository(BuildSheetsDBContext context)
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
        public BuildSheet Details(string name)
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
            .FirstOrDefault(b => b.ProductName.ToLower() == name.ToLower()); return buildSheetDetails;
        }
    }
}
