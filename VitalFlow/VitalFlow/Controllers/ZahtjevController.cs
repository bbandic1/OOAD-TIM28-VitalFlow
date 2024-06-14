using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VitalFlow.Data;
using VitalFlow.Models;

namespace VitalFlow.Controllers
{
    public class ZahtjevController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HUBController> _logger;

        public ZahtjevController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<HUBController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }


        // GET: Zahtjev
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zahtjev.ToListAsync());
        }

        // GET: Zahtjev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjev = await _context.Zahtjev
                .FirstOrDefaultAsync(m => m.zahtjevID == id);
            if (zahtjev == null)
            {
                return NotFound();
            }

            return View(zahtjev);
        }

        // GET: Zahtjev/Create
        public IActionResult Create()
        {
            ViewBag.KrvnaGrupa = new SelectList(Enum.GetValues(typeof(KrvnaGrupa))
                                         .Cast<KrvnaGrupa>()
                                         .Select(e => new SelectListItem
                                         {
                                             Value = e.ToString(),
                                             Text = EnumExtensions.GetDisplayName(e) // Koristimo GetDisplayName metodu da bismo dobili tekstualnu vrednost
                                         }), "Value", "Text");

            return View();
        }

        // POST: Zahtjev/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("zahtjevID,kolicina,email,opis,krvnaGrupa")] Zahtjev zahtjev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zahtjev);
                // await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Create));
                // _context.Add(zahtjev);
                await _context.SaveChangesAsync();

                // Send email notification to clinic
                string subject = "New Blood Request";
                string body = $"A new blood request has been submitted for blood type: {zahtjev.krvnaGrupa}. Please review the details in your email inbox.";

                await SendEmail(zahtjev.email, subject, body);

                return RedirectToAction(nameof(Create));

            }
            ViewBag.KrvnaGrupa = new SelectList(Enum.GetValues(typeof(KrvnaGrupa)).Cast<KrvnaGrupa>());
            return View(zahtjev);
        }

        private async Task SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                string fromEmail = "VitalFlow2024@gmail.com";
                string appPassword = "rlhl dgtp gbdn filq"; 

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(fromEmail, appPassword),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);

                _logger.LogInformation($"Email sent successfully to: {toEmail}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending email: {ex.Message}");
            }
        }

        // GET: Zahtjev/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjev = await _context.Zahtjev.FindAsync(id);
            if (zahtjev == null)
            {
                return NotFound();
            }
            ViewBag.KrvnaGrupa = new SelectList(Enum.GetValues(typeof(KrvnaGrupa)).Cast<KrvnaGrupa>());
            return View(zahtjev);
        }

        // POST: Zahtjev/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("zahtjevID,kolicina,email,opis,krvnaGrupa")] Zahtjev zahtjev)
        {
            if (id != zahtjev.zahtjevID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zahtjev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZahtjevExists(zahtjev.zahtjevID))
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
            ViewBag.KrvnaGrupa = new SelectList(Enum.GetValues(typeof(KrvnaGrupa)).Cast<KrvnaGrupa>());
            return View(zahtjev);
        }

        // GET: Zahtjev/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjev = await _context.Zahtjev
                .FirstOrDefaultAsync(m => m.zahtjevID == id);
            if (zahtjev == null)
            {
                return NotFound();
            }

            return View(zahtjev);
        }

        // POST: Zahtjev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zahtjev = await _context.Zahtjev.FindAsync(id);
            if (zahtjev != null)
            {
                _context.Zahtjev.Remove(zahtjev);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZahtjevExists(int id)
        {
            return _context.Zahtjev.Any(e => e.zahtjevID == id);
        }
    }
}
