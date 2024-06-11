using Microsoft.AspNetCore.Mvc;

namespace VitalFlow.Controllers
{
    public class OnamaController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "O nama";
            return View();
        }

    }
}
