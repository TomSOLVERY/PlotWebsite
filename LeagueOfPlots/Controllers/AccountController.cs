using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Core;
using LeagueOfPlots.Extensions;
using LeagueOfPlots.Models;
using LeagueOfPlots.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfPlots.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly ILogger<LogoutModel> _logger;

        public AccountController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : base(context,userManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if(this.User.Identity.IsAuthenticated)
                return LocalRedirect("~/");
            return this.View("~/Views/Account/LoginView.cshtml");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            if (this.User.Identity.IsAuthenticated)
                return LocalRedirect("~/");
            String key = null;
            if (this.TempData.ContainsKey("RegistryKey"))
            {
                key = this.TempData.Get<String>("RegistryKey");
                this.TempData.Remove("RegistryKey");
            }
            RegistrationModel user = this.ApplicationDbContext.Registrations.FirstOrDefault(x => x.Key == key && !x.IsRegister);
            if (user == null)
                return this.View("~/Views/Account/LoginView.cshtml");
            ViewModelRegistration vm = new ViewModelRegistration
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                RegistrationKey = key
            };
            return this.View("~/Views/Account/Registration.cshtml",vm);
        }

        [HttpPost]
        public async Task<IActionResult> Registration(ViewModelRegistration vm)
        {
            if (this.User.Identity.IsAuthenticated)
                return LocalRedirect("~/");
            if (this.ModelState.IsValid)
            {
                RegistrationModel registration = this.ApplicationDbContext.Registrations.First(x => x.Key == vm.RegistrationKey);
                var user = new ApplicationUser
                {
                    UserName = vm.UserName,
                    Email = vm.Email,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName
                };
                var result = await this.UserManager.CreateAsync(user, vm.Password);
                if (result.Succeeded)
                {
                    registration.IsRegister = true;
                    this.ApplicationDbContext.SaveChanges();
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect("~/");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(nameof(vm.Password), error.Description);
                }
            }
            return this.View("~/Views/Account/Registration.cshtml", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, vm.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect("~/");
                }
                if (result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(nameof(vm.UserName), "Nom d'utilisateur ou mot de passe invalide");
                    return this.View("~/Views/Account/LoginView.cshtml");
                }
            }

            // If we got this far, something failed, redisplay form
            return this.View("~/Views/Account/LoginView.cshtml");
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = this.ApplicationDbContext.Registrations.FirstOrDefault(x => x.Key == vm.KeyRegistration);
                if(user == null)
                {
                    this.ModelState.AddModelError(nameof(vm.KeyRegistration), "Clé d'inscription incorrecte");
                    return this.View("~/Views/Account/LoginView.cshtml");
                }
                if (user.IsRegister)
                {
                    this.ModelState.AddModelError(nameof(vm.KeyRegistration), "Ce compte est déja inscrit");
                    return this.View("~/Views/Account/LoginView.cshtml");
                }
                this.TempData.Put("RegistryKey", vm.KeyRegistration);
                return LocalRedirect("~/Account/Registration");
            }
            return this.View("~/Views/Account/LoginView.cshtml");
        }

        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.UserManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{this.UserManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await this.UserManager.ChangePasswordAsync(user, vm.OldPassword, vm.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return this.View();
            }

            await _signInManager.RefreshSignInAsync(user);
            return this.View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("/Account/Login");
        }
    }
}
