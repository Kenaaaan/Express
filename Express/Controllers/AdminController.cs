using Microsoft.AspNetCore.Mvc;

namespace Express.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
