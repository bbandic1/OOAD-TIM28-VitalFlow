using Microsoft.AspNetCore.Mvc;

namespace VitalFlow.Controllers
{
    public class KontaktController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Kontakt";
            return View();
        }
    }
}
