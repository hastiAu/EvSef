 

using DocumentFormat.OpenXml.Spreadsheet;
using EvSef.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.ViewComponents
{
    public class SiteHeaderViewComponent: ViewComponent
    {
        #region Constructor

 
        private readonly ISiteService _siteService;


        public SiteHeaderViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion
        public async Task<IViewComponentResult> InvokeAsync()

        {
            var text = await _siteService.GetSiteSettingForEdit();
            var logo = text.SiteLogo;
            ViewData["Logo"] = logo;

            var restaurantLink = await _siteService.GetAllRestaurantsForShowInSite();
            ViewData["Restaurant"]= restaurantLink;
            return await Task.FromResult((IViewComponentResult)View("SiteHeader") );
        }
    }
}
