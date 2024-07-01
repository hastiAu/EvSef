using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.ViewModels.WeekDayFood;

namespace EvSef.Domain.Entities.Food
{
    public class WeekDayFood
    {
        [Key]
        public int WeekdayFoodId { get; set; }
        public int ChefFoodId { get; set; }

        [Display(Name = "WeekDay Name")]
        public WeekDayName WeekDayName { get; set; }

        [Display(Name = "WeekDay From Date")]
        public DateTime WeekDayFromDate { get; set; }


        [Display(Name = "WeekDay To Date")]
        public DateTime WeekDayToDate { get; set; }


        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Is Active")]
      
        public bool IsActive { get; set; }

        public int CreatedUser { get; set; }

        #region Relations

 
        public ChefFood ChefFood { get; set; }
 

        #endregion
    }

    public enum WeekDayName
    {
        Saturday = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6,


    }
}
