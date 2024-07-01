using EvSef.Core.Services.Implementations;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.Chef;
using EvSef.Domain.ViewModels.SiteSetting;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Controllers
{
    
    public class ChefController : SiteBaseController 
    {
        #region Constructor

        private readonly IUserService _userService;
        private readonly ISiteService _siteService;

        public ChefController(IUserService userService, ISiteService siteService)
        {
            _userService = userService;
            _siteService = siteService;
        }

        #endregion

        [HttpGet]
        [Route("ChefRequest")]
        public async Task<IActionResult> CreateChefRequestInSite()
        {
            var state = await _siteService.GetStates();
            ViewData["State"] = state;

            var firstLocationId = state.First().LocationId;
            var district = await _siteService.GetDistricts(firstLocationId);
            ViewData["District"] = district;

            SiteSettingViewModel? siteSetting = await _siteService.GetSiteSettingForEdit();
            var beChefTitle = siteSetting.BeChefTitle;
            ViewData["BeChefTitle"] = beChefTitle;

            var beChefDescription = siteSetting.BeChefDescription;
            ViewData["BeChefDescription"] = beChefDescription;

            var chefImage = siteSetting.BeChefImage;
            ViewData["ChefImage"] = chefImage;



            return View();
        }

        [HttpPost]
        [Route("ChefRequest")]
        public async Task<IActionResult> CreateChefRequestInSite(ChefRequestInSitViewModel registerNewChefInSitViewModel)
        {

            SiteSettingViewModel? siteSetting = await _siteService.GetSiteSettingForEdit();
            var beChefTitle = siteSetting.BeChefTitle;
            ViewData["BeChefTitle"] = beChefTitle;

            var beChefDescription = siteSetting.BeChefDescription;
            ViewData["BeChefDescription"] = beChefDescription;

            var result = await _userService.CreateChefRequestInSite(registerNewChefInSitViewModel);

            switch (result)
            {
                case ChefRequestInSiteResult.Failed:
                    return RedirectToAction("NotFound");

                case ChefRequestInSiteResult.UserHasRequestWithThisNumber:
                    ModelState.AddModelError("Email", "You have sent a request Before, Please Wait our Staff calling you!");
                    await GetStateAndDistricts();
                    return View(registerNewChefInSitViewModel);
                case ChefRequestInSiteResult.Successfully:
                    TempData[SuccessMessage] = "Your Request was sent, Please wait to Our call !";
                    return RedirectToAction("Index", "Home");

            }
            await GetStateAndDistricts();
            ViewBag.ErrorText = "Your Request Was Not Created Successfully";
            return View(registerNewChefInSitViewModel);
        }

        public async Task GetStateAndDistricts()
        {
            var state = await _siteService.GetStates();
            ViewData["State"] = state;

            var firstLocationId = state.First().LocationId;
            var district = await _siteService.GetDistricts(firstLocationId);
            ViewData["District"] = district;

        }

        public async Task<IActionResult> GetDistrictGroup(int id)
        {
            var district = await _siteService.GetDistricts(id);
            return Json(district);
        }
    }
}
