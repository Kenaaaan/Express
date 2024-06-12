using Express.Data;
using Express.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Express.Controllers
{
    public class KorpaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<KorpaController> _logger;

        public KorpaController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<KorpaController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(string address, string creditCard, string expiryDate, string cvv)
        {
            var userId = _userManager.GetUserId(User);
            var korpa = await _context.Korpa
                .Include(k => k.Products)
                .FirstOrDefaultAsync(k => k.IdKorisnika == userId);

            if (korpa == null)
            {
                return NotFound();
            }

            // Process payment here using the provided credit card details.
            // For simplicity, we're skipping the actual payment gateway integration.

            // Clear the cart after successful payment.
            korpa.Products.Clear();
            korpa.UkupnaCijena = 0;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home"); // Redirect to a confirmation page or home page after checkout.
        }


        // GET: Korpa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var korpa = await _context.Korpa.FindAsync(id);
            if (korpa != null)
            {
                _context.Korpa.Remove(korpa);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korpa = await _context.Korpa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (korpa == null)
            {
                return NotFound();
            }

            return View(korpa);
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            _logger.LogInformation("Retrieving cart for user: {UserId}", userId);

            var korpa = await _context.Korpa
                .Include(k => k.Products)
                .FirstOrDefaultAsync(k => k.IdKorisnika == userId);

            if (korpa == null)
            {
                _logger.LogInformation("No cart found for user: {UserId}", userId);

                korpa = new Korpa
                {
                    IdKorisnika = userId,
                    Products = new List<Proizvod>()
                };
                _context.Korpa.Add(korpa);
                await _context.SaveChangesAsync();
            }
            else
            {
                _logger.LogInformation("Cart found for user: {UserId}, containing {ProductCount} products", userId, korpa.Products.Count);
            }

            return View(korpa);
        }

        // POST: Korpa/AddToCart
        [HttpPost]
        public async Task<IActionResult> AddToCart(int proizvodId)
        {
            var userId = _userManager.GetUserId(User);
            _logger.LogInformation("Adding product {ProductId} to cart for user: {UserId}", proizvodId, userId);

            var identityUser = await _userManager.FindByIdAsync(userId);
            if (identityUser == null)
            {
                _logger.LogWarning("User not found: {UserId}", userId);
                return NotFound();
            }

            var proizvod = await _context.Proizvod.FindAsync(proizvodId);
            if (proizvod == null)
            {
                _logger.LogWarning("Product not found: {ProductId}", proizvodId);
                return NotFound();
            }

            var korpa = await _context.Korpa
                .Include(k => k.Products)
                .FirstOrDefaultAsync(k => k.IdKorisnika == userId);

            if (korpa == null)
            {
                _logger.LogInformation("Creating new cart for user: {UserId}", userId);

                korpa = new Korpa
                {
                    IdKorisnika = userId,
                    Korisnik = identityUser
                };
                _context.Korpa.Add(korpa);
            }

            korpa.DodajProizvod(proizvod);
            _logger.LogInformation("Product {ProductId} added to cart for user: {UserId}", proizvodId, userId);

            await _context.SaveChangesAsync();
            _logger.LogInformation("Changes saved to database");

            return Json(new { success = true });
        }

        // POST: Korpa/RemoveFromCart
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int proizvodId)
        {
            var userId = _userManager.GetUserId(User);
            _logger.LogInformation("Removing product {ProductId} from cart for user: {UserId}", proizvodId, userId);

            var korpa = await _context.Korpa
                .Include(k => k.Products)
                .FirstOrDefaultAsync(k => k.IdKorisnika == userId);

            if (korpa == null)
            {
                _logger.LogWarning("Cart not found for user: {UserId}", userId);
                return NotFound();
            }

            var proizvod = await _context.Proizvod.FindAsync(proizvodId);
            if (proizvod == null)
            {
                _logger.LogWarning("Product not found: {ProductId}", proizvodId);
                return NotFound();
            }

            korpa.ObrisiProizvod(proizvod);
            _logger.LogInformation("Product {ProductId} removed from cart for user: {UserId}", proizvodId, userId);

            await _context.SaveChangesAsync();
            _logger.LogInformation("Changes saved to database");

            return RedirectToAction("Index");
        }
    }
}
