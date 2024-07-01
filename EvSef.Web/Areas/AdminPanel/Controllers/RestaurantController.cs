using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.BeComeChef;
using EvSef.Domain.ViewModels.Restaurant;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class RestaurantController : BaseAdminController
    {
        #region Constructor

        private readonly ISiteService _siteService;


        public RestaurantController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion

        [HttpGet]
        [Route("RestaurantList")]
        public async Task<IActionResult> Index(FilterRestaurantViewModel filterRestaurantViewModel)
        {
            var result = await _siteService.FilterRestaurantList(filterRestaurantViewModel);
            return View(result);
        }

        #region CreaterestaurantByAdmin

        [HttpGet]
        [Route("CreateRestaurant")]
        public IActionResult CreateRestaurantByAdmin()
        {
            return View();
        }



        [HttpPost]
        [Route("createRestaurant")]
        public async Task<IActionResult> CreateRestaurantByAdmin(CreateRestaurantViewModel createRestaurantViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _siteService.CreateRestaurantByAdmin(createRestaurantViewModel);


                switch (result)
                {
                    case CreateRestaurantResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateRestaurantResult.RestaurantNameIsExist:
                        ModelState.AddModelError("RestaurantName",
                            "The Restaurant Name was Registered before by this Name!");

                        return View(createRestaurantViewModel);

                    case CreateRestaurantResult.Success:
                        ViewBag.SuccessText = "The Restaurant Name Was Created Successfully";
                        return RedirectToAction("Index", "Restaurant");
                }
            }

            return View(createRestaurantViewModel);
        }



        #endregion
    }
}
