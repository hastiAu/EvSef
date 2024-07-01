using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.SiteSetting;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.ViewComponents
{
    public class OurServiceViewComponent: ViewComponent
    {
        #region Constructor

         private readonly ISiteService _siteService;

         public OurServiceViewComponent(ISiteService siteService)
         {
             _siteService = siteService;
         }

         #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SiteSettingViewModel? siteSetting = await _siteService.GetSiteSettingForEdit();
            var text= siteSetting.OurServiceTitle;
            ViewData["OurServiceTitle"] = text;
            var ourService = await _siteService.GetAllOurServiceForShowInSite();
            return await Task.FromResult((IViewComponentResult)View("OurService", ourService));
        }
    }
}
