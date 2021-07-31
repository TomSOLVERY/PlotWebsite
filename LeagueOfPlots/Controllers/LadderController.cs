using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Core;
using LeagueOfPlots.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfPlots.Controllers
{
    public class LadderController : BaseController
    {
        public LadderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
