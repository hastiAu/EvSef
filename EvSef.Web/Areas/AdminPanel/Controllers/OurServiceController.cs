using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.OurCustomer;
using EvSef.Domain.ViewModels.OurService;
using EvSef.Domain.ViewModels.Restaurant;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class OurServiceController : BaseAdminController
    {
        #region Constructor

        private readonly ISiteService _siteService;


        public OurServiceController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion

        [HttpGet]
        [Route("OurServiceList")]
        public async Task<IActionResult> Index(FilterOurServiceViewModel filterOurServiceViewModel)
        {
            var result = await _siteService.FilterOurServiceList(filterOurServiceViewModel);
            return View(result);
        }

        #region CreaterestaurantByAdmin

        [HttpGet]
        [Route("CreateOurService")]
        public IActionResult CreateOurServiceByAdmin()
        {
            return View();
        }



        [HttpPost]
        [Route("CreateOurService")]
        public async Task<IActionResult> CreateOurServiceByAdmin(CreateOurServiceViewModel createOurServiceViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _siteService.CreateOurServiceByAdmin(createOurServiceViewModel);


                switch (result)
                {
                    case CreateOurServiceResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateOurServiceResult.OurServiceTitleIsExist:
                        ModelState.AddModelError("OurServiceTitle",
                            "OurService was Registered before by this Title!");

                        return View(createOurServiceViewModel);

                    case CreateOurServiceResult.Success:
                        ViewBag.SuccessText = "OurService Was Created Successfully";
                        return RedirectToAction("Index", "OurService");
                }
            }

            return View(createOurServiceViewModel);
        }



        #endregion
    }
}
