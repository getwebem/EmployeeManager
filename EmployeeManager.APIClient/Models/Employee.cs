using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.APIClient.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Column("EmployeeID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Employeee ID is required")]
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = ("First Name must be less than 50 characters"))]
        [Required(ErrorMessage = "Employeee First Name is required")]
        public string FirstName { get; set; }

        [Column("LastName")]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = ("Last Name must be less than 50 characters"))]
        [Required(ErrorMessage = "Employeee Last Name is required")]
        public string  LastName { get; set; }

        [Column("Title")]
        [Display(Name = "Title")]
        [StringLength(30, ErrorMessage = ("Title must be less than 30 characters"))]
        [Required(ErrorMessage = "Employeee Title is required")]
        public string Title { get; set; }

        [Column("BirthDate")]
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Employeee Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Column("HireDate")]
        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "Employeee Hire Date is required")]
        public DateTime HireDate { get; set; }

        [Column("Notes")]
        [Display(Name = "Notes")]
        [StringLength(500, ErrorMessage = ("Notes must be less than 500 characters"))]
        public string Notes { get; set; }

        [Column("Country")]
        [Display(Name = "Country")]
        [StringLength(30, ErrorMessage = ("Country must be less than 30 characters"))]
        [Required(ErrorMessage = "Employeee Country is required")]
        public string Country { get; set; }

    }
}
