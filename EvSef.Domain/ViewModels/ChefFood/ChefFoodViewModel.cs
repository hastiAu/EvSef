using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.ChefFood
{
    public class ChefFoodViewModel
    {
        public int ChefId { get; set; }
        public int ChefFoodId { get; set; }

        [Display(Name = "Food Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FoodTitle { get; set; }

        public int  FoodId { get; set; }

        public string ChefName { get; set; }

    }
}
