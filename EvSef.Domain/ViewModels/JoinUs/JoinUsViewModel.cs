using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.JoinUs
{
    public class JoinUsViewModel
    {
        [Display(Name = "JoinUs Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string JoinUsTitle { get; set; }

        [Display(Name = "JoinUs Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string JoinUsDescription { get; set; }

        [Display(Name = "JoinUs Image")]
        public string? JoinUsImage { get; set; }
    }
}
