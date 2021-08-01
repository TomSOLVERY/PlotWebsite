using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models;

namespace LeagueOfPlots.ViewModels
{
    public class ViewModelProfileEditInfo
    {
        public ViewModelProfileEditInfo() { }
        public ViewModelProfileEditInfo(ApplicationUser user)
        {
            this.Email = user.Email;
            this.BirthDate = user.BirthDate;
        }

        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "L'email n'est pas un e-mail valide")]
        [Display(Name = "Email")]
        public String Email { get; set; }
        [Required(ErrorMessage = "La date de naissance est requise")]
        public DateTime BirthDate { get; set; }

        public void UpdateModel(ApplicationUser model)
        {
            model.Email = this.Email;
            model.BirthDate = this.BirthDate;
        }
    }
}
