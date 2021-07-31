using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Helpers;
using LeagueOfPlots.Models;
using Microsoft.AspNetCore.Http;

namespace LeagueOfPlots.ViewModels
{
    public class ViewModelProfile
    {
        public ViewModelProfile(ApplicationUser user, ApplicationDbContext dbContext)
        {
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.Avatar = user.Avatar == null ? "/img/avatar_plot.png" : "data:image/png;base64," + Convert.ToBase64String(user.Avatar);
            this.Instagram = user.Instagram;
            this.Facebook = user.Facebook;
            this.Twitter = user.Twitter;
            this.FauxFrerotLadder = FauxFrerotLadderHelper.LadderToString(dbContext.Users.Select(x => x.FauxFrerotPoints).OrderBy(x => x).Distinct().ToList().IndexOf(user.FauxFrerotPoints) + 1);
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public DateTime BirthDate { get; set; }
        public String Avatar { get; set; }
        public IFormFile AvatarFile { get; set; }
        public String Instagram { get; set; }
        public String Facebook { get; set; }
        public String Twitter { get; set; }
        public String FauxFrerotLadder { get; set; }
    }
}
