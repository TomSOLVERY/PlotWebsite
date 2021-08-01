using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueOfPlots.Models.Gallery
{
    public interface IPaginator
    {
        String Name { get; }

        String Link { get; }

        String Previous { get; set; }

        String Next { get; set; }
    }
}
