using System.ComponentModel.DataAnnotations;

//Added  Entity Framework 6.0.4 migration 
// (1) Add-Migration -Context AppDbContext
// (2) update-database -Context AppIdentityDbContext
//https://www.youtube.com/watch?v=BfEjDD8mWYg

namespace EmployeeManager.APIClient.Models
{
    public class SignIn
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}
