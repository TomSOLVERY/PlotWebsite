using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LeagueOfPlots.Helpers;
using LeagueOfPlots.Models;
using LeagueOfPlots.Models.Gallery;
using LeagueOfPlots.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using LeagueOfPlots.Core;
using Microsoft.EntityFrameworkCore;

namespace LeagueOfPlots.Controllers
{
    [Authorize]
    public class AlbumController : BaseController
    {
        
        public AlbumController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager) : base(applicationDbContext, userManager)
        {
          
        }
        public IActionResult Index(Int32 Id)
        {
            List<Album> albums = this.ApplicationDbContext.Albums.ToList();
            Album album = albums.FirstOrDefault(x => x.Id == Id);
            if (album == null)
            {
                return NotFound();
            }
            return View(new ViewModelAlbum(album,albums));
        }

        public IActionResult Delete(Int32 Id)
        {
            Album album = this.ApplicationDbContext.Albums.FirstOrDefault(a => a.Id == Id);
            if (album == null)
                return NotFound();
            this.ApplicationDbContext.Remove(album);
            this.ApplicationDbContext.SaveChanges();
            return new RedirectResult("~/Gallery");
        }

        public async Task<IActionResult> Upload(Int32 id, ICollection<IFormFile> files)
        {
            Album album = this.ApplicationDbContext.Albums.FirstOrDefault(a => a.Id == id);
            foreach (var file in files.Where(f => ImageHelper.IsImageFile(f.FileName)))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    Photo photo = new Photo(album, memoryStream.ToArray(), file.FileName);
                    await this.ApplicationDbContext.AddAsync(photo);
                    album.PhotoCount++;
                    if (album.CoverPhoto == null)
                        album.CoverPhoto = photo;
                }  
            }
            await this.ApplicationDbContext.SaveChangesAsync();
            return new RedirectResult($"~/Album?Id="+album.Id);
        }
    }
}
