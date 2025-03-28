using GhostHire.Data;
using GhostHire.Models;
using Microsoft.AspNetCore.Mvc;

namespace GhostHire.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext appDbContext;

        public AccountController(ApplicationDbContext context)
        {
            appDbContext = context;
        }
        
        public IActionResult SignUpPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUpPage(Authentication user)
        {
            if(ModelState.IsValid)
            {
                if(appDbContext.authentications.Any(x => x.Username == user.Username))
                {
                    ModelState.AddModelError("", "Username exists");
                    return View(user);
                }
                appDbContext.authentications.Add(user);
                appDbContext.SaveChanges();
                
                return RedirectToAction("LoginPage", "Account");
            }
            return View(user);
        }

        public IActionResult LoginPage()
        {
           if(HttpContext.Session.GetString("Username") != null)
           {
                return RedirectToAction("HomePage", "Home");
           }
           return View();
        }
        [HttpPost]
        public IActionResult LoginPage(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = appDbContext.authentications.FirstOrDefault(x => x.Username == username && x.Password == password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View();
                }
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("AuthenticationId", user.AuthenticationID.ToString());
                return RedirectToAction("HomePage", "Home");
            }
            return View();
           
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("HomePage", "Home");
        }
    }
}
