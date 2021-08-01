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
        public ViewModelAlbum(Album model, List<Int32> albums)
        {
            this.Id = model.Id;
            this.Name = model.Name;            
            this.Thumbnail = model.CoverPhoto?.Thumbnail == null ? null : "data:image/png;base64," + Convert.ToBase64String(model.CoverPhoto.Thumbnail);
            this.Index = albums.IndexOf(model.Id);
            this.Next = this.Index < albums.Count - 1 ? $"/Album?Id=" + albums[this.Index + 1] : null;
            this.Previous = this.Index > 0 ? $"/Album?Id=" + albums[this.Index - 1] : null;
            this.Photos = new List<ViewModelPhoto>();
            foreach (var photo in model.Photos)
            {
                this.Photos.Add(new ViewModelPhoto(photo, model.Photos.Select(x => x.Id).ToList()));
            }

        }

        public Int32 Id { get; set; }
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
        public String Next { get; set; }
        public String Previous { get; set; }
    }
}
