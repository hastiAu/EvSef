using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.PriceType
{
    public class AdminListPriceTypeViewModel
    {
        [Display(Name = "Price Type Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string PriceTypeName { get; set; }

        [Display(Name = "PriceType Is Default")]
        [Required(ErrorMessage = "{0} is required")]
        public bool PriceTypeIsDefault { get; set; }

        public int CreatedUser { get; set; }
    }
}
