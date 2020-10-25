using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfPlots.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly ILogger<LogoutModel> _logger;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //_logger.LogInformation("User logged out.");
            return LocalRedirect("/Identity/Account/Login");
           
        }
    }
}
