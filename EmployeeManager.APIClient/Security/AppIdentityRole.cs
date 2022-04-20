using Microsoft.AspNetCore.Identity;

namespace EmployeeManager.APIClient.Security
{
    public class AppIdentityRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
