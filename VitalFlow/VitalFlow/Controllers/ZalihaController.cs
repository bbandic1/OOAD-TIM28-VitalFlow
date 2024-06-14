using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VitalFlow.Data;
using VitalFlow.Models;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;

namespace VitalFlow.Controllers
{
    public class ZalihaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ZalihaController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public ZalihaController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<ZalihaController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        // GET: Zaliha
        public async Task<IActionResult> Index()
        {
            var zalihe = await _context.Zaliha
                .Select(z => new ZalihaViewModel
                {
                    HubID = z.hubID,
                    KrvnaGrupa = z.krvnaGrupa,
                    Kolicina = z.kolicina,
                    KriticnaLinija = z.kriticnaLiinija
                }).ToListAsync();

            return View(zalihe);
        }

        // POST: Zaliha/Increase
        [HttpPost]
        public async Task<IActionResult> Increase(string krvnaGrupa)
        {
            _logger.LogInformation($"Increase request received for blood type: {krvnaGrupa}");

            // Check and parse string to KrvnaGrupa enum
            if (!Enum.TryParse<KrvnaGrupa>(krvnaGrupa, out var krvnaGrupaEnum))
            {
                return BadRequest("Invalid blood type");
            }

            // Find stock for selected blood type
            var zaliha = await _context.Zaliha
                .FirstOrDefaultAsync(z => z.krvnaGrupa == krvnaGrupaEnum);

            if (zaliha == null)
            {
                return NotFound();
            }

            // Increase quantity for found stock
            zaliha.kolicina++;

            // Save changes to database
            await _context.SaveChangesAsync();

            // Redirect to Index action after successful update
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Decrease(string krvnaGrupa)
        {
            _logger.LogInformation($"Decrease request received for blood type: {krvnaGrupa}");

            // Check and parse string to KrvnaGrupa enum
            if (!Enum.TryParse<KrvnaGrupa>(krvnaGrupa, out var krvnaGrupaEnum))
            {
                return BadRequest("Invalid blood type");
            }

            // Find stock for selected blood type
            var zaliha = await _context.Zaliha
                .FirstOrDefaultAsync(z => z.krvnaGrupa == krvnaGrupaEnum);

            if (zaliha == null)
            {
                return NotFound();
            }

            

            var users = await _context.Users.Where(u => u.Email != null).ToListAsync();
            // Decrease quantity for found stock
            zaliha.kolicina--;

            // Check if stock level is critical
            if (zaliha.kolicina <= zaliha.kriticnaLiinija)
            {
                foreach (var korisnik in users)
                {
                    string subject = "Važna obavijest: Kritično niska zaliha krvne grupe";
                    string body = $"Poštovani/Poštovana,\n\n" +
                                  "Ovim putem Vas obavještavamo da su zalihe krvne grupe " +  krvnaGrupa  + " trenutno na kritično niskom nivou. " +
                                  "Kako bismo mogli pružiti neophodnu pomoć pacijentima kojima je vaša krvna grupa potrebna, " +
                                  "molimo vas da, ukoliko ste u mogućnosti, razmislite o donaciji krvi u najbližem centru za transfuziju.\n\n" +
                                  "Vaša pomoć može spasiti živote i svaka donacija je od izuzetne važnosti za našu zajednicu.\n\n" +
                                  "Hvala Vam na vašoj nesebičnoj podršci i solidarnosti.\n\n" +
                                  "Srdačan pozdrav,\n" +
                                  "Vaš tim za transfuziju krvi";

                    await SendEmail(korisnik.Email, subject, body);
                }
            }

            // Save changes to database
            await _context.SaveChangesAsync();

            // Redirect to Index action after successful update
            return RedirectToAction(nameof(Index));
        }

        private async Task SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                string fromEmail = "VitalFlow2024@gmail.com";
                string appPassword = "rlhl dgtp gbdn filq"; // Replace with your app password

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

        private bool ZalihaExists(KrvnaGrupa krvnaGrupa)
        {
            return _context.Zaliha.Any(e => e.krvnaGrupa == krvnaGrupa);
        }
    }
}
