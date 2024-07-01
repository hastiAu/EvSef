using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.SiteSetting;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.ViewComponents
{
    public class WhyUsViewComponent : ViewComponent
    {
        #region Constructor

        private readonly ISiteService _siteService;

        public WhyUsViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {

            SiteSettingViewModel? siteSetting = await _siteService.GetSiteSettingForEdit();
            var reasonChefTitle = siteSetting.ReasonChefTitle;
            ViewData["ReasonBecomeChefTitle"] = reasonChefTitle;
            var whyUs = await _siteService.GetAllBeComeChefForShowInSite();
            return await Task.FromResult((IViewComponentResult)View("WhyUs", whyUs));
        }

    }
}
