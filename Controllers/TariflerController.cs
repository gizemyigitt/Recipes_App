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
    public class TariflerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TariflerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tarifler
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tarifler.Include(t => t.Kategori).Include(t => t.Tatli);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tarifler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifler = await _context.Tarifler
                .Include(t => t.Kategori)
                .Include(t => t.Tatli)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarifler == null)
            {
                return NotFound();
            }

            return View(tarifler);
        }

        // GET: Tarifler/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAd");
            ViewData["TatliId"] = new SelectList(_context.Tatli, "Id", "Ad");
            return View();
        }

        // POST: Tarifler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KategoriId,TatliId")] Tarifler tarifler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarifler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAd", tarifler.KategoriId);
            ViewData["TatliId"] = new SelectList(_context.Tatli, "Id", "Ad", tarifler.TatliId);
            return View(tarifler);
        }

        // GET: Tarifler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifler = await _context.Tarifler.FindAsync(id);
            if (tarifler == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAd", tarifler.KategoriId);
            ViewData["TatliId"] = new SelectList(_context.Tatli, "Id", "Ad", tarifler.TatliId);
            return View(tarifler);
        }

        // POST: Tarifler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KategoriId,TatliId")] Tarifler tarifler)
        {
            if (id != tarifler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarifler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TariflerExists(tarifler.Id))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAd", tarifler.KategoriId);
            ViewData["TatliId"] = new SelectList(_context.Tatli, "Ad", "Ad", tarifler.TatliId);
            return View(tarifler);
        }

        // GET: Tarifler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifler = await _context.Tarifler
                .Include(t => t.Kategori)
                .Include(t => t.Tatli)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarifler == null)
            {
                return NotFound();
            }

            return View(tarifler);
        }

        // POST: Tarifler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarifler = await _context.Tarifler.FindAsync(id);
            _context.Tarifler.Remove(tarifler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TariflerExists(int id)
        {
            return _context.Tarifler.Any(e => e.Id == id);
        }
    }
}
