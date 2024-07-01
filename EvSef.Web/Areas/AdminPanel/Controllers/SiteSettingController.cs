using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.SiteSetting;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class SiteSettingController : BaseAdminController 
    {
        #region Constructor

        private readonly ISiteService   _siteService;

        public SiteSettingController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion

        #region Edit SiteSetting

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var siteSetting = await _siteService.GetSiteSettingForEdit();

            if (siteSetting == null)
                return RedirectToAction("NotFound", "Home");

            return View(siteSetting);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SiteSettingViewModel siteSettingViewModel)
        {


            var siteSetting = await _siteService.UpdateSiteSetting(siteSettingViewModel);

            switch (siteSetting)
            {
                case SiteSettingEditResult.SiteSettingNotFound:
                    ViewBag.ErrorText = "Operation was Failed";
                    return View();

                case SiteSettingEditResult.SiteSettingEdited:
                    ViewBag.SuccessText = "Site Setting was Updated";
                    return View();

            }


            return View(siteSettingViewModel);
        }

        #endregion




    }
}
