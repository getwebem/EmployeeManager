using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Required(ErrorMessage = "Employeee ID is required")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Employeee First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Employeee Last Name is required")]
        public string  LastName { get; set; }

        [Required(ErrorMessage = "Employeee Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Employeee Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Employeee Hire Date is required")]
        public DateTime HireDate { get; set; }

        public string Notes { get; set; }

        [Required(ErrorMessage = "Employeee Country is required")]
        public string Country { get; set; }

    }
}
