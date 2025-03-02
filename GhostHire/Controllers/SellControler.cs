using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GhostHire.Controllers
{
    public class SellController : Controller
    {
        // List of anonymous services (Mock Data - Replace with DB in production)
        private static List<ServiceModel> services = new List<ServiceModel>
        {
            new ServiceModel { Id = 1, Title = "Ghostwriting", Description = "Get a blog, article, or book written by a professional.", Price = 50 },
            new ServiceModel { Id = 2, Title = "Anonymous Video Editing", Description = "Professional video editing without revealing identity.", Price = 75 },
            new ServiceModel { Id = 3, Title = "Anonymous Graphic Design", Description = "Logos, banners, and illustrations with full anonymity.", Price = 60 },
            new ServiceModel { Id = 4, Title = "Cybersecurity Consultation", Description = "Improve security without revealing the consultant's identity.", Price = 120 }
        };

        // Show the list of services
        public IActionResult Index()
        {
            return View(services);
        }

        // Show hire page for selected service
        public IActionResult Hire(int id)
        {
            var service = services.Find(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // Handle hire confirmation
        [HttpPost]
        public IActionResult ConfirmHire(int serviceId)
        {
            var service = services.Find(s => s.Id == serviceId);
            if (service == null)
            {
                return NotFound();
            }

            ViewBag.Message = $"Service '{service.Title}' successfully hired! The provider will contact you anonymously.";
            return View("Success");
        }
    }

    // Service model for listing and hiring
    public class ServiceModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Categories { get; internal set; }
    }
}
