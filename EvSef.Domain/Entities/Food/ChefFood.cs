using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.Entities.Food;
using EvSef.Domain.Entities.FoodPrice;

namespace EvSef.Domain.Entities.Food
{
    public  class ChefFood
    {
        [Key]
        public int ChefFoodId { get; set; }
        public int FoodId { get; set;}
        public int ChefId  { get; set; }

        [Display(Name = "ChefFood Limit Count")]
        public float ChefFoodLimitCount { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }
        public int CreatedUser { get; set; }

        #region Relations

        [ForeignKey("ChefId")]
        public Chef Chef { get; set; }

        //[ForeignKey("FoodId")]
        public Food Food { get; set; }
        public ICollection<ChefFoodPrice>ChefFoodPrices{ get; set; }
        public ICollection<WeekDayFood> WeekDayFoods { get; set; }
        public ICollection<CorporationFood> CorporationFoods { get; set; }

        public OrderDetails.OrderDetails OrderDetails { get; set; }

        #endregion

    }
}
 
 