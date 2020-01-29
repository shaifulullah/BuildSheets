using BuildSheets.Data;
using BuildSheets.Models;
using BuildSheets.Services;
using BuildSheets.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Controllers
{
    public class BuildSheetsController : Controller
    {
        private readonly BuildSheetsDBContext _context;
        private readonly IBuildSheets buildSheetsRepository;
        private readonly HttpContext _currentContext;

        public BuildSheetsController(BuildSheetsDBContext context, IBuildSheets buildSheets, IHttpContextAccessor _IHttpContextAccessor)
        {
            _context = context;
            buildSheetsRepository = buildSheets;
            _currentContext = _IHttpContextAccessor.HttpContext;
        }

        #region Gets
        private string GetLoggedInUsername()
        {
            string name = "";
            if (User.Identity.IsAuthenticated)
            {
                name = (User.Identity as System.Security.Claims.ClaimsIdentity)?.Claims.ElementAt(1).Value;
            }
            return name;
        }
        #endregion

        #region Sets
        #region Set Select List for Edit

        public SelectList SetInternalSubAssemblyBoardSelectList(BuildSheetsViewModel vm)
        {

            var internalSubAssebly = _context.InternalSubAssemblyBoards.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in internalSubAssebly)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name + " - " + "Rev " + item.Rev,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<InternalSubAssemblyBoardBuildSheet> relatedISABs = GetRelatedInternalSubAssemblyBoardbyBuildSheet(vm.Id);

            if (relatedISABs != null)
            {
                foreach (var relatedISAB in relatedISABs)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relatedISAB.InternalSubAssemblyBoardId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<InternalSubAssemblyBoardBuildSheet> GetRelatedInternalSubAssemblyBoardbyBuildSheet(int BuildSheetId)
        {
            return _context.InternalSubAssemblyBoardBuildSheets.Where(e => e.BuildSheetId == BuildSheetId);
        }

        public SelectList SetbaseBoardSelectList(BuildSheetsViewModel vm)
        {

            var baseBoards = _context.BaseBoards.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in baseBoards)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name + " - " + "Rev " + item.Rev,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<BaseBoardBuildSheet> relatedBaseBoards = GetRelatedBBByBS(vm.Id);

            if (relatedBaseBoards != null)
            {
                foreach (var relatedBaseBoard in relatedBaseBoards)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relatedBaseBoard.BaseBoardBuildSheetId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<BaseBoardBuildSheet> GetRelatedBBByBS(int BuildSheetId)
        {
            return _context.BaseBoardBuildSheets.Where(e => e.BuildSheetId == BuildSheetId);
        }

        public SelectList SetSubBoardSelectList(BuildSheetsViewModel vm)
        {

            var subBoards = _context.SubBoards.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in subBoards)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name + " - " + "Rev " + item.Rev,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<SubBoardBuildSheet> relatedSubBoards = GetRelatedSBByBS(vm.Id);

            if (relatedSubBoards != null)
            {
                foreach (var relatedSubBoard in relatedSubBoards)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relatedSubBoard.SubBoardBuildSheetId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<SubBoardBuildSheet> GetRelatedSBByBS(int BuildSheetId)
        {
            return _context.SubBoardBuildSheets.Where(e => e.BuildSheetId == BuildSheetId);
        }

        public SelectList SetHardwareList(BuildSheetsViewModel vm)
        {
            var hardwares = _context.Hardwares.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in hardwares)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name + " - " + item.Rev,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<HardwareBuildSheet> relatedHardwares = GetRelatedHardwareByBS(vm.Id);

            if (relatedHardwares != null)
            {
                foreach (var relatedHardware in relatedHardwares)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relatedHardware.HardwareId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<HardwareBuildSheet> GetRelatedHardwareByBS(int BuildSheetId)
        {
            return _context.HardwareBuildSheets.Where(e => e.BuildSheetId == BuildSheetId);
        }

        public SelectList SetInsertList(BuildSheetsViewModel vm)
        {
            List<Insert> inserts = _context.Inserts.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in inserts)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name + " - " + item.Rev,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<InsertBuildsheet> relatedInserts = GetRelatedInsertsByBS(vm.Id);

            if (relatedInserts != null)
            {
                foreach (var relatedInsert in relatedInserts)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relatedInsert.InsertId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<InsertBuildsheet> GetRelatedInsertsByBS(int BuildSheetId)
        {
            return _context.InsertBuildsheets.Where(e => e.BuildSheetId == BuildSheetId);
        }

        public SelectList SetLabelList(BuildSheetsViewModel vm)
        {
            List<Label> labels = _context.Labels.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in labels)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name + " - " + item.Rev,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<LabelBuildSheet> relatedLabels = GetRelatedLabelsByBS(vm.Id);

            if (relatedLabels != null)
            {
                foreach (var relatedLabel in relatedLabels)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relatedLabel.LabelId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<LabelBuildSheet> GetRelatedLabelsByBS(int BuildSheetId)
        {
            return _context.LabelBuildSheets.Where(e => e.BuildSheetId == BuildSheetId);
        }

        public SelectList SetPackagingList(BuildSheetsViewModel vm)
        {
            List<Packaging> packagings = _context.Packagings.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in packagings)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name + " - " + item.Rev,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<PackagingBuildSheet> relatedPackages = GetRelatedPackagingByBS(vm.Id);

            if (relatedPackages != null)
            {
                foreach (var relatedPackage in relatedPackages)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relatedPackage.PackagingId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<PackagingBuildSheet> GetRelatedPackagingByBS(int BuildSheetId)
        {
            return _context.PackagingBuildSheets.Where(e => e.BuildSheetId == BuildSheetId);
        }

        public SelectList SetDocumentList(BuildSheetsViewModel vm)
        {
            List<Document> documents = _context.Documents.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in documents)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name + " - " + item.Rev,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<DocumentBuildSheet> relateddocuments = GetRelatedDocumentByBS(vm.Id);

            if (relateddocuments != null)
            {
                foreach (var relateddocument in relateddocuments)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relateddocument.DocumentId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<DocumentBuildSheet> GetRelatedDocumentByBS(int BuildSheetId)
        {
            return _context.DocumentBuildSheets.Where(e => e.BuildSheetId == BuildSheetId);
        }

        public SelectList SetWIList(BuildSheetsViewModel vm)
        {
            List<WorkInstruction> workInstructions = _context.WorkInstructions.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in workInstructions)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name + " - " + item.Rev,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<WorkInstructionBuildSheet> relateWis = GetRelatedWIByBS(vm.Id);

            if (relateWis != null)
            {
                foreach (var relateWi in relateWis)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relateWi.WorkInstructionId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<WorkInstructionBuildSheet> GetRelatedWIByBS(int BuildSheetId)
        {
            return _context.WorkInstructionBuildSheets.Where(e => e.BuildSheetId == BuildSheetId);
        }

        public SelectList SetGeotabAssDrawingList(BuildSheetsViewModel vm)
        {
            List<GeotabAssemblyDrawing> geotabAssemblyDrawings = _context.GeotabAssemblyDrawings.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in geotabAssemblyDrawings)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name + " - " + item.Rev,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<GeotabAssemblyDrawingBuildSheet> relateGADs = GetRelatedGADByBS(vm.Id);

            if (relateGADs != null)
            {
                foreach (var relateGAD in relateGADs)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relateGAD.GeotabAssemblyDrawingId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<GeotabAssemblyDrawingBuildSheet> GetRelatedGADByBS(int BuildSheetId)
        {
            return _context.GeotabAssemblyDrawingBuildSheets.Where(e => e.BuildSheetId == BuildSheetId);
        }

        public SelectList SetCMDrawingList(BuildSheetsViewModel vm)
        {
            List<ContractManufactureAssemblyDrawing> contractManufactureAssemblyDrawings = _context.ContractManufactureAssemblyDrawings.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in contractManufactureAssemblyDrawings)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name + " - " + item.Rev,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<ContractManufactureAssemblyDrawingBuildSheet> relateCMADs = GetRelatedCMAByBS(vm.Id);

            if (relateCMADs != null)
            {
                foreach (var relateCMAD in relateCMADs)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relateCMAD.ContractManufactureAssemblyDrawingId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<ContractManufactureAssemblyDrawingBuildSheet> GetRelatedCMAByBS(int BuildSheetId)
        {
            return _context.ContractManufactureAssemblyDrawingBuildSheets.Where(e => e.BuildSheetId == BuildSheetId);
        }

        public SelectList SetTesterSoftwareList(BuildSheetsViewModel vm)
        {
            List<TesterSoftware> testerSoftwares = _context.TesterSoftwares.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in testerSoftwares)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.ProductCode + " - " + "Rev " + item.TesterVersion,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<TesterSoftwareBuildsheet> relateTesterSoftwares = GetRelatedTesterSoftwareByBS(vm.Id);

            if (relateTesterSoftwares != null)
            {
                foreach (var relateTesterSoftware in relateTesterSoftwares)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relateTesterSoftware.TesterSoftwareId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<TesterSoftwareBuildsheet> GetRelatedTesterSoftwareByBS(int BuildSheetId)
        {
            return _context.TesterSoftwareBuildsheets.Where(e => e.BuildSheetId == BuildSheetId);
        }


        public SelectList SetCLrequirementList(BuildSheetsViewModel vm)
        {
            List<CertificationLabelRequirement> certificationLabelRequirements = _context.CertificationLabelRequirements.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in certificationLabelRequirements)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.SideADescription + " - " + item.SideBDescription,
                    Value = item.Id.ToString(),
                });
            }
            SelectList ddl = new SelectList(items, "Value", "Text", null);
            IEnumerable<CertificationLabelRequirementBuildSheet> relateCLRequirements = GetRelatedCLrequirementByBS(vm.Id);

            if (relateCLRequirements != null)
            {
                foreach (var relateCLRequirement in relateCLRequirements)
                {
                    var a = ddl.GetEnumerator();
                    while (a.MoveNext())
                    {
                        if (Convert.ToInt64(a.Current.Value) == relateCLRequirement.CertificationLabelRequirementId)
                        {
                            a.Current.Selected = true;
                        }
                    }
                }
            }
            return ddl;
        }
        public IEnumerable<CertificationLabelRequirementBuildSheet> GetRelatedCLrequirementByBS(int BuildSheetId)
        {
            return _context.CertificationLabelRequirementBuildSheets.Where(e => e.BuildSheetId == BuildSheetId);
        }
        #endregion

        #region Set Middle Tables
        public List<InternalSubAssemblyBoardBuildSheet> SetInternalSubAssemblyBoard(List<int> InternalSubAssemblyBoardIds, int BuildSheetId)
        {
            List<InternalSubAssemblyBoardBuildSheet> returnList = new List<InternalSubAssemblyBoardBuildSheet>();
            if (InternalSubAssemblyBoardIds != null)
            {
                foreach (var InternalSubAssemblyBoardId in InternalSubAssemblyBoardIds)
                {
                    var internalSubAssemblyBoard = GetRecordByBsAndsubAssId(InternalSubAssemblyBoardId, BuildSheetId);
                    if (internalSubAssemblyBoard != null)
                    {
                        returnList.Add(internalSubAssemblyBoard);
                    }
                    else
                    {
                        InternalSubAssemblyBoardBuildSheet insab = new InternalSubAssemblyBoardBuildSheet()
                        {
                            BuildSheetId = BuildSheetId,
                            InternalSubAssemblyBoardId = InternalSubAssemblyBoardId
                        };
                        returnList.Add(insab);
                    }
                }
            }
            return returnList;
        }
        public InternalSubAssemblyBoardBuildSheet GetRecordByBsAndsubAssId(int InternalSubAssemblyBoardId, int BuildSheetId)
        {
            return _context.InternalSubAssemblyBoardBuildSheets.Where(e => e.InternalSubAssemblyBoardId == InternalSubAssemblyBoardId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }

        public List<BaseBoardBuildSheet> SetBaseBoard(List<int> BaseBoardIds, int BuildSheetId)
        {
            List<BaseBoardBuildSheet> returnList = new List<BaseBoardBuildSheet>();
            if (BaseBoardIds != null)
            {
                foreach (var baseBoardId in BaseBoardIds)
                {
                    var baseBoard = GetRecordByBsandBBId(baseBoardId, BuildSheetId);

                    if (baseBoard != null)
                    {
                        returnList.Add(baseBoard);
                    }
                    else
                    {
                        BaseBoardBuildSheet bb = new BaseBoardBuildSheet()
                        {
                            BuildSheetId = BuildSheetId,
                            BaseBoardBuildSheetId = baseBoardId
                        };
                        returnList.Add(bb);
                    }
                }
            }
            return returnList;
        }
        public BaseBoardBuildSheet GetRecordByBsandBBId(int BaseBoardId, int BuildSheetId)
        {
            return _context.BaseBoardBuildSheets.Where(e => e.BaseBoardBuildSheetId == BaseBoardId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }

        public List<SubBoardBuildSheet> SetSubBoard(List<int> SubBoardIds, int BuildSheetId)
        {
            List<SubBoardBuildSheet> returnList = new List<SubBoardBuildSheet>();
            if (SubBoardIds != null)
            {
                foreach (var subBoardId in SubBoardIds)
                {
                    var baseBoard = GetRecordByBsandSBId(subBoardId, BuildSheetId);

                    if (baseBoard != null)
                    {
                        returnList.Add(baseBoard);
                    }
                    else
                    {
                        SubBoardBuildSheet sb = new SubBoardBuildSheet()
                        {
                            BuildSheetId = BuildSheetId,
                            SubBoardBuildSheetId = subBoardId
                        };
                        returnList.Add(sb);
                    }
                }
            }
            return returnList;
        }
        public SubBoardBuildSheet GetRecordByBsandSBId(int subBoardId, int BuildSheetId)
        {
            return _context.SubBoardBuildSheets.Where(e => e.SubBoardBuildSheetId == subBoardId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }

        public List<HardwareBuildSheet> SetHardware(List<int> HardwaredIds, int BuildSheetId)
        {
            List<HardwareBuildSheet> returnList = new List<HardwareBuildSheet>();
            if (HardwaredIds != null)
            {
                foreach (var hardwareId in HardwaredIds)
                {
                    var hardware = GetRecordByBsandHWId(hardwareId, BuildSheetId);

                    if (hardware != null)
                    {
                        returnList.Add(hardware);
                    }
                    else
                    {
                        HardwareBuildSheet hb = new HardwareBuildSheet()
                        {
                            BuildSheetId = BuildSheetId,
                            HardwareId = hardwareId
                        };
                        returnList.Add(hb);
                    }
                }
            }
            return returnList;
        }
        public HardwareBuildSheet GetRecordByBsandHWId(int hardwareId, int BuildSheetId)
        {
            return _context.HardwareBuildSheets.Where(e => e.HardwareId == hardwareId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }

        public List<InsertBuildsheet> SetInsert(List<int> InsertIds, int BuildSheetId)
        {
            List<InsertBuildsheet> returnList = new List<InsertBuildsheet>();
            if (InsertIds != null)
            {
                foreach (var insertId in InsertIds)
                {
                    var insert = GetRecordByBsandInsertId(insertId, BuildSheetId);

                    if (insert != null)
                    {
                        returnList.Add(insert);
                    }
                    else
                    {
                        InsertBuildsheet hb = new InsertBuildsheet()
                        {
                            BuildSheetId = BuildSheetId,
                            InsertId = insertId
                        };
                        returnList.Add(hb);
                    }
                }
            }
            return returnList;
        }
        public InsertBuildsheet GetRecordByBsandInsertId(int insertId, int BuildSheetId)
        {
            return _context.InsertBuildsheets.Where(e => e.InsertId == insertId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }

        public List<LabelBuildSheet> SetLabel(List<int> LabelIds, int BuildSheetId)
        {
            List<LabelBuildSheet> returnList = new List<LabelBuildSheet>();
            if (LabelIds != null)
            {
                foreach (var labelId in LabelIds)
                {
                    var label = GetRecordByBsandLabelId(labelId, BuildSheetId);

                    if (label != null)
                    {
                        returnList.Add(label);
                    }
                    else
                    {
                        LabelBuildSheet hb = new LabelBuildSheet()
                        {
                            BuildSheetId = BuildSheetId,
                            LabelId = labelId
                        };
                        returnList.Add(hb);
                    }
                }
            }
            return returnList;
        }
        public LabelBuildSheet GetRecordByBsandLabelId(int labelId, int BuildSheetId)
        {
            return _context.LabelBuildSheets.Where(e => e.LabelId == labelId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }

        public List<PackagingBuildSheet> SetPackaging(List<int> PackagingIds, int BuildSheetId)
        {
            List<PackagingBuildSheet> returnList = new List<PackagingBuildSheet>();
            if (PackagingIds != null)
            {
                foreach (var packagingId in PackagingIds)
                {
                    var packaging = GetRecordByBsandPackagingId(packagingId, BuildSheetId);

                    if (packaging != null)
                    {
                        returnList.Add(packaging);
                    }
                    else
                    {
                        PackagingBuildSheet hb = new PackagingBuildSheet()
                        {
                            BuildSheetId = BuildSheetId,
                            PackagingId = packagingId
                        };
                        returnList.Add(hb);
                    }
                }
            }
            return returnList;
        }
        public PackagingBuildSheet GetRecordByBsandPackagingId(int packagingId, int BuildSheetId)
        {
            return _context.PackagingBuildSheets.Where(e => e.PackagingId == packagingId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }

        public List<DocumentBuildSheet> SetDocument(List<int> documentIds, int BuildSheetId)
        {
            List<DocumentBuildSheet> returnList = new List<DocumentBuildSheet>();
            if (documentIds != null)
            {
                foreach (var documentId in documentIds)
                {
                    var document = GetRecordByBsandDocumentId(documentId, BuildSheetId);

                    if (document != null)
                    {
                        returnList.Add(document);
                    }
                    else
                    {
                        DocumentBuildSheet hb = new DocumentBuildSheet()
                        {
                            BuildSheetId = BuildSheetId,
                            DocumentId = documentId
                        };
                        returnList.Add(hb);
                    }
                }
            }
            return returnList;
        }
        public DocumentBuildSheet GetRecordByBsandDocumentId(int documentId, int BuildSheetId)
        {
            return _context.DocumentBuildSheets.Where(e => e.DocumentId == documentId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }

        public List<WorkInstructionBuildSheet> SetWorkInstruction(List<int> workInsIds, int BuildSheetId)
        {
            List<WorkInstructionBuildSheet> returnList = new List<WorkInstructionBuildSheet>();
            if (workInsIds != null)
            {
                foreach (var workInsId in workInsIds)
                {
                    var workIns = GetRecordByBsandWorkInstructiontId(workInsId, BuildSheetId);

                    if (workIns != null)
                    {
                        returnList.Add(workIns);
                    }
                    else
                    {
                        WorkInstructionBuildSheet wi = new WorkInstructionBuildSheet()
                        {
                            BuildSheetId = BuildSheetId,
                            WorkInstructionId = workInsId
                        };
                        returnList.Add(wi);
                    }
                }
            }
            return returnList;
        }
        public WorkInstructionBuildSheet GetRecordByBsandWorkInstructiontId(int workInsId, int BuildSheetId)
        {
            return _context.WorkInstructionBuildSheets.Where(e => e.WorkInstructionId == workInsId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }

        public List<GeotabAssemblyDrawingBuildSheet> SetGeotabAssDrawing(List<int> drawingIds, int BuildSheetId)
        {
            List<GeotabAssemblyDrawingBuildSheet> returnList = new List<GeotabAssemblyDrawingBuildSheet>();
            if (drawingIds != null)
            {
                foreach (var drawingId in drawingIds)
                {
                    var drawing = GetRecordByBsandGeotabAssDrawingsId(drawingId, BuildSheetId);

                    if (drawing != null)
                    {
                        returnList.Add(drawing);
                    }
                    else
                    {
                        GeotabAssemblyDrawingBuildSheet dr = new GeotabAssemblyDrawingBuildSheet()
                        {
                            BuildSheetId = BuildSheetId,
                            GeotabAssemblyDrawingId = drawingId
                        };
                        returnList.Add(dr);
                    }
                }
            }
            return returnList;
        }
        public GeotabAssemblyDrawingBuildSheet GetRecordByBsandGeotabAssDrawingsId(int drawingId, int BuildSheetId)
        {
            return _context.GeotabAssemblyDrawingBuildSheets.Where(e => e.GeotabAssemblyDrawingId == drawingId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }

        public List<ContractManufactureAssemblyDrawingBuildSheet> SetContractAssDrawing(List<int> drawingIds, int BuildSheetId)
        {
            List<ContractManufactureAssemblyDrawingBuildSheet> returnList = new List<ContractManufactureAssemblyDrawingBuildSheet>();
            if (drawingIds != null)
            {
                foreach (var drawingId in drawingIds)
                {
                    var drawing = GetRecordByBsandContractAssDrawingsId(drawingId, BuildSheetId);

                    if (drawing != null)
                    {
                        returnList.Add(drawing);
                    }
                    else
                    {
                        ContractManufactureAssemblyDrawingBuildSheet dr = new ContractManufactureAssemblyDrawingBuildSheet()
                        {
                            BuildSheetId = BuildSheetId,
                            ContractManufactureAssemblyDrawingId = drawingId
                        };
                        returnList.Add(dr);
                    }
                }
            }
            return returnList;
        }
        public ContractManufactureAssemblyDrawingBuildSheet GetRecordByBsandContractAssDrawingsId(int drawingId, int BuildSheetId)
        {
            return _context.ContractManufactureAssemblyDrawingBuildSheets.Where(e => e.ContractManufactureAssemblyDrawingId == drawingId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }

        public List<TesterSoftwareBuildsheet> SetSoftware(List<int> softwareIds, int BuildSheetId)
        {
            List<TesterSoftwareBuildsheet> returnList = new List<TesterSoftwareBuildsheet>();
            if (softwareIds != null)
            {
                foreach (var softwareId in softwareIds)
                {
                    var software = GetRecordByBsandSoftwareId(softwareId, BuildSheetId);

                    if (software != null)
                    {
                        returnList.Add(software);
                    }
                    else
                    {
                        TesterSoftwareBuildsheet dr = new TesterSoftwareBuildsheet()
                        {
                            BuildSheetId = BuildSheetId,
                            TesterSoftwareId = softwareId
                        };
                        returnList.Add(dr);
                    }
                }
            }
            return returnList;
        }
        public TesterSoftwareBuildsheet GetRecordByBsandSoftwareId(int softwareId, int BuildSheetId)
        {
            return _context.TesterSoftwareBuildsheets.Where(e => e.TesterSoftwareId == softwareId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }

        public List<CertificationLabelRequirementBuildSheet> SetCertlableReq(List<int> certIds, int BuildSheetId)
        {
            List<CertificationLabelRequirementBuildSheet> returnList = new List<CertificationLabelRequirementBuildSheet>();
            if (certIds != null)
            {
                foreach (var certId in certIds)
                {
                    var certificate = GetRecordByBsandCertId(certId, BuildSheetId);

                    if (certificate != null)
                    {
                        returnList.Add(certificate);
                    }
                    else
                    {
                        CertificationLabelRequirementBuildSheet dr = new CertificationLabelRequirementBuildSheet()
                        {
                            BuildSheetId = BuildSheetId,
                            CertificationLabelRequirementId = certId
                        };
                        returnList.Add(dr);
                    }
                }
            }
            return returnList;
        }
        public CertificationLabelRequirementBuildSheet GetRecordByBsandCertId(int certId, int BuildSheetId)
        {
            return _context.CertificationLabelRequirementBuildSheets.Where(e => e.CertificationLabelRequirementId == certId && e.BuildSheetId == BuildSheetId).FirstOrDefault();
        }
        #endregion

        #region Set ViewModel
        public BuildSheetsViewModel setViewModel()
        {
            BuildSheetsViewModel vm = new BuildSheetsViewModel();

            var internalSubAssemblyBoardList = _context.InternalSubAssemblyBoards.ToList();
            List<SelectListItem> isabs = new List<SelectListItem>();
            for (int i = 0; i < internalSubAssemblyBoardList.Count; i++)
            {
                InternalSubAssemblyBoard isab = internalSubAssemblyBoardList[i];

                isabs.Add(new SelectListItem
                {
                    Text = isab.Name + " - " + "Rev " + isab.Rev,
                    Value = isab.Id.ToString(),
                    //Group = new SelectListGroup {Name = "Internal Sub Assembly"}
                });
            }
            vm.InternalSubAssemblyBoardList = new SelectList(isabs, "Value", "Text", -1);

            var baseBoardList = _context.BaseBoards.ToList();
            List<SelectListItem> baseBoards = new List<SelectListItem>();
            for (int i = 0; i < baseBoardList.Count; i++)
            {
                BaseBoard bb = baseBoardList[i];

                baseBoards.Add(new SelectListItem
                {
                    Text = bb.Name + " - " + "Rev " + bb.Rev,
                    Value = bb.Id.ToString(),
                    //Group = new SelectListGroup { Name = "Base Board" }
                });
            }
            //vm.BaseBoardList = new SelectList(baseBoards, "Value", "Text", -1, "Group.Name");
            vm.BaseBoardList = new SelectList(baseBoards, "Value", "Text", -1);

            var subBoardList = _context.BaseBoards.ToList();
            List<SelectListItem> subBoards = new List<SelectListItem>();
            for (int i = 0; i < subBoardList.Count; i++)
            {
                BaseBoard sb = subBoardList[i];

                subBoards.Add(new SelectListItem
                {
                    Text = sb.Name + " - " + "Rev " + sb.Rev,
                    Value = sb.Id.ToString(),
                    //Group = new SelectListGroup { Name = "Sub Board" }
                });
            }
            vm.SubBoardList = new SelectList(subBoards, "Value", "Text", -1);

            var otherHardwareList = _context.Hardwares.ToList();
            List<SelectListItem> otherHardwars = new List<SelectListItem>();
            for (int i = 0; i < otherHardwareList.Count; i++)
            {
                Hardware hw = otherHardwareList[i];

                otherHardwars.Add(new SelectListItem
                {
                    Text = hw.Name + " - " + "Rev " + hw.Rev,
                    Value = hw.Id.ToString(),
                    //Group = new SelectListGroup { Name = "Sub Board" }
                });
            }
            vm.OtherHardwareList = new SelectList(otherHardwars, "Value", "Text", -1);


            var insertList = _context.Inserts.ToList();
            List<SelectListItem> inserts = new List<SelectListItem>();
            for (int i = 0; i < insertList.Count; i++)
            {
                Insert ins = insertList[i];

                inserts.Add(new SelectListItem
                {
                    Text = ins.Name + " - " + "Rev " + ins.Rev,
                    Value = ins.Id.ToString(),
                    //Group = new SelectListGroup { Name = "Sub Board" }
                });
            }
            vm.InsertList = new SelectList(inserts, "Value", "Text", -1);


            var labelList = _context.Labels.ToList();
            List<SelectListItem> labels = new List<SelectListItem>();
            for (int i = 0; i < labelList.Count; i++)
            {
                Label ins = labelList[i];

                labels.Add(new SelectListItem
                {
                    Text = ins.Name + " - " + "Rev " + ins.Rev,
                    Value = ins.Id.ToString(),
                    //Group = new SelectListGroup { Name = "Sub Board" }
                });
            }
            vm.LabelList = new SelectList(labels, "Value", "Text", -1);


            var packagingList = _context.Packagings.ToList();
            List<SelectListItem> packagings = new List<SelectListItem>();
            for (int i = 0; i < packagingList.Count; i++)
            {
                Packaging pak = packagingList[i];

                packagings.Add(new SelectListItem
                {
                    Text = pak.Name + " - " + "Rev " + pak.Rev,
                    Value = pak.Id.ToString(),
                    //Group = new SelectListGroup { Name = "Sub Board" }
                });
            }
            vm.PackagingList = new SelectList(packagings, "Value", "Text", -1);

            var documentList = _context.Documents.ToList();
            List<SelectListItem> documents = new List<SelectListItem>();
            for (int i = 0; i < documentList.Count; i++)
            {
                Document d = documentList[i];

                documents.Add(new SelectListItem
                {
                    Text = d.Name + " - " + "Rev " + d.Rev,
                    Value = d.Id.ToString(),
                    //Group = new SelectListGroup { Name = "Support Document" }
                });
            }
            vm.DocumentList = new SelectList(documents, "Value", "Text", -1);

            var workInstructionList = _context.WorkInstructions.ToList();
            List<SelectListItem> workInstructions = new List<SelectListItem>();

            for (int i = 0; i < workInstructionList.Count; i++)
            {
                WorkInstruction wi = workInstructionList[i];

                workInstructions.Add(new SelectListItem
                {
                    Text = wi.Name + " - " + "Rev " + wi.Rev,
                    Value = wi.Id.ToString(),
                    //Group = new SelectListGroup { Name = "Work Instructions" }
                });
            }
            vm.WorkInstructionList = new SelectList(workInstructions, "Value", "Text", -1);

            var geotabAssemblyDrawingList = _context.GeotabAssemblyDrawings.ToList();
            List<SelectListItem> geotabAssemblyDrawings = new List<SelectListItem>();

            for (int i = 0; i < geotabAssemblyDrawingList.Count; i++)
            {
                GeotabAssemblyDrawing gad = geotabAssemblyDrawingList[i];

                geotabAssemblyDrawings.Add(new SelectListItem
                {
                    Text = gad.Name + " - " + "Rev " + gad.Rev,
                    Value = gad.Id.ToString(),
                    //Group = new SelectListGroup { Name = "Geotab Assembly Drawings" }
                });
            }
            vm.GeotabAssemblyDrawingList = new SelectList(geotabAssemblyDrawings, "Value", "Text", -1);

            var contractManufactureAssemblyDrawingsList = _context.ContractManufactureAssemblyDrawings.ToList();
            List<SelectListItem> contractManufactureAssemblyDrawings = new List<SelectListItem>();

            for (int i = 0; i < contractManufactureAssemblyDrawingsList.Count; i++)
            {
                ContractManufactureAssemblyDrawing camd = contractManufactureAssemblyDrawingsList[i];

                contractManufactureAssemblyDrawings.Add(new SelectListItem
                {
                    Text = camd.Name + " - " + "Rev " + camd.Rev,
                    Value = camd.Id.ToString(),
                    //Group = new SelectListGroup { Name = "Contract Manufacture AssemblyDrawing" }
                });
            }
            vm.ContractManufactureAssemblyDrawingList = new SelectList(contractManufactureAssemblyDrawings, "Value", "Text", -1);

            var testerSoftwaresList = _context.TesterSoftwares.ToList();
            List<SelectListItem> testerSoftwares = new List<SelectListItem>();

            for (int i = 0; i < testerSoftwaresList.Count; i++)
            {
                TesterSoftware ts = testerSoftwaresList[i];

                testerSoftwares.Add(new SelectListItem
                {
                    Text = ts.ProductCode + " - " + "Rev " + ts.TesterVersion,
                    Value = ts.Id.ToString(),
                    //Group = new SelectListGroup { Name = "Tester Softwares" }
                });
            }
            vm.TesterSoftwareList = new SelectList(testerSoftwares, "Value", "Text", -1);

            var certificationLabelRequirementList = _context.CertificationLabelRequirements.ToList();
            List<SelectListItem> certificationLabelRequirements = new List<SelectListItem>();

            for (int i = 0; i < certificationLabelRequirementList.Count; i++)
            {
                CertificationLabelRequirement clr = certificationLabelRequirementList[i];

                certificationLabelRequirements.Add(new SelectListItem
                {
                    Text = clr.SideADescription + " - " + clr.SideBDescription,
                    Value = clr.Id.ToString(),
                    //Group = new SelectListGroup { Name = "Certification Label Requirement" }
                });
            }
            vm.CertificationLabelRequirementList = new SelectList(certificationLabelRequirements, "Value", "Text", -1);

            return (vm);
        }
        #endregion
        #endregion

        // GET: BuildSheetsArea/BuildSheets
        public IActionResult Index(string name)
        {
            var buildSheet = buildSheetsRepository.Main(name);
            if (!string.IsNullOrWhiteSpace(name) && buildSheet == null)
            {
                ViewBag.ErrorMessage = "No Result found";
                return View(buildSheet);
            }
            else
            {
                ViewBag.SearchString = name;
                return View(buildSheet);
            }
        }
        public IActionResult Details(int? Id)
        {
            var details = buildSheetsRepository.Details(Id);
            //BuildSheetsViewModel vm = new BuildSheetsViewModel();
            //vm = details;
            return View(details);
        }


        // GET: BuildSheetsArea/BuildSheets/Create
        public IActionResult Create()
        {
            ViewData["loggedInUser"] = GetLoggedInUsername();
            BuildSheetsViewModel vm = setViewModel();
            return View(vm);
        }

        // POST: BuildSheetsArea/BuildSheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BuildSheetsViewModel Vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BuildSheet NewBs = new BuildSheet(Vm);
                    _context.Add(NewBs);
                    await _context.SaveChangesAsync();


                    int buildSheetId = NewBs.Id;

                    if (Vm.InternalSubAssemblyBoardId != null)
                    {
                        List<InternalSubAssemblyBoardBuildSheet> internalSubAssemblyBoardBuildSheet = SetInternalSubAssemblyBoard(Vm.InternalSubAssemblyBoardId, buildSheetId);
                        NewBs.BuildSheetsInternalSubAssemblyBoard = internalSubAssemblyBoardBuildSheet.ToList();
                    }
                    if (Vm.BaseBoardId != null)
                    {
                        List<BaseBoardBuildSheet> baseBoardBuildSheet = SetBaseBoard(Vm.BaseBoardId, buildSheetId);
                        NewBs.BaseBoards = baseBoardBuildSheet;
                    }
                    if (Vm.SubBoardId != null)
                    {
                        List<SubBoardBuildSheet> subBoardBuildSheet = SetSubBoard(Vm.SubBoardId, buildSheetId);
                        NewBs.SubBoards = subBoardBuildSheet;
                    }
                    if (Vm.OtherHardwareIds != null)
                    {
                        List<HardwareBuildSheet> hardwareBuildSheet = SetHardware(Vm.OtherHardwareIds, buildSheetId);
                        NewBs.OtherHardwares = hardwareBuildSheet;
                    }
                    if (Vm.InsertIds != null)
                    {
                        List<InsertBuildsheet> insertBuildsheet = SetInsert(Vm.InsertIds, buildSheetId);
                        NewBs.Inserts = insertBuildsheet;
                    }
                    if (Vm.LabelIds != null)
                    {
                        List<LabelBuildSheet> labelBuildSheet = SetLabel(Vm.LabelIds, buildSheetId);
                        NewBs.Labels = labelBuildSheet;
                    }
                    if (Vm.PackagingIds != null)
                    {
                        List<PackagingBuildSheet> packagingBuildSheet = SetPackaging(Vm.PackagingIds, buildSheetId);
                        NewBs.Packagings = packagingBuildSheet;
                    }
                    if (Vm.DocumentIds != null)
                    {
                        List<DocumentBuildSheet> documentBuildSheet = SetDocument(Vm.DocumentIds, buildSheetId);
                        NewBs.Documents = documentBuildSheet;
                    }
                    if (Vm.WorkInstructionIds != null)
                    {
                        List<WorkInstructionBuildSheet> workInstructionBuildSheet = SetWorkInstruction(Vm.WorkInstructionIds, buildSheetId);
                        NewBs.WorkInstructions = workInstructionBuildSheet;
                    }
                    if (Vm.GeotabAssemblyDrawingIds != null)
                    {
                        List<GeotabAssemblyDrawingBuildSheet> geotabAssemblyDrawingBuildSheet = SetGeotabAssDrawing(Vm.GeotabAssemblyDrawingIds, buildSheetId);
                        NewBs.GeotabAssemblyDrawings = geotabAssemblyDrawingBuildSheet;
                    }
                    if (Vm.ContractManufactureAssemblyDrawingIds != null)
                    {
                        List<ContractManufactureAssemblyDrawingBuildSheet> contractManufactureAssemblyDrawingBuildSheet = SetContractAssDrawing(Vm.ContractManufactureAssemblyDrawingIds, buildSheetId);
                        NewBs.ContractManufactureAssemblyDrawings = contractManufactureAssemblyDrawingBuildSheet;
                    }
                    if (Vm.TesterSoftwareIds != null)
                    {
                        List<TesterSoftwareBuildsheet> testerSoftwareBuildsheet = SetSoftware(Vm.TesterSoftwareIds, buildSheetId);
                        NewBs.TesterSoftwares = testerSoftwareBuildsheet;
                    }
                    if (Vm.CertificationLabelRequirementIds != null)
                    {
                        List<CertificationLabelRequirementBuildSheet> certificationLabelRequirementBuildSheet = SetCertlableReq(Vm.CertificationLabelRequirementIds, buildSheetId);
                        NewBs.CertificationLabelRequirements = certificationLabelRequirementBuildSheet;
                    }

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: BuildSheetsArea/BuildSheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildSheet = _context.BuildSheets
                .Include(b => b.BuildSheetsInternalSubAssemblyBoard).ThenInclude(bb => bb.InternalSubAssemblyBoard)
                .Include(bb => bb.BaseBoards).ThenInclude(bb => bb.BaseBoard)
                .Include(sb => sb.SubBoards).ThenInclude(sb => sb.SubBoard)
                .Include(b => b.OtherHardwares).ThenInclude(hw => hw.Hardware)
                .Include(b => b.Inserts).ThenInclude(hw => hw.Insert)
                .Include(l => l.Labels).ThenInclude(l => l.Label)
                .Include(p => p.Packagings).ThenInclude(p => p.Packaging)
                .Include(sd => sd.Documents).ThenInclude(d => d.Document)
                .Include(wi => wi.WorkInstructions).ThenInclude(d => d.WorkInstruction)
                .Include(ad => ad.GeotabAssemblyDrawings).ThenInclude(d => d.GeotabAssemblyDrawing)
                .Include(cm => cm.ContractManufactureAssemblyDrawings).ThenInclude(cm => cm.ContractManufactureAssemblyDrawing)
                .Include(ts => ts.TesterSoftwares).ThenInclude(ts => ts.TesterSoftware)
                .Include(clr => clr.CertificationLabelRequirements).ThenInclude(clr => clr.CertificationLabelRequirement)
                .FirstOrDefault(b => b.Id == id);

            if (buildSheet == null)
            {
                return NotFound();
            }

            BuildSheetsViewModel vm = new BuildSheetsViewModel(buildSheet);

            vm.InternalSubAssemblyBoardList = SetInternalSubAssemblyBoardSelectList(vm);
            vm.BaseBoardList = SetbaseBoardSelectList(vm);
            vm.SubBoardList = SetSubBoardSelectList(vm);
            vm.OtherHardwareList = SetHardwareList(vm);
            vm.InsertList = SetInsertList(vm);
            vm.LabelList = SetLabelList(vm);
            vm.PackagingList = SetPackagingList(vm);
            vm.DocumentList = SetDocumentList(vm);
            vm.WorkInstructionList = SetWIList(vm);
            vm.GeotabAssemblyDrawingList = SetGeotabAssDrawingList(vm);
            vm.ContractManufactureAssemblyDrawingList = SetCMDrawingList(vm);
            vm.TesterSoftwareList = SetTesterSoftwareList(vm);
            vm.CertificationLabelRequirementList = SetCLrequirementList(vm);


            return View(vm);
        }

        // POST: BuildSheetsArea/BuildSheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BuildSheetsViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var existingBuildSheet = _context.BuildSheets
                       .Include(b => b.BuildSheetsInternalSubAssemblyBoard).ThenInclude(bb => bb.InternalSubAssemblyBoard)
                       .Include(bb => bb.BaseBoards).ThenInclude(bb => bb.BaseBoard)
                       .Include(sb => sb.SubBoards).ThenInclude(sb => sb.SubBoard)
                       .Include(b => b.OtherHardwares).ThenInclude(hw => hw.Hardware)
                       .Include(b => b.Inserts).ThenInclude(hw => hw.Insert)
                       .Include(l => l.Labels).ThenInclude(l => l.Label)
                       .Include(p => p.Packagings).ThenInclude(p => p.Packaging)
                       .Include(sd => sd.Documents).ThenInclude(d => d.Document)
                       .Include(wi => wi.WorkInstructions).ThenInclude(d => d.WorkInstruction)
                       .Include(ad => ad.GeotabAssemblyDrawings).ThenInclude(d => d.GeotabAssemblyDrawing)
                       .Include(cm => cm.ContractManufactureAssemblyDrawings).ThenInclude(cm => cm.ContractManufactureAssemblyDrawing)
                       .Include(ts => ts.TesterSoftwares).ThenInclude(ts => ts.TesterSoftware)
                       .Include(clr => clr.CertificationLabelRequirements).ThenInclude(clr => clr.CertificationLabelRequirement)
                       .FirstOrDefault(b => b.Id == id);


                    existingBuildSheet.Id = vm.Id;
                    existingBuildSheet.ProductName = vm.ProductName;
                    existingBuildSheet.Description = vm.Description;
                    existingBuildSheet.APN = vm.APN;
                    existingBuildSheet.CustomerGateway = vm.CustomerGateway;
                    existingBuildSheet.UpdatedBy = vm.UpdatedBy;
                    existingBuildSheet.ProductUpdatedOn = vm.ProductUpdatedOn;
                    existingBuildSheet.ECOId = vm.ECOId;
                    existingBuildSheet.ProductLaunchDate = vm.ProductLaunchDate;
                    existingBuildSheet.ProductOwner = vm.ProductOwner;
                    existingBuildSheet.ProductStatus = vm.ProductStatus;
                    existingBuildSheet.ProvisioningPackage = vm.ProvisioningPackage;
                    existingBuildSheet.Revision = vm.Revision;
                    existingBuildSheet.RevisionURL = vm.RevisionURL;
                    existingBuildSheet.ProductImageURL = vm.ProductImageURL;
                    existingBuildSheet.BuildSheetsInternalSubAssemblyBoard = SetInternalSubAssemblyBoard(vm.InternalSubAssemblyBoardId, existingBuildSheet.Id);
                    existingBuildSheet.BaseBoards = SetBaseBoard(vm.BaseBoardId, existingBuildSheet.Id);
                    existingBuildSheet.SubBoards = SetSubBoard(vm.SubBoardId, existingBuildSheet.Id);
                    existingBuildSheet.OtherHardwares = SetHardware(vm.OtherHardwareIds, existingBuildSheet.Id);
                    existingBuildSheet.Inserts = SetInsert(vm.InsertIds, existingBuildSheet.Id);
                    existingBuildSheet.Labels = SetLabel(vm.LabelIds, existingBuildSheet.Id);
                    existingBuildSheet.Packagings = SetPackaging(vm.PackagingIds, existingBuildSheet.Id);
                    existingBuildSheet.Documents = SetDocument(vm.DocumentIds, existingBuildSheet.Id);
                    existingBuildSheet.WorkInstructions = SetWorkInstruction(vm.WorkInstructionIds, existingBuildSheet.Id);
                    existingBuildSheet.GeotabAssemblyDrawings = SetGeotabAssDrawing(vm.GeotabAssemblyDrawingIds, existingBuildSheet.Id);
                    existingBuildSheet.ContractManufactureAssemblyDrawings = SetContractAssDrawing(vm.ContractManufactureAssemblyDrawingIds, existingBuildSheet.Id);
                    existingBuildSheet.TesterSoftwares = SetSoftware(vm.TesterSoftwareIds, existingBuildSheet.Id);
                    existingBuildSheet.CertificationLabelRequirements = SetCertlableReq(vm.CertificationLabelRequirementIds, existingBuildSheet.Id);

                    _context.Update(existingBuildSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            }
            return RedirectToAction("Details", new { id = id });
        }

        // GET: BuildSheetsArea/BuildSheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildSheet = await _context.BuildSheets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildSheet == null)
            {
                return NotFound();
            }

            return View(buildSheet);
        }

        // POST: BuildSheetsArea/BuildSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildSheet = await _context.BuildSheets.FindAsync(id);
            _context.BuildSheets.Remove(buildSheet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildSheetExists(int id)
        {
            return _context.BuildSheets.Any(e => e.Id == id);
        }
    }
}
