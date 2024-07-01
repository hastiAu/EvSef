using EvSef.Core.Services.Interfaces;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.SiteSetting;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.ViewComponents.CorporationFoodOrder
{
    public class CorporationFoodOrderViewComponent:ViewComponent
    {

        #region Constructor

        private readonly ISiteService _siteService;
        private readonly IFoodService _foodService;

        public CorporationFoodOrderViewComponent(ISiteService siteService, IFoodService foodService)
        {
            _siteService = siteService;
            _foodService = foodService;
        }

        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SiteSettingViewModel? siteSetting = await _siteService.GetSiteSettingForEdit();
        

            var howOrderCorporationFoodTitle = siteSetting.HowOrderCorporationFoodTitle;
            ViewData["HowOrderCorporationFoodTitle"] = howOrderCorporationFoodTitle;
            var text = await _siteService.GetSiteSettingForEdit();
            var logo = text.SiteLogo;
            ViewData["Logo"] = logo;
       
            var howOrder = await _foodService.GetAllHowOrderCorporationFoodForShowInSite();

            return await Task.FromResult((IViewComponentResult)View("CorporationFoodOrder", howOrder));
        }
    }
}
 
