using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueOfPlots.Models.Gallery
{
    public class Album
    {
        public Album() { }
        public Album(String name, String username)
        {
            this.Name = name;
            this.AuthorUsername = username;
        }
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String AuthorUsername { get; set; }
        public List<Photo> Photos { get; set; }

        public Photo CoverPhoto { 
            get
            {
                return this.Photos.FirstOrDefault();
            }
        }
        /// <summary>
        /// Sorts the photos in the album.
        /// </summary>
        public void Sort()
        {
            Photos = Photos.OrderBy(p => p.Name).ToList();
        }

    }
}
