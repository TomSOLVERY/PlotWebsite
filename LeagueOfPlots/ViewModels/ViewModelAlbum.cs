using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models;
using LeagueOfPlots.Models.Gallery;

namespace LeagueOfPlots.ViewModels
{
    public class ViewModelAlbum : IPaginator
    {
        public ViewModelAlbum() { }
        public ViewModelAlbum(Album model, List<Album> albums)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Photos = new List<ViewModelPhoto>();
            foreach(var photo in model.Photos)
            {
                this.Photos.Add(new ViewModelPhoto(photo, model.Photos));
            }
            this.Albums = albums;
            this.Thumbnail = model.CoverPhoto?.Thumbnail == null ? null : "data:image/png;base64," + Convert.ToBase64String(model.CoverPhoto.Thumbnail);
            this.Index = albums.IndexOf(model);

        }

        public Int32 Id { get; set; }
        private List<Album> Albums {get; set; }
        private Int32 Index { get; set; }
        public String Name { get; set; }
        public String Thumbnail { get; set; }
        public string Link
        {
            get
            {
                return $"/Album?Id=" + this.Id;
            }
        }
        public List<ViewModelPhoto> Photos { get; set; }
        public IPaginator Next { 
            get {
                if (this.Index < this.Albums.Count - 1)
                    return new ViewModelAlbum(this.Albums[this.Index + 1], this.Albums);
                return null;
            } 
        }
        public IPaginator Previous
        {
            get
            {
                if (this.Index > 0)
                    return new ViewModelAlbum(this.Albums[this.Index - 1], this.Albums);
                return null;
            }
        }
    }
}
