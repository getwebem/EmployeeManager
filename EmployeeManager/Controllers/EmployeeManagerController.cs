using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManager.Controllers
{
    public class EmployeeManagerController : Controller
    {
        private AppDbContext db = null;
        public EmployeeManagerController(AppDbContext db)
        {
            this.db = db;
        }
        
        public IActionResult List()
        {
            List<Employee> model = (from e in db.Employees
                                    orderby e.EmployeeID
                                    select e).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            FillCountries();
            return View();
        }

        private void FillCountries()
        {
           List<SelectListItem> listOfCountries = (from c in db.Employees select new SelectListItem()
           {
               Text = c.Country, Value = c.Country
           }).Distinct().ToList();
            ViewBag.Countries = listOfCountries;    
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            FillCountries();
            var model = db.Employees.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Employee model)
        {   FillCountries();
            if (ModelState.IsValid)
            {
                db.Employees.Add(model);
                db.SaveChanges();
                ViewBag.Message = "Employee added successfully";
            }
            return View(model);
        }
    }
}
