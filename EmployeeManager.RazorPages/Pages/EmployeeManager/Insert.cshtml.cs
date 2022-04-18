using EmployeeManager.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.RazorPages.Pages.EmployeeManager
{
    public class InsertModel : PageModel
    {
        private readonly AppDbContext db = null;

        [BindProperty]
        public Employee Employee { get; set; }

        public List<SelectListItem> Countries { get; set; }

        public string Message { get; set; }

        public void FillCountries()
        {
            List<SelectListItem> listOfCountries = (from c in db.Employees select new SelectListItem()
            {
                Text = c.Country, 
                Value =  c.Country
            }).Distinct().ToList();

            Countries = listOfCountries;
        }





        public InsertModel(AppDbContext db)
        {
            this.db = db;
        }



        public void OnGet()
        {
        }
    }
}
