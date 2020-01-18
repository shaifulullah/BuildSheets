using BuildSheets.Data;
using BuildSheets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Controllers
{
    public class BuildSheetsController : Controller
    {
        private readonly BuildSheetsDBContext _context;

        public BuildSheetsController(BuildSheetsDBContext context)
        {
            _context = context;
        }

        // GET: BuildSheetsArea/BuildSheets
        public async Task<IActionResult> Index()
        {
            return View(await _context.BuildSheets.ToListAsync());
        }

        // GET: BuildSheetsArea/BuildSheets/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: BuildSheetsArea/BuildSheets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuildSheetsArea/BuildSheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,APN,CustomerGateway")] BuildSheet buildSheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildSheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildSheet);
        }

        // GET: BuildSheetsArea/BuildSheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildSheet = await _context.BuildSheets.FindAsync(id);
            if (buildSheet == null)
            {
                return NotFound();
            }
            return View(buildSheet);
        }

        // POST: BuildSheetsArea/BuildSheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,APN,CustomerGateway")] BuildSheet buildSheet)
        {
            if (id != buildSheet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildSheetExists(buildSheet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(buildSheet);
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
