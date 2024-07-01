using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Wallet;

namespace EvSef.Domain.ViewModels.Cart
{
    public class CartDeliveryAndPaymentDetails
    {

        [Required(ErrorMessage = "Delivery date is required.")]
        [Display(Name = "Delivery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = "Delivery time is required.")]
        [Display(Name = "Delivery Time")]
        public TimeSpan DeliveryTime { get; set; }

        [Required(ErrorMessage = "Details is required.")]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required(ErrorMessage = "PaymentMethod is required.")]
        [Display(Name = "Payment Method")]
        public PaymentType PaymentMethod { get; set; }
    

    }
}
