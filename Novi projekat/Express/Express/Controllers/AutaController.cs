using Microsoft.AspNetCore.Mvc;
using Express.Data;


namespace Express.Controllers
{
    public class AutaController : Controller
    {
        private readonly ApplicationDbContext Context;
        
        public AutaController(ApplicationDbContext context)
        {
            Context = context;
        }
      
        public IActionResult Index()
        { 

            var Auta = Context.Proizvod.ToList();
            return View(Auta);
        }
    }
}
