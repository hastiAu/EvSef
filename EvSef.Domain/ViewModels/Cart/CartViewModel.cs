using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.ViewModels.Cart;

namespace EvSef.Domain.ViewModels.Cart

{
    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
        public List<CartAddressViewModel> CartAddresses { get; set; }
        public CartDeliveryAndPaymentDetails CartDeliveryDateViewModel { get; set; }
        public int SelectedContactInfoId { get; set; }

        public decimal Tax { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(item => item.ChefFoodsPrice * item.Quantity);
            }
        }

        public decimal FinalPrice
        {
            get
            {
                return TotalPrice + (TotalPrice * Tax / 100);
            }
        }

        public enum CartViewModelResult
        {
            CartCreatedSuccess,
            CartCreatedFail,
            CartNotFound
        }
    }

}

