using Microsoft.AspNetCore.Mvc;

namespace GhostHire.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUpPage()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }
    }
}
