using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.MainSlider;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class MainSliderController : BaseAdminController
    {

        #region Constructor

        private readonly ISiteService _siteService;


        public MainSliderController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion

        #region MainSlider List


        [HttpGet]
        [Route("MainSliderList")]
        public async Task<IActionResult> Index(FilterMainSliderViewModel filterMainSlider)
        {
            var result = await _siteService.FilterMainSliderList(filterMainSlider);
            return View(result);
        }


        #endregion


        #region Create MainSlider

        [HttpGet]
        [Route("CreateMainSlider")]
        public IActionResult CreateMainSlidersByAdmin()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateMainSlider")]
        public async Task<IActionResult> CreateMainSlidersByAdmin(CreateMainSliderViewModel createMainSliderViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _siteService.CreateMainSliderByAdmin(createMainSliderViewModel);


                switch (result)
                {
                    case CreateMainSliderResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateMainSliderResult.MainSliderTitleIsExist:
                        ModelState.AddModelError("AboutUsTitle",
                            "The MainSlider Title was Registered before by this Title!");

                        return View(createMainSliderViewModel);

                    case CreateMainSliderResult.Success:
                        ViewBag.SuccessText = "The MainSlider Was Created Successfully";
                        return RedirectToAction("Index", "MainSlider");
                }
            }

            return View(createMainSliderViewModel);
        }



        #endregion
    }
}