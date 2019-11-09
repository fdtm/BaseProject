using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Core.Models;
using WebApplication2.Core.Services;

namespace WebApplication2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _studentService.GetStudentsByNumber(2));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var student = await _studentService.GetAsync(Convert.ToInt32(id));
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,Degree,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                var result = await _studentService.AddAsync(student);
                if(!result.Success)
                {
                    ModelState.AddModelError("", result.Message);
                    return View(student);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var student = await _studentService.GetAsync(Convert.ToInt32(id));
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age,Degree,Address")] Student student)
        {
            if (id != student.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _studentService.UpdateAsync(id, student);
                if(!result.Success)
                {
                    ModelState.AddModelError("", result.Message);
                    return View(student);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var student = await _studentService.GetAsync(Convert.ToInt32(id));
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _studentService.RemoveAsync(id);
            if(!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View("Delete", id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
