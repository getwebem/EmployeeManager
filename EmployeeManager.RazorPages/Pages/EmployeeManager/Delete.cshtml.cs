using EmployeeManager.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.RazorPages.Pages.EmployeeManager
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext db = null;

        [BindProperty]
        public Employee Employee { get; set; }
        public string Message { get; set; }
        public bool DataFound { get; set; } = true;

        public DeleteModel(AppDbContext db)
        {
            this.db = db;
        }

        public void OnGet(int id)
        {
            Employee = db.Employees.Find(id);

            if (Employee == null)
            {
                DataFound = false;
                Message = "Employee ID not found";
            }
            else
            {
                DataFound = true;
                Message = "";
            }
        }

        public IActionResult OnPost()
        {
            Employee emp = db.Employees.Find(Employee.EmployeeID);
            try
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                TempData["Message"] = "Employee Successfully Deleted";
                return RedirectToPage("/EmployeeManager/List");
            }
            catch (DbUpdateException ex1)
            {
                Message = ex1.Message;
                if (ex1.InnerException != null)
                {
                    Message += ": " + ex1.InnerException.Message;
                }
            }
            catch (Exception ex2)
            {
                Message = ex2.Message;
            }

            return Page();
        }
    }
}

