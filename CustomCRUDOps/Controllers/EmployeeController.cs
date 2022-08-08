using CustomCRUDOps.Data;
using CustomCRUDOps.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CustomCRUDOps.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employee.ToListAsync();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            var e = new Employee();
            e.Name = form["name"];
            e.DOB = Convert.ToDateTime(form["dob"]);
            e.EmailAddress = form["email"];
            e.HomeAddress = form["address"];
            _context.Employee.Add(e);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var emp = await _context.Employee.FirstOrDefaultAsync(e => e.Id == id);
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            var emp = _context.Employee.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Delete(IFormCollection form)
        {
            int id = Convert.ToInt32(form["id"]);
            var emp = _context.Employee.Find(id);
            _context.Employee.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = _context.Employee.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            int id = Convert.ToInt32(form["id"]);
            var emp = _context.Employee.Find(id);
            emp.Name = form["name"];
            emp.DOB = Convert.ToDateTime(form["dob"]);
            emp.EmailAddress = form["email"];
            emp.HomeAddress = form["address"];
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
