using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models.Gallery;

namespace LeagueOfPlots.ViewModels
{
    public class ViewModelGallery
    {
        public ViewModelGallery() { }

        public ViewModelGallery(List<Album> models)
        {
            Albums = new List<ViewModelAlbumItem>();
            foreach(var model in models)
            {
                Albums.Add(new ViewModelAlbumItem(model));
            }
        }
        public List<ViewModelAlbumItem> Albums { get; set; }
    }
}
