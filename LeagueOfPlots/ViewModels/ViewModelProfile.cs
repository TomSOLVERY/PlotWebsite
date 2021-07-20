using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models;
using Microsoft.AspNetCore.Http;

namespace LeagueOfPlots.ViewModels
{
    public class ViewModelProfile
    {
        public ViewModelProfile(ApplicationUser user)
        {
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.Avatar = user.Avatar == null ? "/img/avatar_plot.png" : "data:image/png;base64," + Convert.ToBase64String(user.Avatar);
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public DateTime BirthDate { get; set; }
        public String Avatar { get; set; }
        public IFormFile AvatarFile { get; set; }
    }
}
