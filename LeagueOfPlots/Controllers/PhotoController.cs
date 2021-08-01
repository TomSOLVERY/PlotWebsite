using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
            List<Int32> photos = this.ApplicationDbContext.Photos.Where(x => x.AlbumId == AlbumId).Select(x => x.Id).ToList();
            Photo photo = this.ApplicationDbContext.Photos.Include(x => x.Album).Include(x => x.Content).FirstOrDefault(x => x.Id == Id);
            if (photo == null || photo.AlbumId != AlbumId)
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

        public async Task<IActionResult> Delete(Int32 Id)
        {
            Photo photo = this.ApplicationDbContext.Photos.FirstOrDefault(p => p.Id == Id);
            if (photo == null)
                return NotFound();
            Int32 albumId = photo.AlbumId;
            this.ApplicationDbContext.Remove(photo);
            await this.ApplicationDbContext.SaveChangesAsync();
            Album album = this.ApplicationDbContext.Albums.FirstOrDefault(x => x.Id == albumId);
            album.PhotoCount--;
            await this.ApplicationDbContext.SaveChangesAsync();
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
