using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.AboutUs
{
    public class AboutUsViewModel
    {

        [Display(Name = "AboutUs Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string AboutUsTitle { get; set; }

        [Display(Name = "AboutUs Description")]
        [MaxLength(1000, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string AboutUsDescription { get; set; }

        [Display(Name = "AboutUs Image 1")]
        [Required(ErrorMessage = "{0} is required")]
        public string AboutUsImage1 { get; set; }

        [Display(Name = "AboutUs Image 2")]
        [Required(ErrorMessage = "{0} is required")]
        public string AboutUsImage2 { get; set; }
    }
}
