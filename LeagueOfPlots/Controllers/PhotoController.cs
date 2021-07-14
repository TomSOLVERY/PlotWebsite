using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using LeagueOfPlots.Core;
using LeagueOfPlots.Helpers;
using LeagueOfPlots.Models;
using LeagueOfPlots.Models.Gallery;
using LeagueOfPlots.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeagueOfPlots.Controllers
{
    [Authorize]
    public class PhotoController : BaseController
    {
        public PhotoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context,userManager)
        {
          
        }
        public IActionResult Index(Int32 AlbumId,Int32 Id)
        {
            List<Photo> photos = this.ApplicationDbContext.Photos.Where(x => x.AlbumId == AlbumId).ToList();
            Photo photo = photos.FirstOrDefault(x => x.Id == Id);
            if (photo == null)
                return NotFound();
            return View(new ViewModelPhoto(photo,photos));
        }

        public IActionResult Rename(Int32 Id, String name)
        {
            Photo photo = this.ApplicationDbContext.Photos.FirstOrDefault(x => x.Id == Id);
            if (photo == null)
                return NotFound();
            photo.Name = name;
            this.ApplicationDbContext.SaveChanges();
            return new RedirectResult($"~/Photo?AlbumId="+photo.AlbumId+"&Id=" + Id);

        }

        public IActionResult Delete(Int32 Id)
        {
            Photo photo = this.ApplicationDbContext.Photos.FirstOrDefault(p => p.Id == Id);
            if (photo == null)
                return NotFound();
            photo.Album.PhotoCount--;
            this.ApplicationDbContext.Remove(photo);
            this.ApplicationDbContext.SaveChanges();
            return new RedirectResult($"~/Album?Id=" + photo.AlbumId);
        }

        public IActionResult Download(Int32 id)
        {
            Photo photo = this.ApplicationDbContext.Photos.Include(x => x.Content).FirstOrDefault(x => x.Id == id);
            if (photo == null)
                return this.NotFound();
            return this.File(photo.Content.Content, ImageHelper.GetTypeMIME(photo.Extension), photo.ToString());
        }
    }
}
