using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VitalFlow.Data;
using VitalFlow.Models;

namespace YourAppName.Areas.Identity.Pages.Account
{
    public class ManageModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ManageModel(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string PhoneNumber { get; set; }

        [BindProperty]
        public string JMBG { get; set; }

        [BindProperty]
        public KrvnaGrupa KrvnaGrupa { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var korisnik = await _context.Korisnik
                .FirstOrDefaultAsync(k => k.identityID == user.Id);

            if (korisnik != null)
            {
                Email = user.Email; // Postavljanje e-mail adrese korisnika
                PhoneNumber = korisnik.brojTelefona; // Postavljanje broja telefona korisnika
                JMBG = korisnik.jmbg; // Postavljanje JMBG-a korisnika
                KrvnaGrupa = korisnik.krvnaGrupa; // Postavljanje krvne grupe korisnika
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var korisnik = await _context.Korisnik
                .FirstOrDefaultAsync(k => k.identityID == user.Id);

            if (korisnik != null)
            {
                korisnik.brojTelefona = PhoneNumber; // Ažuriranje broja telefona
                korisnik.jmbg = JMBG; // Ažuriranje JMBG-a
                korisnik.krvnaGrupa = KrvnaGrupa; // Ažuriranje krvne grupe
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
