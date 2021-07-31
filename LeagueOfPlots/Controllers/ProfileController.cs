using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Core;
using LeagueOfPlots.Models;
using LeagueOfPlots.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfPlots.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {
        }

        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await this.UserManager.GetUserAsync(this.User);
            if (user == null)
                return this.NotFound();
            ViewModelProfile vm = new ViewModelProfile(user,this.ApplicationDbContext);
            return this.View(vm);
        } 
    }
}
