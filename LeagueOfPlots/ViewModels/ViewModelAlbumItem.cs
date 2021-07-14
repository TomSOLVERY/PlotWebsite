using System;
using System.IO;
using LeagueOfPlots.Helpers;
using LeagueOfPlots.Models.Gallery;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfPlots.ViewModels
{
    [ResponseCache(Duration = 30)]
    public class ViewModelAlbumItem
    {
        public ViewModelAlbumItem(Album model)
        {
            this.Id = model.Id;
            this.Thumbnail =  model.CoverPhoto == null ? "data:image/png;base64," + Convert.ToBase64String(File.ReadAllBytes("wwwroot/img/emptyThumbnail.png")) : "data:image/png;base64," + Convert.ToBase64String(model.CoverPhoto.Thumbnail);
            this.PhotoCount = model.PhotoCount;
            this.Name = model.Name;
        }

        public Int32 Id { get; set; }
        public String Thumbnail { get; set; }
        public Int32 PhotoCount { get; set; }
        public String Name { get; set; }

    }
}