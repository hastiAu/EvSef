using EvSef.Domain.Entities.FoodPrice;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.Food
{
    public class CorporationFood
    {
        [Key]
        public int CorporationFoodId { get; set; }

        public int CorporationId { get; set; }
        public int ChefFoodId { get; set; }

        [Display(Name = "FoodAmount")]
        public int FoodAmount { get; set; }

        public  WeekDayName WeekDayName { get; set; }


        [Display(Name = "Corporation Order From Date")]
        [DataType(DataType.Date)]
        public DateTime CorporationOrderFromDate { get; set; }


        [Display(Name = "Corporation Order To Date")]
        [DataType(DataType.Date)]
        public DateTime CorporationOrderToDate { get; set; }


        [Display(Name = "Is Delete")]
        public bool IsDelete { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }
        public int CreatedUser { get; set; }


        #region Relations


        public ICollection<ChefFood> ChefFoods { get; set; }

        #endregion
    }
}
