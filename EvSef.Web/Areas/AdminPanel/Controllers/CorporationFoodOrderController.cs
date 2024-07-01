using EvSef.Core.Convertors;
using EvSef.Core.Services.Implementations;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.CorporationFoodOrder;
using EvSef.Domain.ViewModels.OurCustomer;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class CorporationFoodOrderController : BaseAdminController
    {

        #region Constructor


        private readonly IFoodService _foodService;

        public CorporationFoodOrderController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        #endregion

        #region CorporationFoodList

        [HttpGet]
        [Route("CorporationFoodList")]
        public async Task<IActionResult> CorporationFoodOrderList(FilterCorporationFoodOrderViewModel filterCorporationFoodOrderViewModel)
        {
            var result = await _foodService.FilterCorporationFoodOrderList(filterCorporationFoodOrderViewModel);
            return View(result);
        }


        #endregion

        #region CreateCorporationFoodOrderByAdmin
        [HttpGet]
        [Route("CreateCorporationFoodOrderByAdmin")]
        public IActionResult CreateCorporationFoodOrderByAdmin()
        {
            return View();
        }


        [HttpPost]
        [Route("CreateCorporationFoodOrderByAdmin")]
        public async Task<IActionResult> CreateCorporationFoodOrderByAdmin(CreateCorporationFoodOrderViewModel createCorporationFoodOrderViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _foodService.CreateCorporationFoodByAdmin(createCorporationFoodOrderViewModel);


                switch (result)
                {
                    case CreateCorporationFoodOrderResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateCorporationFoodOrderResult.CorporationFoodOrderIsExist:
                        ModelState.AddModelError("Title",
                            "The How Order was Registered before by this Title!");

                        return View(createCorporationFoodOrderViewModel);

                    case CreateCorporationFoodOrderResult.Success:
                        ViewBag.SuccessText = "Corporation Food Order Was Created Successfully";
                        return RedirectToAction("CorporationFoodOrderList", "CorporationFoodOrder");
                }
            }

            return View(createCorporationFoodOrderViewModel);
        }

        #endregion
    }
}
