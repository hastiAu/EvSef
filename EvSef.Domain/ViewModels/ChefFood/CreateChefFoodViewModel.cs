using EvSef.Domain.Entities.Food;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.ChefFood
{
    public class CreateChefFoodViewModel
    {
       
      
        public int ChefId { get; set; }
        public int FoodSelectedId { get; set; }
   

        [Display(Name = "ChefFood Limit Count")]
        public float ChefFoodLimitCount { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

  
        public int CreatedUser { get; set; }

        [Display(Name = "Chef Food Price")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ChefFoodsPrice { get; set; }

        [Display(Name = "Chef Food Price Discount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ChefFoodPriceDiscount { get; set; }


        [Display(Name = "Price Is Default")]
        public bool ChefFoodPriceIsDefault { get; set; }

        [Display(Name = "PriceType")]
        public  int SelectedPriceType { get; set; }

        [Display(Name = "Chef Food Price From Date")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Date)]

        public DateTime ChefFoodPriceFromDate { get; set; }


        [Display(Name = "ChefFood Price To Date")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Date)]

        public DateTime ChefFoodPriceToDate { get; set; }
    }

    public enum CreateChefFoodResult
    {
        NotFound,
        Success,
        Error
    }
}
