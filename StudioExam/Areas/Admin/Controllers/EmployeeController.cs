using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioExam.Context;
using StudioExam.Helpers;
using StudioExam.Models;
using StudioExam.ViewModels.EmployeeViewModels;
using System.Threading.Tasks;

namespace StudioExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _enviroment;
        private readonly string folderPath;

        public EmployeeController(AppDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;
            folderPath = Path.Combine(_enviroment.WebRootPath, "assets", "images");

        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.Select(employee => new EmployeeGetVM()
            {
                Id = employee.Id,
                FullName = employee.FullName,
                ImagePath = employee.ImagePath,
                PositionName=employee.Position.Name

            }).ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> Create()
        {
            await SendPositionsWithViewBag();
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateVM vm)
        {
            await SendPositionsWithViewBag();

            if (!ModelState.IsValid)
                return View(vm);

            var isExistPositionId = await _context.Positions.AnyAsync(x => x.Id == vm.PositionId);

            if (!isExistPositionId)
            {
                ModelState.AddModelError("PositionId", "This PositionId not found");
                return View(vm);
            }

            if (vm.Image.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Image", "You can upload untill 2 mb image file");
                return View(vm);

            }
            if (vm.Image.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Image", "You can upload file image type");
                return View(vm);

            }

            string uniqueFileName = await vm.Image.FileUploadAsync(folderPath);

            Employee employee = new()
            {
                FullName = vm.FullName,
                ImagePath = uniqueFileName,
                PositionId = vm.PositionId

            };

            await _context.Employees.AddAsync(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            

        }
        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);


            if (employee is null)
                return NotFound();

            _context.Employees.Remove(employee);
            _context.SaveChanges();





            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee is null)
                return NotFound();



            return RedirectToAction(nameof(Index)); 

        }










        private async Task SendPositionsWithViewBag()
        {
            var positions = await _context.Positions.ToListAsync();
            ViewBag.Positions = positions;
        }
    }
}
