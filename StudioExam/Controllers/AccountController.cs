using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StudioExam.ViewModels.AccountViewModels;

namespace StudioExam.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IdentityDbContext _identityContext;
        //private readonly IdentityRole _maneger;

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Register(RegisterVM vm)
        //{
        //    if (!ModelState.IsValid)
        //        return View(vm);


        //}
    }
}
