using EvSef.Core.Extensions;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.ViewModels.Cart;
using EvSef.Domain.ViewModels.SiteSetting;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.ViewComponents
{
    public class BasketStatusViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = HttpContext.Session.GetJson<List<CartItemViewModel>>("ses-basket");
            if (cart == null)
            {
                return await Task.FromResult((IViewComponentResult)View("BasketStatus", 0));
            }
            else
            {
                return await Task.FromResult((IViewComponentResult)View("BasketStatus", cart.Sum(m => m.Quantity)));

            }

        }
    }
}
 