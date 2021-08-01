using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models;

namespace LeagueOfPlots.ViewModels
{
    public class ViewModelLadder
    {
        public ViewModelLadder() { }
        public ViewModelLadder(List<ApplicationUser> users) {
            this.Rows = users.Select(x => new ViewModelLadderRow(x, users.Select(x => x.FauxFrerotPoints).OrderBy(x => x).Distinct().ToList())).ToList();
        }
        public List<ViewModelLadderRow> Rows { get; set; }
    }
}
