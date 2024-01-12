using Microsoft.AspNetCore.Mvc;

namespace BlogNet3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Post()
        {
            return View();
        }
    }
}
