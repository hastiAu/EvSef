using EvSef.Domain.Entities.Food;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.WeekDayFood
{
    public class WeekdayChefFoodViewModel
    {
        [Display(Name = "Food Title")]
        public string FoodTitle { get; set; }
        public int ChefFoodId { get; set; }
        [Display(Name = "WeekDay Name")]

        public WeekDayName WeekDayName { get; set; }
        public bool IsActive { get; set;}
    }
}


 