using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.SiteSetting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EvSef.Web.ViewComponents
{
    public class SiteFooterViewComponent: ViewComponent
    {
        #region Constructor

        private readonly ISiteService _siteService;

        public SiteFooterViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SiteSettingViewModel? siteSetting = await _siteService.GetSiteSettingForEdit();
            var siteName = siteSetting.SiteName;
            ViewData["SiteName"] = siteName;

            var siteAboutUs = siteSetting.SiteAboutUs;
            ViewData["SiteAboutUs"] = siteAboutUs;

            var siteCopyRight = siteSetting.SiteCopyRight;
            ViewData["SiteCopyRight"] = siteCopyRight;

            var sitePhone = siteSetting.SitePhone;
            ViewData["SitePhone"] = sitePhone;

            var siteCustomerPhone = siteSetting.SiteCustomerPhone;
            ViewData["SiteCustomerPhone"] = siteCustomerPhone;

            var siteEmail = siteSetting.SiteEmail;
            ViewData["SiteEmail"] = siteEmail;

            var siteUrl = siteSetting.SiteUrl;
            ViewData["SiteUrl"] = siteUrl;
            var instagram = await _siteService.GetAllInstagramPostForShowInSite();
             return await Task.FromResult((IViewComponentResult)View("SiteFooter", instagram));
        }
    }
}
