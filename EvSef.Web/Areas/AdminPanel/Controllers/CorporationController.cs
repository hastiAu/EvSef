using EvSef.Core.Convertors;
using EvSef.Core.Services.Implementations;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.Corporation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;
using EvSef.Domain.ViewModels.CorporationFood;
using EvSef.Web.Identity;
using EvSef.Domain.ViewModels.CorporationFoodOrder;
using EvSef.Domain.Entities.Account;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class CorporationController : BaseAdminController
    {
        #region Constructor

        private readonly IUserService _userService;
        private readonly ISiteService _siteService;
        private readonly IFoodService _foodService;
        private readonly IViewRenderService _viewRender;

        public CorporationController(IUserService userService, ISiteService siteService, IFoodService foodService, IViewRenderService viewRender)
        {
            _userService = userService;
            _siteService = siteService;
            _foodService = foodService;
            _viewRender = viewRender;
        }

        #endregion

        #region FilterCorporationRequest

        public async Task<IActionResult> Index(FilterCorporationRequestViewModel filterCorporationRequest)
        {
            var result = await _userService.FilterCorporationRequest(filterCorporationRequest);
            return View(result);
        }


        #endregion

        #region CorporationList
        public async Task<IActionResult> CorporationList(CorporationListViewModel filterCorporationList)
        {
            var result = await _userService.FilterCorporationList(filterCorporationList);
            return View(result);
        }



        #endregion

        #region SetToIsCalledStatuse

        public async Task<IActionResult> SetToIsCalledStatus(int id)
        {
            var result = await _userService.SetToIsCalledStatus(id);

            switch (result)
            {
                case CorporationRequest.NotFound:
                    return View("NotFound");

                case CorporationRequest.Success:
                    return Json(new
                    {
                        text = "The user was contacted",
                        statusCode = HttpStatusCode.OK

                    });
            }

            return RedirectToAction("NotFound", "Home");
        }

        #endregion

        #region SetToNotCalledStatuse

        public async Task<IActionResult> SetToNotCalledStatus(int id)
        {
            var result = await _userService.SetToNotCalledStatus(id);

            switch (result)
            {
                case CorporationRequest.NotFound:
                    return View("NotFound");

                case CorporationRequest.Success:
                    return Json(new
                    {
                        text = "The user could not be contacted",
                        statusCode = HttpStatusCode.OK

                    });
            }

            return RedirectToAction("NotFound", "Home");
        }

        #endregion

        #region GetStateAndDistricts




        public async Task GetStateAndDistricts()
        {
            var state = await _siteService.GetStates();
            ViewData["State"] = state;

            var firstLocationId = state.First().LocationId;
            var district = await _siteService.GetDistricts(firstLocationId);
            ViewData["District"] = district;

        }
        #endregion


        #region Create Corporation By Admin


        [HttpGet]
        [Route("CreateCorporationUser")]
        public async Task<IActionResult> CreateCorporationByAdmin()
        {
            var state = await _siteService.GetStates();
            ViewData["State"] = state;

            var firstLocationId = state.First().LocationId;
            var district = await _siteService.GetDistricts(firstLocationId);
            ViewData["District"] = district;

            return View();
        }


        [HttpPost]
        [Route("CreateCorporationUser")]
        public async Task<IActionResult> CreateCorporationByAdmin(CreateCorporationViewModel createCorporationViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateCorporationByAdmin(createCorporationViewModel);

                switch (result)
                {
                    case CreateCorporationResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateCorporationResult.MobileNumberIsExists:
                        ModelState.AddModelError("Mobile",
                            "The Corporation was Registered before by this Mobile Number!");
                        await GetStateAndDistricts();
                        return View(createCorporationViewModel);

                    case CreateCorporationResult.EmailIsExists:
                        ModelState.AddModelError("Email", "The Corporation was Registered Before by this Email!");
                        await GetStateAndDistricts();
                        return View(createCorporationViewModel);

                    case CreateCorporationResult.Success:
                        ViewBag.SuccessText = "Corporation Was Created Successfully";
                        return RedirectToAction("CorporationList", "Corporation");
                }

            }

            await GetStateAndDistricts();
            ViewBag.ErrorText = "Corporation Was Not Created Successfully";
            return View(createCorporationViewModel);


        }
        #endregion


        #region RegisterCorporationByAdmin
        [Route("RegisterCorporationByAdmin")]
        public async Task<IActionResult> RegisterCorporationByAdmin(int id)
        {


            RegisterCorporationResult result = await _userService.RegisterCorporationByAdmin(id);


            switch (result)
            {
                case RegisterCorporationResult.IsExistCorporationMobile:
                    {
                        return Json(new
                        {
                            text = "User was Registered before with this Number!"
                        });
                    }


                case RegisterCorporationResult.NotFound:

                    {
                        return Json(new
                        {
                            text = "Not Found"
                        });
                    }


                case RegisterCorporationResult.Successful:
                    {

                        return Json(new
                        {
                            text = "Corporation was Registered, Sent Login Information to User's Email",
                            StatusCode = HttpStatusCode.OK,

                        });
                    }

            }

            return View("NotFound");
        }



        #endregion

        #region GetDistrictGroup

        public async Task<IActionResult> GetDistrictGroup(int id)
        {
            var district = await _siteService.GetDistricts(id);
            return Json(district);
        }

        #endregion


        #region Corporation Food Order List

        [HttpGet]
        [Route("CorporationFoodOrderList")]
        public async Task<IActionResult> CorporationFoodOrderList(FilterCorporationFoodOrder filter)
        {
            if (filter.CorporationId <= 0)
            {
                return NotFound();
            }

            var orders = await _foodService.GetOrdersByCorporationId(filter.CorporationId,filter);

            ViewBag.CorporationId = filter.CorporationId;

            return View(orders);
        }

        #endregion


        #region Create CorporationFood Order


        [HttpGet]
        [Route("CreateCorporationFoodOrder")]
        
        public async Task<IActionResult> CreateCorporationFoodOrder(int corporationId)
        {
            if (corporationId <= 0) return NotFound();
            var corporation = await _foodService.GetCorporationById(corporationId);
            await GetAllChefFoodByName();
            await GetAllFoodList();
            await GetAllFoodPriceType();
            return View(corporation);
        }

        [HttpPost]
        [Route("CreateCorporationFoodOrder")]
        public async Task<IActionResult> CreateCorporationFoodOrder(CreateCorporationFoodViewModel createCorporationFoodViewModel)
        {
            var result = await _foodService.CreateCorporationFood(createCorporationFoodViewModel);

            switch (result)
            {
                case CreateCorporationFoodResult.NotFound:
                    return RedirectToAction("NotFound", "Home");

                case CreateCorporationFoodResult.Error:
                    return RedirectToAction("NotFound", "Home");
                    
 

                case CreateCorporationFoodResult.Success:
                    ViewBag.SuccessText = "Corporation Food Order Was Created Successfully";
                    return RedirectToAction("CorporationFoodOrderList", new { corporationId = createCorporationFoodViewModel.CorporationId });
                    //return RedirectToAction("CorporationFoodOrderList", new { corporationId });


            }


            await GetAllChefFoodByName();
            await GetAllFoodList();
            await GetAllFoodPriceType();
            ViewBag.ErrorText = "Corporation Was Not Created Successfully";
            return View(createCorporationFoodViewModel);
        }

        #endregion




        #region Get All Foods

        public async Task GetAllFoodList()
        {
            var foodList = await _foodService.GetAllFoods();
            ViewData["FoodList"] = foodList;
        }


        #endregion

        #region GetAllFoodPriceType

        public async Task GetAllFoodPriceType()
        {
            var priceType = await _foodService.GetAllFoodPriceType();
            ViewData["PriceType"] = priceType;
        }


        #endregion



        [HttpGet]

        public async Task GetAllChefFoodByName()
        {
            var allChefFoods = await _foodService.GetAllChefFoods();
            ViewData["AllChefFoods"] = allChefFoods;
        }



    }
}