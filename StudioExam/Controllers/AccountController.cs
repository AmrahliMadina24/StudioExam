using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace StudioExam.Controllers
{
    public class AccountController : Controller
    {
        private readonly IdentityDbContext _identityContext;
        private readonly IdentityRole _maneger;

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
