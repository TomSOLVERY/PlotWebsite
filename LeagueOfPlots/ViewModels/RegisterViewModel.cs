using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueOfPlots.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "La clé est requise")]
        [StringLength(50)]
        [Display(Name = "Clé d'inscription")]
        public String KeyRegistration { get; set; }
    }
}
