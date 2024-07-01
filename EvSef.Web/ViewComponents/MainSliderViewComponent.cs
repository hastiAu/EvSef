using EvSef.Core.Services.Implementations;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.SiteSetting;
using EvSef.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.ViewComponents
{
 
    public class MainSliderViewComponent: ViewComponent
    {
        #region Constructor

        private readonly IUserService _userService;
        private readonly ISiteService _siteService;

        public MainSliderViewComponent(IUserService userService, ISiteService siteService)
        {
            _userService = userService;
            _siteService = siteService;
        }

        #endregion
        public async Task<IViewComponentResult> InvokeAsync()

        {

           var text = await _siteService.GetSiteSettingForEdit();
           var corporationFormTitle1 = text.CorporationFormTitle1;
            ViewData["CorporationFormTitle1"]= corporationFormTitle1;
            var corporationFormTitle2 = text.CorporationFormTitle2;
            ViewData["CorporationFormTitle2"] = corporationFormTitle1;
            ViewData["SliderPhotoFile"] = text.SliderPhoto;

            var mainSlider = await _siteService.GetAllMainSliderForShowInSite();
            ViewData["MainSlider"] = mainSlider;
            return await Task.FromResult((IViewComponentResult)View("MainSlider"));
        }
    }
}
