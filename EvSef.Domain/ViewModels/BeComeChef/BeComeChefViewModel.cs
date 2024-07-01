using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.BeComeChef
{
    public class BeComeChefViewModel
    {
        [Display(Name = "BeCome Chef Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string BeComeChefTitle { get; set; }


        [Display(Name = "BeCome Chef Image")]
        public string? BeComeChefImage { get; set; }
    }
}
