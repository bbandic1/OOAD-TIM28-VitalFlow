using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VitalFlow.Models;

namespace YourAppName.Areas.Identity.Pages.Account
{
    public class ManageModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ManageModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

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

            // Load additional data from your database for JMBG and Krvna Grupa
            // Example:
            // var korisnik = await _context.Korisnik.FindAsync(user.Id);
            // if (korisnik != null)
            // {
            //     JMBG = korisnik.jmbg;
            //     KrvnaGrupa = korisnik.krvnaGrupa;
            // }

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

            // Update additional data in your database for JMBG and Krvna Grupa
            // Example:
            // var korisnik = await _context.Korisnik.FindAsync(user.Id);
            // if (korisnik != null)
            // {
            //     korisnik.jmbg = JMBG;
            //     korisnik.krvnaGrupa = KrvnaGrupa;
            //     await _context.SaveChangesAsync();
            // }

            return RedirectToPage();
        }
    }
}
