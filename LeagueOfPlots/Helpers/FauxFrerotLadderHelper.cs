using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models;

namespace LeagueOfPlots.Helpers
{
    public static class FauxFrerotLadderHelper
    {
        public static String LadderToString(Int32 point)
        {
            switch (point)
            {
                case 1:
                    return "1er";
                default:
                    return point + "ème";
            }
        }
    }
}
