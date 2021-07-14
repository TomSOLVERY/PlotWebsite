using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LeagueOfPlots.Helpers;

namespace LeagueOfPlots.Models.Gallery
{
    public class Photo
    {
        private Dictionary<int, int> _heights = new Dictionary<int, int>();
        private static Regex _size = new Regex(@"(?<name>.+)-(?<width>[0-9]+)x(?<height>[0-9]+).", RegexOptions.Compiled);

        public Photo() { }

        public Photo(Album album, Byte[] imageBytes, String absoluteName)
        {
            this.Album = album;
            this.Content = new PhotoContent { Id = this.Id, Content = imageBytes };
            this.Name = Path.GetFileNameWithoutExtension(absoluteName);
            this.Extension = Path.GetExtension(absoluteName);
        }

        public Int32 Id { get; set; }
        public Int32 AlbumId { get; set; }
        public virtual PhotoContent Content { get; set; }
        public Byte[] Thumbnail {
            get
            {
                return ImageHelper.Resize(this.Content.Content, 128, 128);
            }
        }
        public String Name { get; set; }
        public String Extension { get; set; }
        public virtual Album Album { get; set; }
        public override string ToString()
        {
            return this.Name + this.Extension;
        }
    }
}
