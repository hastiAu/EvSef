using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.SiteSetting;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.ViewComponents
{
    public class CustomizeFoodViewComponent:ViewComponent

    {
        #region Constructor

        private readonly ISiteService _siteService;

        public CustomizeFoodViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            SiteSettingViewModel? siteSetting = await _siteService.GetSiteSettingForEdit();
            var sloganTitle = siteSetting.SloganTitle;
            ViewData["SloganTitle"] = sloganTitle;
            var phone = siteSetting.SiteCustomerPhone;
            ViewData["Phone"] = phone;
            var customFood = await _siteService.GetAllCustomFoodForShowInSite();
            return await Task.FromResult((IViewComponentResult)View("CustomizeFood", customFood));
        }
    }
}
