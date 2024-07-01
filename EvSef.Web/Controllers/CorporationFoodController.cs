using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.SiteSetting;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Controllers
{
    public class CorporationFoodController : Controller
    {

        #region Constructor

        private readonly ISiteService _siteService;

        public CorporationFoodController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion


        [Route("CorporationFood")]
        public async Task< IActionResult> CorporationFood()
        {
            SiteSettingViewModel? siteSetting = await _siteService.GetSiteSettingForEdit();
            var corporationFoodTitle = siteSetting.CorporationFoodTitle;
            ViewData["CorporationFoodTitle"] = corporationFoodTitle;

            var corporationFoodDescription = siteSetting.CorporationFoodDescription;
            ViewData["CorporationFoodDescription"] = corporationFoodDescription;
            return View();
        }
    }
}
