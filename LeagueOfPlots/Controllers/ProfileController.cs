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

        [HttpGet]
        public async Task<IActionResult> UpdateInformation()
        {
            ApplicationUser user = await this.UserManager.GetUserAsync(this.User);
            if (user == null)
                return this.NotFound();
            ViewModelProfileEditInfo vm = new ViewModelProfileEditInfo(user);
            return this.PartialView("PartialViewEditInformation",vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInformation(ViewModelProfileEditInfo vm)
        {
            if(!this.ModelState.IsValid)
                return this.PartialView("PartialViewEditInformation", vm);
            ApplicationUser user = await this.UserManager.GetUserAsync(this.User);
            if (user == null)
                return this.NotFound();
            vm.UpdateModel(user);
            this.ApplicationDbContext.SaveChanges();
            return this.PartialView("PartialViewEditInformation", vm);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialNetworks()
        {
            ApplicationUser user = await this.UserManager.GetUserAsync(this.User);
            if (user == null)
                return this.NotFound();
            ViewModelProfileEditSN vm = new ViewModelProfileEditSN(user);
            return this.PartialView("PartialViewEditSocialNetworks", vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialNetworks(ViewModelProfileEditSN vm)
        {
            if (!this.ModelState.IsValid)
                return this.PartialView("PartialViewEditSocialNetworks", vm);
            ApplicationUser user = await this.UserManager.GetUserAsync(this.User);
            if (user == null)
                return this.NotFound();
            vm.UpdateModel(user);
            this.ApplicationDbContext.SaveChanges();
            return this.PartialView("PartialViewEditSocialNetworks", vm);
        }
    }
}
