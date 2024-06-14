using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Express.Data;
using Express.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Express.Controllers
{
    public class AutaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Auta
        public async Task<IActionResult> Index(string searchString, string carBrand, int? minMileage, int? maxMileage)
        {
            var cars = from c in _context.Proizvod select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Model.Contains(searchString) || s.Proizvodjac.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(carBrand))
            {
                cars = cars.Where(x => x.Proizvodjac == carBrand);
            }

            if (minMileage.HasValue)
            {
                cars = cars.Where(x => x.Kilometraza >= minMileage);
            }

            if (maxMileage.HasValue)
            {
                cars = cars.Where(x => x.Kilometraza <= maxMileage);
            }

            var brands = await _context.Proizvod.Select(p => p.Proizvodjac).Distinct().ToListAsync();
            ViewData["Brands"] = new SelectList(brands);

            return View(await cars.ToListAsync());
        }

        // Other actions remain unchanged
    }
}
