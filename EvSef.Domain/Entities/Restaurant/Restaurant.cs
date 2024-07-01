using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.Restaurant
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }

        [Display(Name = "Restaurant Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string RestaurantName { get; set; }

        [Display(Name = "Restaurant Url")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        [Url]
        public string RestaurantUrl { get; set; }


        [Display(Name = "Order")]
        public int Order { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }
    }
}
