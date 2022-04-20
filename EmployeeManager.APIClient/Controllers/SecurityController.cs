using EmployeeManager.APIClient.Models;
using EmployeeManager.APIClient.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.APIClient.Controllers
{
    public class SecurityController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly SignInManager<AppIdentityUser> signInManager;
        private readonly RoleManager<AppIdentityRole> roleManager;

        public SecurityController(
            UserManager<AppIdentityUser> userManager,
            SignInManager<AppIdentityUser> signInManager,
            RoleManager<AppIdentityRole> roleManager
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                if (!roleManager.RoleExistsAsync("Manager").Result)
                {
                    var role = new AppIdentityRole();
                    role.Name = "Manager";
                    role.Description = "Can Perform CRUD Operations";
                    var roleResult = roleManager.CreateAsync(role).Result;
                }

                var user = new AppIdentityUser();
                user.UserName = register.UserName;
                user.Email = register.Email;
                user.FullName = register.FullName;
                user.BirthDate = register.BirthDate;

                var result = userManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                    return RedirectToAction("SignIn", "Security");
                } else
                {
                    ModelState.AddModelError("", "Invalid User Detail");
                }
            }
            return View(register);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(
                    signIn.UserName,
                    signIn.Password,
                    signIn.RememberMe,
                    false).Result;

                if (result.Succeeded)
                        return RedirectToAction("List", "EmployeeManager");
                    else
                      ModelState.AddModelError("", "Invalid User Details");
            }
            return View(signIn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult SignOut()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction("SignIn", "Security");
        }

        public IActionResult AccessDenied() { 
            return View(); 
        }

    }
}
