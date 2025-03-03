using Microsoft.AspNetCore.Mvc;
using GhostHire.Models;
using GhostHire.Data;
using Microsoft.AspNetCore.Http;

namespace GhostHire.Controllers
{
    public class AdvertiseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvertiseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Advertize()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Advertize(GhostHire.Models.ServiceModel model, string[] Categories, List<IFormFile> Photos)
        {
            if (Categories.Length == 0)
            {
                ModelState.AddModelError("Categories", "You must select at least one category.");
                return View(model);
            }

            if (Photos == null || Photos.Count == 0)
            {
                ModelState.AddModelError("Photos", "You must upload at least one photo.");
                return View(model);
            }

            // Store selected categories and photo names
            model.Categories = string.Join(", ", Categories);
            model.PhotoFileNames = string.Join(", ", Photos.Select(p => p.FileName));

            // Redirect to confirmation page 
            return RedirectToAction("AdvertizeConfirmation");
        }

        [HttpGet]
        public IActionResult AdvertizeConfirmation()
        {
            return View(); 
        }
    }
}
