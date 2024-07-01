using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.CustomFood
{
    public class CustomFoodViewModel
    {
        [Display(Name = "Custom Food Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string CustomFoodTitle { get; set; }

        [Display(Name = "Custom Food Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string CustomFoodDescription { get; set; }

        [Display(Name = "Custom Food Image")]
        public string CustomFoodImage { get; set; }
    }
}
