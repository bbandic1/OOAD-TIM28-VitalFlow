using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VitalFlow.Data;
using VitalFlow.Models;

namespace VitalFlow.Controllers
{
    public class ZalihaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZalihaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zaliha
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zaliha.ToListAsync());
        }

        // GET: Zaliha/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaliha = await _context.Zaliha
                .FirstOrDefaultAsync(m => m.hubID == id);
            if (zaliha == null)
            {
                return NotFound();
            }

            return View(zaliha);
        }

        // GET: Zaliha/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zaliha/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("krvnaGrupa,kolicina,kriticnaLinija,hubID")] Zaliha zaliha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zaliha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zaliha);
        }

        // GET: Zaliha/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaliha = await _context.Zaliha.FindAsync(id);
            if (zaliha == null)
            {
                return NotFound();
            }
            return View(zaliha);
        }

        // POST: Zaliha/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("krvnaGrupa,kolicina,kriticnaLinija,hubID")] Zaliha zaliha)
        {
            if (id != zaliha.hubID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zaliha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZalihaExists(zaliha.hubID))
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
            return View(zaliha);
        }

        // GET: Zaliha/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaliha = await _context.Zaliha
                .FirstOrDefaultAsync(m => m.hubID == id);
            if (zaliha == null)
            {
                return NotFound();
            }

            return View(zaliha);
        }

        // POST: Zaliha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zaliha = await _context.Zaliha.FindAsync(id);
            if (zaliha != null)
            {
                _context.Zaliha.Remove(zaliha);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZalihaExists(int id)
        {
            return _context.Zaliha.Any(e => e.hubID == id);
        }
    }
}
