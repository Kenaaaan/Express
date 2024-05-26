using Microsoft.AspNetCore.Mvc;

namespace Express.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
