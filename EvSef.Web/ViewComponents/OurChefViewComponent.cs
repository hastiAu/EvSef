using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.SiteSetting;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.ViewComponents
{
    public class OurChefViewComponent: ViewComponent
    {

        #region Constructor

        private readonly ISiteService _siteService;
        private readonly IUserService _userService;

        public OurChefViewComponent(ISiteService siteService, IUserService userService)
        {
            _siteService = siteService;
            _userService = userService;
        }

        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SiteSettingViewModel? siteSetting = await _siteService.GetSiteSettingForEdit();
            var text = siteSetting.OurChefTitle;
            ViewData["OurChefTitle"] = text;
            var instagramUrl= siteSetting.InstagramUrl;
            ViewData["InstagramUrl"]= instagramUrl;
            var chef = await _userService.GetAllChefForShowInSite();
            return await Task.FromResult((IViewComponentResult)View("OurChef", chef));
        }
    }
}
