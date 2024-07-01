using Google.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Food;
using DateTime = System.DateTime;
using EvSef.Domain.Entities.FoodPrice;

namespace EvSef.Domain.Entities.FoodPrice
{
    public class ChefFoodPrice
    {

        [Key]
        public int ChefFoodPriceId { get; set; }
        public int ChefFoodId { get; set; }
        public int PriceTypeId { get; set; }

        [Display(Name = "Chef Food Price")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ChefFoodsPrice { get; set; }

        [Display(Name = "Chef Food Price Discount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ChefFoodPriceDiscount { get; set; }


        [Display(Name = "Price Is Default")]
        public bool ChefFoodPriceIsDefault { get; set; }


        [Display(Name = "Chef Food Price From Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime ChefFoodPriceFromDate { get; set; }


        [Display(Name = "ChefFood Price To Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime ChefFoodPriceToDate { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }
        public int CreatedUser { get; set; }

        #region Relations
        [ForeignKey("PriceTypeId")]
        public PriceType PriceType { get; set; }

        [ForeignKey("ChefFoodId")]
        public ChefFood ChefFood { get; set; }
     
        #endregion
    }
}

  