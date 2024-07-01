using EvSef.Domain.Entities.UserType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Food;

namespace EvSef.Domain.Entities.OrderDetails
{
    public class OrderDetails

    {
        [Key]
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int ChefFoodId { get; set; }

        [Display(Name = "Food Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderFoodAmount { get; set; }


        [Display(Name = "Order Food TaxAmount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderFoodTaxAmount { get; set; }



        [Display(Name = "Order Food Discount Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderFoodDiscountAmount { get; set; }

        [Display(Name = "Order Food Description")]
        public string OrderFoodDescription { get; set; }

        [Display(Name = "Register Date")]
        public DateTime RegisterDate { get; set; }
        public int CreatedUser { get; set; }



        #region Releation

        public Order.Order Order { get; set; }
        public ChefFood ChefFood { get; set; }

        #endregion
    }
}
