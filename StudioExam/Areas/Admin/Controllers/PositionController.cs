using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioExam.Context;
using StudioExam.Helpers;
using StudioExam.Models;
using StudioExam.ViewModels.EmployeeViewModels;
using StudioExam.ViewModels.PositionViewModels;

namespace StudioExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController(AppDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var positions = await _context.Positions.Select(positions => new PositionGetVM()
            {
                Id = positions.Id,
                Name = positions.Name,
                



            }).ToListAsync();
            return View(positions);
        }
        public IActionResult Create()
        {
           
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(PositionCreateVM vm)
        {
          

            if (!ModelState.IsValid)
                return View(vm);

            
          

            Position position = new()
            {
                Name = vm.Name,
              

            };



            await _context.Positions.AddAsync(position);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Delete(int id)
        {
            var position = await _context.Positions.FindAsync(id);


            if (position is null)
                return NotFound();

            _context.Positions.Remove(position);
            _context.SaveChanges();





            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update()
        {
            return View();
        }


    }
}
