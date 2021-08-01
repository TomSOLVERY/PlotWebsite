using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models.Gallery;

namespace LeagueOfPlots.ViewModels
{
    public class ViewModelPhoto : IPaginator
    {
        public ViewModelPhoto() { }
        public ViewModelPhoto(Photo model, List<Int32> photos)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.AlbumLink = $"/Album?Id=" + model.AlbumId;
            this.AlbumName = model.Album.Name;
            this.Content = "data:image/png;base64," + Convert.ToBase64String(model.Content.Content);
            this.Thumbnail = model.Thumbnail == null ? null : "data:image/png;base64," + Convert.ToBase64String(model.Thumbnail);
            this.AlbumId = model.AlbumId;
            this.Index = photos.IndexOf(model.Id);
            this.Next = this.Index < photos.Count - 1 ? $"/Photo?AlbumId=" + this.AlbumId + "&Id=" + photos[this.Index + 1] : null;
            this.Previous = this.Index > 0 ? $"/Photo?AlbumId=" + this.AlbumId + "&Id=" + photos[this.Index - 1] : null;
        }

        public Int32 Id { get; set; }

        public String Thumbnail { get; set; }
        public String Content { get; set; }
        public String Name { get; set; }
        public Int32 AlbumId { get; set; }
        public String AlbumLink { get; set; }
        public String AlbumName { get; set; }
        private Int32 Index { get; set; }
        public string Link
        {
            get
            {
                return $"/Photo?AlbumId="+this.AlbumId+"&Id="+ this.Id;
            }
        }
        public String Next { get; set; }

        public String Previous { get; set; }
    }
}
