using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioExam.Context;
using StudioExam.ViewModels.EmployeeViewModels;
using System.Threading.Tasks;

namespace StudioExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
