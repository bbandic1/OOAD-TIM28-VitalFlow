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
    public class HUBController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HUBController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HUB
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hub.ToListAsync());
        }

        // GET: HUB/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hUB = await _context.Hub
                .FirstOrDefaultAsync(m => m.hubID == id);
            if (hUB == null)
            {
                return NotFound();
            }

            return View(hUB);
        }

        // GET: HUB/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HUB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("terminID,zahtjevID,hubID")] HUB hUB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hUB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hUB);
        }

        // GET: HUB/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hUB = await _context.Hub.FindAsync(id);
            if (hUB == null)
            {
                return NotFound();
            }
            return View(hUB);
        }

        // POST: HUB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("terminID,zahtjevID,hubID")] HUB hUB)
        {
            if (id != hUB.hubID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hUB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HUBExists(hUB.hubID))
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
            return View(hUB);
        }

        // GET: HUB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hUB = await _context.Hub
                .FirstOrDefaultAsync(m => m.hubID == id);
            if (hUB == null)
            {
                return NotFound();
            }

            return View(hUB);
        }

        // POST: HUB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hUB = await _context.Hub.FindAsync(id);
            if (hUB != null)
            {
                _context.Hub.Remove(hUB);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HUBExists(int id)
        {
            return _context.Hub.Any(e => e.hubID == id);
        }
    }
}
