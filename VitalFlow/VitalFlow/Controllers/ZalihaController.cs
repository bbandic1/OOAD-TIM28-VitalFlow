using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitalFlow.Data;
using VitalFlow.Models;

namespace VitalFlow.Controllers
{
    namespace VitalFlow.Controllers
    {
        public class ZalihaController : Controller
        {
            private readonly ApplicationDbContext _context;
            private readonly ILogger<ZalihaController> _logger;

            public ZalihaController(ApplicationDbContext context, ILogger<ZalihaController> logger)
            {
                _context = context;
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
                _logger.LogInformation($"Decrease request received for blood type: {krvnaGrupa}");
                // Provjera i pretvorba stringa u enum KrvnaGrupa
                if (!Enum.TryParse<KrvnaGrupa>(krvnaGrupa, out var krvnaGrupaEnum))
                {
                    return BadRequest("Invalid blood type");
                }

                // Pronalaženje zalihe za odabranu krvnu grupu
                var zaliha = await _context.Zaliha
                    .FirstOrDefaultAsync(z => z.krvnaGrupa == krvnaGrupaEnum);

                if (zaliha == null)
                {
                    return NotFound();
                }

                // Povećanje količine za pronađenu zalihu
                zaliha.kolicina++;

                // Spremanje promjena u bazi podataka
                await _context.SaveChangesAsync();

                // Preusmjeravanje na akciju Index nakon uspješnog ažuriranja
                return RedirectToAction(nameof(Index));
            }

            // POST: Zaliha/Decrease
            [HttpPost]
            public async Task<IActionResult> Decrease(string krvnaGrupa)
            {
                // Provjera i pretvorba stringa u enum KrvnaGrupa
                if (!Enum.TryParse<KrvnaGrupa>(krvnaGrupa, out var krvnaGrupaEnum))
                {
                    return BadRequest("Invalid blood type");
                }

                // Pronalaženje zalihe za odabranu krvnu grupu
                var zaliha = await _context.Zaliha
                    .FirstOrDefaultAsync(z => z.krvnaGrupa == krvnaGrupaEnum);

                if (zaliha == null)
                {
                    return NotFound();
                }

                // Smanjenje količine za pronađenu zalihu
                zaliha.kolicina--;

                // Spremanje promjena u bazi podataka
                await _context.SaveChangesAsync();

                // Preusmjeravanje na akciju Index nakon uspješnog ažuriranja
                return RedirectToAction(nameof(Index));
            }

            private bool ZalihaExists(KrvnaGrupa krvnaGrupa)
            {
                return _context.Zaliha.Any(e => e.krvnaGrupa == krvnaGrupa);
            }
        }
    }
}
