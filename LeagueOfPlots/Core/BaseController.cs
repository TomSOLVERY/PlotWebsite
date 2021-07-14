using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfPlots.Core
{
    public class BaseController : Controller
    {
        public BaseController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.ApplicationDbContext = context;
            this.UserManager = userManager;
        }

        protected ApplicationDbContext ApplicationDbContext;
        protected UserManager<ApplicationUser> UserManager;
    }
}
