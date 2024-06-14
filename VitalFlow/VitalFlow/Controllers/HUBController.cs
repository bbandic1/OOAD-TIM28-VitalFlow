using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using VitalFlow.Data;
using VitalFlow.Models;

namespace VitalFlow.Controllers
{
    [Authorize]
    public class HUBController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HUBController> _logger;

        public HUBController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<HUBController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
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

        // GET: HUB/CreateTermin
        public IActionResult getCreateTermin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTermin(Sale Sala, DateOnly Datum, string Vrijeme)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Pokrenuta akcija CreateTermin.");

                var user = await _userManager.GetUserAsync(User);


                if (user == null)
                {
                    _logger.LogError("Korisnik nije logovan.");
                    return RedirectToAction("Login", "Account");
                }

                var termin = new Termin
                {
                    datum = Datum,
                    vrijeme = Vrijeme,
                    sala = Sala,
                    donorID = user.Id,
                    email = user.Email,
                    jmbg = ""
                };

                _context.Add(termin);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Novi termin je uspješno kreiran (ID: {termin.terminID}).");


                _logger.LogInformation("Završena akcija CreateTermin.");

                return RedirectToAction(nameof(Index));
            }

            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    _logger.LogError($"ModelState greška: {error.ErrorMessage}");
                }
            }
            
            _logger.LogError("ModelState nije validan.");

            return View("Index", await _context.Hub.ToListAsync());
        }


        private bool HUBExists(int id)
        {
            return _context.Hub.Any(e => e.hubID == id);
        }
    }
}
