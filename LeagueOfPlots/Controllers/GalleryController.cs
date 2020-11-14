using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Areas.Identity.Data;
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

        public IActionResult Index()
        {
            List<ViewModelAlbum> vm = new List<ViewModelAlbum>();
            List<Album> albums = this.ApplicationDbContext.Albums.Include(x => x.Photos).ToList();
            foreach(var album in albums)
            {
                vm.Add(new ViewModelAlbum(album, albums));
            }
            return View(vm);
        }
    }
}
