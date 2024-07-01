using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.FoodPrice
{
    public class PriceType
    {
        [Key]
        public int PriceTypeId { get; set; }

        [Display(Name = "Price Type Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string PriceTypeName { get; set; }

        [Display(Name = "Price Type Currency")]
        [Required(ErrorMessage = "{0} is required")]
        public string PriceTypeCurrency{ get; set; }

        [Display(Name = "PriceType Is Default")]
        [Required(ErrorMessage = "{0} is required")]
        public bool PriceTypeIsDefault { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }
        public int CreatedUser { get; set; }
        public bool IsDelete { get; set; }

        #region Relations

        public ICollection<ChefFoodPrice> ChefFoodPrices { get; set; }

        #endregion


    }
}
