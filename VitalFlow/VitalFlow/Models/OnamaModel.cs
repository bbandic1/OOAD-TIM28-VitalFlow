using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VitalFlow.Models
{
    public class OnamaModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Title"] = "O nama";
        }
    }
}
