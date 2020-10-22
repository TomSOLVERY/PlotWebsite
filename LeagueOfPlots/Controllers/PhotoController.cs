using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LeagueOfPlots.Models.Gallery;
using LeagueOfPlots.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfPlots.Controllers
{
    [Authorize]
    public class PhotoController : Controller
    {
        private AlbumCollection _ac;
        private IWebHostEnvironment _environment;

        public PhotoController(AlbumCollection ac, IWebHostEnvironment environment)
        {
            _ac = ac;
            _environment = environment;
        }
        public IActionResult Index(string albumName, string photoName)
        {
            var album = _ac.Albums.FirstOrDefault(a => a.Name.Equals(albumName, StringComparison.OrdinalIgnoreCase));
            Photo photo = album.Photos.FirstOrDefault(p => p.DisplayName.Equals(photoName, StringComparison.OrdinalIgnoreCase));
            return View(new ViewModelPhoto { Photo = photo});
        }

        public IActionResult Rename(string albumName, string photoName)
        {
            var album = _ac.Albums.FirstOrDefault(a => a.Name.Equals(albumName, StringComparison.OrdinalIgnoreCase));
            Photo photo = album.Photos.FirstOrDefault(p => p.DisplayName.Equals(photoName, StringComparison.OrdinalIgnoreCase));
            string name = Request.Form["name"] + Path.GetExtension(photo.AbsolutePath);

            var newPhotoPath = new FileInfo(Path.Combine(album.AbsolutePath, name));
            int index = album.Photos.IndexOf(photo);

            System.IO.File.Move(photo.AbsolutePath, newPhotoPath.FullName);
            var newPhoto = new Photo(album, newPhotoPath);

            album.Photos.Insert(index, newPhoto);
            album.Photos.RemoveAt(index + 1);

            // Rename thumbnails
            string folder = Path.Combine(album.AbsolutePath, "thumbnail");
            var pattern = $"{photo.DisplayName}-*x*{Path.GetExtension(photo.AbsolutePath)}";

            foreach (var file in Directory.EnumerateFiles(folder, pattern))
            {
                string newThumbnail = Path.Combine(folder, Path.GetFileName(file).Replace(photo.DisplayName, newPhoto.DisplayName));
                System.IO.File.Move(file, newThumbnail);
            }

            photo.Album.Sort();

            return new RedirectResult($"~/photo?albumName={WebUtility.UrlEncode(albumName).Replace('+', ' ')}&photoName={newPhoto.DisplayName}");

        }

        public IActionResult Delete(string albumName, string photoName)
        {
            var album = _ac.Albums.FirstOrDefault(a => a.Name.Equals(albumName, StringComparison.OrdinalIgnoreCase));
            Photo photo = album.Photos.FirstOrDefault(p => p.DisplayName.Equals(photoName, StringComparison.OrdinalIgnoreCase));
            album.Photos.Remove(photo);

            if (System.IO.File.Exists(photo.AbsolutePath))
            {
                System.IO.File.Delete(photo.AbsolutePath);
                string folder = Path.Combine(album.AbsolutePath, "thumbnail");
                var pattern = $"{photo.DisplayName}-*x*{Path.GetExtension(photo.AbsolutePath)}";

                foreach (var file in Directory.EnumerateFiles(folder, pattern))
                {
                    System.IO.File.Delete(file);
                }
            }

            return new RedirectResult($"~/Album?name={WebUtility.UrlEncode(albumName).Replace('+', ' ')}");
        }
    }
}
