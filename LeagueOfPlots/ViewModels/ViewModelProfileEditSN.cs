using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Helpers;
using LeagueOfPlots.Models;

namespace LeagueOfPlots.ViewModels
{
    public class ViewModelProfileEditSN
    {
        public ViewModelProfileEditSN() { }
        public ViewModelProfileEditSN(ApplicationUser user)
        {
            this.Facebook = SocialNetworksConstants.Facebook + user.Facebook;
            this.Twitter = SocialNetworksConstants.Twitter + user.Twitter;
            this.Instagram = SocialNetworksConstants.Instagram + user.Instagram;
        }

        [RegularExpression(@"https:\/\/www.facebook.com\/[a-z.0-9]*", ErrorMessage ="Lien du profil Facebook incorrect")]
        public String Facebook { get; set; }
        [RegularExpression(@"https:\/\/twitter.com\/[a-zA-Z0-9._-]*", ErrorMessage = "Lien du profil Twitter incorrect")]
        public String Twitter { get; set; }
        [RegularExpression(@"https:\/\/www.instagram.com\/[a-zA-Z0-9\/._-]*", ErrorMessage = "Lien du profil Instagram incorrect")]
        public String Instagram { get; set; }

        public void UpdateModel(ApplicationUser model)
        {
            model.Facebook = this.Facebook?.Split(SocialNetworksConstants.Facebook)[1] ?? String.Empty;
            model.Twitter = this.Twitter?.Split(SocialNetworksConstants.Twitter)[1] ?? String.Empty;
            model.Instagram = this.Instagram?.Split(SocialNetworksConstants.Instagram)[1] ?? String.Empty;
        }
    }
}
