using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Helpers;
using LeagueOfPlots.Models;

namespace LeagueOfPlots.ViewModels
{
    public class ViewModelLadderRow
    {
        public ViewModelLadderRow() { }

        public ViewModelLadderRow(ApplicationUser user, List<Int32> points)
        {
            this.Id = user.Id;
            this.Avatar = user.Avatar == null ? "/img/avatar_plot.png" : "data:image/png;base64," + Convert.ToBase64String(user.Avatar);
            this.Name = user.FirstName + " " + user.LastName;
            this.LadderPlace = FauxFrerotLadderHelper.LadderToString(points.IndexOf(user.FauxFrerotPoints) + 1);
            this.Points = user.FauxFrerotPoints;
        }
        public Int32 Id { get; set; }
        public String Avatar { get; set; }
        public String Name { get; set; }
        public String LadderPlace { get; set; }
        public Int32 Points { get; set; }
    }
}
