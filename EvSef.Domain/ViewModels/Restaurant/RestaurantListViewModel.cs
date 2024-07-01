using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Restaurant
{
    public class RestaurantListViewModel
    {
        [Display(Name = "Restaurant Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string RestaurantName { get; set; }

        [Display(Name = "Restaurant Url")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        [Url]
        public string RestaurantUrl { get; set; }

    }
}
