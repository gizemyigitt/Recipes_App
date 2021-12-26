using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSite.Data;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class TatliMalzemeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TatliMalzemeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TatliMalzeme
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TatliMalzeme.Include(t => t.Malzeme).Include(t => t.Tatli);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TatliMalzeme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatliMalzeme = await _context.TatliMalzeme
                .Include(t => t.Malzeme)
                .Include(t => t.Tatli)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tatliMalzeme == null)
            {
                return NotFound();
            }

            return View(tatliMalzeme);
        }

        // GET: TatliMalzeme/Create
        public IActionResult Create()
        {
            ViewData["MalzemeId"] = new SelectList(_context.Malzeme, "Id", "Ad");
            ViewData["TatliId"] = new SelectList(_context.Tatli, "Id", "Ad");
            return View();
        }

        // POST: TatliMalzeme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TatliId,MalzemeId")] TatliMalzeme tatliMalzeme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tatliMalzeme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MalzemeId"] = new SelectList(_context.Malzeme, "Id", "Ad", tatliMalzeme.MalzemeId);
            ViewData["TatliId"] = new SelectList(_context.Tatli, "Id", "Ad", tatliMalzeme.TatliId);
            return View(tatliMalzeme);
        }

        // GET: TatliMalzeme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatliMalzeme = await _context.TatliMalzeme.FindAsync(id);
            if (tatliMalzeme == null)
            {
                return NotFound();
            }
            ViewData["MalzemeId"] = new SelectList(_context.Malzeme, "Id", "Ad", tatliMalzeme.MalzemeId);
            ViewData["TatliId"] = new SelectList(_context.Tatli, "Id", "Ad", tatliMalzeme.TatliId);
            return View(tatliMalzeme);
        }

        // POST: TatliMalzeme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TatliId,MalzemeId")] TatliMalzeme tatliMalzeme)
        {
            if (id != tatliMalzeme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tatliMalzeme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TatliMalzemeExists(tatliMalzeme.Id))
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
            ViewData["MalzemeId"] = new SelectList(_context.Malzeme, "Id", "Ad", tatliMalzeme.MalzemeId);
            ViewData["TatliId"] = new SelectList(_context.Tatli, "Id", "Ad", tatliMalzeme.TatliId);
            return View(tatliMalzeme);
        }

        // GET: TatliMalzeme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatliMalzeme = await _context.TatliMalzeme
                .Include(t => t.Malzeme)
                .Include(t => t.Tatli)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tatliMalzeme == null)
            {
                return NotFound();
            }

            return View(tatliMalzeme);
        }

        // POST: TatliMalzeme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tatliMalzeme = await _context.TatliMalzeme.FindAsync(id);
            _context.TatliMalzeme.Remove(tatliMalzeme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TatliMalzemeExists(int id)
        {
            return _context.TatliMalzeme.Any(e => e.Id == id);
        }
    }
}
