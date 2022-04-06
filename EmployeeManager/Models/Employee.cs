using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.Models
{
    [Table("Employees")]
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Notes { get; set; }
        public string Country { get; set; }

    }
}
