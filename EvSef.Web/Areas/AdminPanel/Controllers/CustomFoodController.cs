using EvSef.Core.Convertors;
using EvSef.Core.Services.Implementations;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.CustomFood;
using EvSef.Domain.ViewModels.OurService;
using EvSef.Domain.ViewModels.SocialMedia;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class CustomFoodController : BaseAdminController
    {
        #region Constructor

        private readonly ISiteService _siteService;


        public CustomFoodController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion

        #region CustomFood List


        [HttpGet]
        [Route("CustomFoodList")]
        public async Task<IActionResult> Index(FilterCustomFoodViewModel filterCustomFoodViewModel)
        {
            var result = await _siteService.FilterCustomFoodList(filterCustomFoodViewModel);
            return View(result);
        }
        #endregion



        #region Cretae Social Media

        [HttpGet]
        [Route("CreateCustomFood")]
        public IActionResult CreateCustomFoodByAdmin()
        {
            return View();
        }



        [HttpPost]
        [Route("CreateCustomFood")]
        public async Task<IActionResult> CreateCustomFoodByAdmin(CreateCustomFoodViewModel createCustomFoodViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _siteService.CreateCustomFoodByAdmin(createCustomFoodViewModel);


                switch (result)
                {
                    case CreateCustomFoodResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateCustomFoodResult.CustomFoodNameIsExist:
                        ModelState.AddModelError("CustomFoodTitle",
                            "The Custom Food Title was Registered before by this Title!");

                        return View(createCustomFoodViewModel);

                    case CreateCustomFoodResult.Success:
                        ViewBag.SuccessText = "The Custom Food Was Created Successfully";
                        return RedirectToAction("Index", "CustomFood");
                }
            }

            return View(createCustomFoodViewModel);
        }
        #endregion

    }
}
