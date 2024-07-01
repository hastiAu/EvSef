using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.MainSlider
{
    public class MainSliderViewModel
    {
        [Display(Name = "Slider Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string SliderTitle { get; set; }

        [Display(Name = "Slider Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string SliderDescription { get; set; }

        [Display(Name = "Slider Image")]
        [MaxLength(200, ErrorMessage = "{0} Length must be less than {1} Character")]

        public string SliderImage { get; set; }

 
    }
}
