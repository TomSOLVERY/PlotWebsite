using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LeagueOfPlots.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<Int32>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Byte[] Avatar { get; set; }
        public String Twitter { get; set; }
        public String Facebook { get; set; }
        public String Instagram { get; set; }
        public Int32 FauxFrerotPoints { get; set; }
    }
}
