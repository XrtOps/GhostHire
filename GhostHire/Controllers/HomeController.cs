using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GhostHire.Models;
using System.Diagnostics;

namespace GhostHire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Home Page
        public IActionResult HomePage()
        {
            return View();
        }


        // * * SHOP PAGE * * Sell Page
        public IActionResult Sell()
        {
            return RedirectToAction("Index", "Sell"); // Redirects to SellController
        }


        // My Dashboard Page
        public IActionResult MyDashboard()
        {
            return View();
        }

        public IActionResult AboutKSL()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult TermsAndConditions()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
