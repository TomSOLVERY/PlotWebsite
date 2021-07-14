using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Core;
using LeagueOfPlots.Models;
using LeagueOfPlots.Models.Gallery;
using LeagueOfPlots.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeagueOfPlots.Controllers
{
    [Authorize]
    public class GalleryController : BaseController
    {
        public GalleryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {
        }
        public const int CacheAgeSeconds = 60 * 60 * 24 * 30; // 30 days
        public IActionResult Index()
        {
            List<Album> albums = this.ApplicationDbContext.Albums.ToList();
            Response.Headers["Cache-Control"] = $"private,max-age={CacheAgeSeconds}";
            return View(new ViewModelGallery(albums));
        }

        public async Task<IActionResult> Create(String name)
        {
            ApplicationUser currentUser = await this.UserManager.GetUserAsync(this.HttpContext.User);
            Album album = new Album(name, currentUser.UserName);
            this.ApplicationDbContext.Add(album);
            this.ApplicationDbContext.SaveChanges();
            return new RedirectResult($"~/Gallery");
        }
    }
}
