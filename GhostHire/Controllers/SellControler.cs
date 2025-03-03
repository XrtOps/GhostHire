using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using GhostHire.Models;
using GhostHire.Data;

namespace GhostHire.Controllers
{
    public class SellController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Hardcoded Freelancers - 3 Listings per Category
        private static List<ServiceModel> hardcodedFreelancers = new List<ServiceModel>
        {
            // Web Design
            new ServiceModel { Id = 1, Title = "Custom Website Design", Description = "Unique website designs tailored to your brand.", Price = 300, Categories = "Web Design" },
            new ServiceModel { Id = 2, Title = "Landing Page Creation", Description = "High-converting landing pages with modern UI.", Price = 150, Categories = "Web Design" },
            new ServiceModel { Id = 3, Title = "Website Redesign", Description = "Revamp your outdated website for a fresh look.", Price = 250, Categories = "Web Design" },

            // Graphic Design
            new ServiceModel { Id = 4, Title = "Logo Design", Description = "Professional logo design for your business.", Price = 80, Categories = "Graphic Design" },
            new ServiceModel { Id = 5, Title = "Brand Identity Pack", Description = "Complete branding package for consistency.", Price = 200, Categories = "Graphic Design" },
            new ServiceModel { Id = 6, Title = "Business Card Design", Description = "Sleek, modern business card designs.", Price = 50, Categories = "Graphic Design" },

            // Digital Marketing
            new ServiceModel { Id = 7, Title = "Social Media Marketing", Description = "Boost engagement with strategic campaigns.", Price = 150, Categories = "Digital Marketing" },
            new ServiceModel { Id = 8, Title = "Email Marketing", Description = "Drive sales with targeted email campaigns.", Price = 100, Categories = "Digital Marketing" },
            new ServiceModel { Id = 9, Title = "PPC Advertising", Description = "Effective pay-per-click campaigns for growth.", Price = 200, Categories = "Digital Marketing" },

            // Writing & Translation
            new ServiceModel { Id = 10, Title = "Ghostwriting", Description = "Get a blog, article, or book written professionally.", Price = 50, Categories = "Writing & Translation" },
            new ServiceModel { Id = 11, Title = "Technical Writing", Description = "Detailed, technical documents for your business.", Price = 120, Categories = "Writing & Translation" },
            new ServiceModel { Id = 12, Title = "Translation Services", Description = "Accurate translations for any language.", Price = 75, Categories = "Writing & Translation" },

            // Programming
            new ServiceModel { Id = 13, Title = "Full-Stack Web Development", Description = "Complete front-end and back-end development.", Price = 500, Categories = "Programming" },
            new ServiceModel { Id = 14, Title = "API Development", Description = "Custom APIs for your web or mobile app.", Price = 300, Categories = "Programming" },
            new ServiceModel { Id = 15, Title = "Database Optimization", Description = "Speed up and secure your database.", Price = 200, Categories = "Programming" },

            // Video & Animation
            new ServiceModel { Id = 16, Title = "Explainer Video Creation", Description = "Engaging animated explainer videos.", Price = 250, Categories = "Video & Animation" },
            new ServiceModel { Id = 17, Title = "YouTube Video Editing", Description = "Professional video editing for YouTube.", Price = 100, Categories = "Video & Animation" },
            new ServiceModel { Id = 18, Title = "Motion Graphics", Description = "High-quality motion graphics and animation.", Price = 300, Categories = "Video & Animation" },

            // Music & Audio
            new ServiceModel { Id = 19, Title = "Podcast Editing", Description = "Clean and professional podcast audio.", Price = 150, Categories = "Music & Audio" },
            new ServiceModel { Id = 20, Title = "Jingle Creation", Description = "Custom jingles and theme music.", Price = 200, Categories = "Music & Audio" },
            new ServiceModel { Id = 21, Title = "Voiceover Services", Description = "Professional voiceovers for any project.", Price = 100, Categories = "Music & Audio" },

            // Photography
            new ServiceModel { Id = 22, Title = "Product Photography", Description = "High-quality photos for e-commerce.", Price = 250, Categories = "Photography" },
            new ServiceModel { Id = 23, Title = "Portrait Photography", Description = "Professional headshots and portraits.", Price = 150, Categories = "Photography" },
            new ServiceModel { Id = 24, Title = "Photo Editing & Retouching", Description = "Enhance and edit your photos professionally.", Price = 80, Categories = "Photography" },

            // SEO Services
            new ServiceModel { Id = 25, Title = "SEO Optimization", Description = "Improve your website's Google ranking.", Price = 100, Categories = "SEO Services" },
            new ServiceModel { Id = 26, Title = "Backlink Building", Description = "Get high-quality backlinks for SEO.", Price = 200, Categories = "SEO Services" },
            new ServiceModel { Id = 27, Title = "Content SEO Strategy", Description = "Optimize your content for better reach.", Price = 150, Categories = "SEO Services" },

            // App Development
            new ServiceModel { Id = 28, Title = "iOS App Development", Description = "Custom iOS apps for your business.", Price = 600, Categories = "App Development" },
            new ServiceModel { Id = 29, Title = "Android App Development", Description = "Native Android apps with top performance.", Price = 600, Categories = "App Development" },
            new ServiceModel { Id = 30, Title = "Cross-Platform Apps", Description = "Apps for both iOS & Android.", Price = 800, Categories = "App Development" }
        };

        public SellController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string category = null)
        {
            // Get database freelancers
            List<ServiceModel> dbFreelancers = _context.Services.ToList();

            // Combine hardcoded and database freelancers
            List<ServiceModel> allFreelancers = hardcodedFreelancers.Concat(dbFreelancers).ToList();

            // Filter by category if selected
            if (!string.IsNullOrEmpty(category))
            {
                allFreelancers = allFreelancers
                    .Where(s => s.Categories != null && s.Categories.ToLower().Contains(category.ToLower()))
                    .ToList();
            }

            ViewBag.SelectedCategory = category;
            return View(allFreelancers);
        }

        public IActionResult Hire(int id)
        {
            var service = hardcodedFreelancers.FirstOrDefault(s => s.Id == id) ?? _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost]
        public IActionResult ConfirmHire(int serviceId)
        {
            var service = hardcodedFreelancers.FirstOrDefault(s => s.Id == serviceId) ?? _context.Services.Find(serviceId);
            if (service == null)
            {
                return NotFound();
            }

            ViewBag.Message = $"Service '{service.Title}' successfully hired! The provider will contact you anonymously.";
            return View("Success");
        }
    }
}
