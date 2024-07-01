using EvSef.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.ViewComponents
{
    public class OurCustomerViewComponent: ViewComponent
    {
        #region Constructor

      
        private readonly ISiteService _siteService;

        public OurCustomerViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ourCustomer = await _siteService.GetAllOurCustomerForShowInSite();
            return await Task.FromResult((IViewComponentResult)View("OurCustomer", ourCustomer));
        }
    }
}
