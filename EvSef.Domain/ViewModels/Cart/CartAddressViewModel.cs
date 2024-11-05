using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Cart
{
    public class CartAddressViewModel
    {

     
        public int ContactInfoId { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "{0} is required")]
        public string Address { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "{0} is required")]
        public string State { get; set; }

        [Display(Name = "District")]
        [Required(ErrorMessage = "{0} is required")]
        public string District { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "{0} is required")]
        public string ZipCode { get; set; }
        public int? LocationId { get; set; }
    }
    public enum CreateCartAddressResult
    {
        Success,
        NotFound,
        AddressIsExists,

    }
}
