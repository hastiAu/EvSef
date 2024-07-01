using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.SiteSetting;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.ViewComponents.JoinCooking
{
    public class JoinCookingViewComponent : ViewComponent
    {

        #region Constructor

        private readonly ISiteService _siteService;

        public JoinCookingViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SiteSettingViewModel? siteSetting = await _siteService.GetSiteSettingForEdit();
            var joinChefTitle = siteSetting.JoinChefTitle;
            ViewData["JoinChefTitle"] = joinChefTitle;
            var joinUs= await _siteService.GetAllJoinUsForShowInSite();
            return await Task.FromResult((IViewComponentResult)View("JoinCooking", joinUs));
        }
    }
}


