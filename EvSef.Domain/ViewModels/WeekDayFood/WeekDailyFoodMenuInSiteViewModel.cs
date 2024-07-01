using EvSef.Domain.Entities.Food;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.FoodPrice;

namespace EvSef.Domain.ViewModels.WeekDayFood
{
    public class WeekDailyFoodMenuInSiteViewModel
    {

        public int ChefFoodId { get; set; }

        public string FoodTitle { get; set; }

        [Display(Name = "WeekDay Name")]
        public WeekDayName WeekDayName { get; set; }
     
        [Display(Name = "Food Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string FoodDescription { get; set; }

        [Display(Name = "Chef Food Price")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ChefFoodsPrice { get; set; }
        
        [Display(Name = "Food Image")]
        public string? ImageFood { get; set; }
    }
}
