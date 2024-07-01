using EvSef.Domain.Entities.Food;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.WeekDayFood
{
    public class CreateWeekDayFoodViewModel
    {
     
        public int SelectedChefFoodId { get; set; }

        [Display(Name = "WeekDay Name")]
        public WeekDayName WeekDayName { get; set; }



        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "Is Active")]

        public bool IsActive { get; set; }
        public int CreatedUser { get; set; }
    }

    public enum CreateWeekDayFoodResult
    {
        Success,
        NotFound,
        Error

    }
}
