using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Cart
{
    public class CheckOutViewModel
    {
        public CartAddressViewModel CartAddresses { get; set; }
        public CartDeliveryAndPaymentDetails CartDeliveryDateViewModel { get; set; }


        public decimal Tax { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal FinalPrice { get; set; }
    }

    public enum CheckOutResult
    {
        Success,
        NotFound,
        CheckOutIsExist
    }

    public class CheckOutResultModel
    {
        public CheckOutResult Result { get; set; }
        public string OrderNumber { get; set; }
    }

}
