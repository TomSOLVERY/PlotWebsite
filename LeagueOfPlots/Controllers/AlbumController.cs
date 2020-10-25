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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfPlots.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        
        public AlbumController(AlbumCollection ac, IWebHostEnvironment environment, ImageProcessor processor)
        {
            _ac = ac;
            _environment = environment;
            _processor = processor;
        }

        private AlbumCollection _ac;
        private IWebHostEnvironment _environment;
        private ImageProcessor _processor;
        public IActionResult Index(string name)
        {
            Album album = _ac.Albums.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (album == null)
            {
                return NotFound();
            }
            return View(new ViewModelAlbum { Album = album });
        }

        public IActionResult Delete(string name)
        {
            string path = Path.Combine(_environment.WebRootPath, "albums", name);

            if (Directory.Exists(path))
                Directory.Delete(path, true);

            var album = _ac.Albums.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (album != null)
            {
                _ac.Albums.Remove(album);
            }

            return new RedirectResult("~/");
        }

        public IActionResult Create(string name)
        {
            string path = Path.Combine(_environment.WebRootPath, "albums", name);

            Directory.CreateDirectory(path);
            var album = new Album(path, _ac);
            _ac.Albums.Insert(0, album);
            _ac.Sort();

            return new RedirectResult($"~/Album?name={WebUtility.UrlEncode(name).Replace('+', ' ')}");
        }

        public async Task<IActionResult> Upload(string name, ICollection<IFormFile> files)
        {
            var album = _ac.Albums.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            foreach (var file in files.Where(f => _ac.IsImageFile(f.FileName)))
            {
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(_environment.WebRootPath, "albums", album.Name, Path.GetFileName(fileName));

                if (System.IO.File.Exists(filePath))
                {
                    filePath = Path.ChangeExtension(filePath, file.GetHashCode() + Path.GetExtension(filePath));
                }

                using (var imageStream = file.OpenReadStream())
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    _processor.CreateThumbnails(imageStream, filePath);
                    await file.CopyToAsync(fileStream);
                }

                var photo = new Photo(album, new FileInfo(filePath));
                album.Photos.Insert(0, photo);
            }

            album.Sort();

            return new RedirectResult($"~/Album?name={WebUtility.UrlEncode(name).Replace('+', ' ')}");
        }
    }
}
