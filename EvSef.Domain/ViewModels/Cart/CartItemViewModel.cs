using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Cart
{
    public class CartItemViewModel
    {
        public int ClientId { get; set; }
        public int ChefFoodId { get; set; }

        [Display(Name = "Food Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FoodTitle { get; set; }

        [Display(Name = "Food Image")]
        public string? ImageFood { get; set; }

        [Display(Name = "Chef Food Price")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ChefFoodsPrice { get; set; }

        public int Quantity { get; set; }

      
    }
  
}
