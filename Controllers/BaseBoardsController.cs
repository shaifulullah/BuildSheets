using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildSheets.Data;
using BuildSheets.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildSheets.Controllers
{
    public class BaseBoardsController : Controller
    {
        private BuildSheetsDBContext _context;

        public BaseBoardsController(BuildSheetsDBContext context)
        {
            _context = context;
        }
        public IActionResult Main()
        {
            List<BaseBoard> baeBoards = _context.BaseBoards.ToList();
            return View(baeBoards);
        }

        public IActionResult Create()
        {
            List<BaseBoard> baseBoards = new List<BaseBoard>();
            return View(baseBoards);
        }

        public JsonResult InsertBaseBoards([FromBody] List<BaseBoard> baseBoards)
        {
            if (baseBoards == null)
            {
                baseBoards = new List<BaseBoard>();
            }

            //Loop and insert records.
            foreach (BaseBoard baseBoard in baseBoards)
            {
                _context.BaseBoards.Add(baseBoard);
            }

            int insertedRecords = _context.SaveChanges();
            return Json(insertedRecords);
        }
    }
}