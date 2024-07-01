using System.Net;
using System.Runtime.CompilerServices;
using EvSef.Core.Convertors;
using EvSef.Core.Services.Implementations;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.Chef;
using EvSef.Domain.ViewModels.ChefFood;
using EvSef.Domain.ViewModels.Corporation;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class ChefController : BaseAdminController
    {
        #region Constructor

        private readonly IUserService _userService;
        private readonly IFoodService _foodService;
        private readonly ISiteService _siteService;
        private readonly IViewRenderService _viewRender;


        public ChefController(IUserService userService, IFoodService foodService, ISiteService siteService, IViewRenderService viewRender)
        {
            _userService = userService;
            _foodService = foodService;
            _siteService = siteService;
            _viewRender = viewRender;
        }

        #endregion

        #region Filter Chef List & Request

        public async Task<IActionResult> Index(FilterChefRequestListViewModel filterChefRequestListViewModel)
        {
            var result = await _userService.FilterChefRequestList(filterChefRequestListViewModel);
            return View(result);
        }
        public async Task<IActionResult> FilterChefList(FilterChefListViewModel filterChefListViewModel)
        {
            var result = await _userService.FilterChefList(filterChefListViewModel);
            return View(result);
        }


        #endregion

        #region Create Chef ByAdmin

        [HttpGet]
        [Route("CreateChef")]
        public async Task<IActionResult> CreateNewChef()
        {
            var state = await _siteService.GetStates();
            ViewData["State"] = state;

            var firstLocationId = state.First().LocationId;
            var district = await _siteService.GetDistricts(firstLocationId);
            ViewData["District"] = district;

            return View();
        }



        [HttpPost]
        [Route("CreateChef")]
        public async Task<IActionResult> CreateNewChef(CreateNewChefByAdminViewModel createNewChefByAdmin)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateNewChefByAdmin(createNewChefByAdmin);

                switch (result)
                {
                    case CreateNewChefResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateNewChefResult.MobileNumberIsExists:
                        ModelState.AddModelError("Mobile",
                            "The Chef was Registered before by this Mobile Number!");
                        await GetStateAndDistricts();
                        return View(createNewChefByAdmin);

                    case CreateNewChefResult.EmailIsExists:
                        ModelState.AddModelError("Email", "The Chef was Registered Before by this Email!");
                        await GetStateAndDistricts();
                        return View(createNewChefByAdmin);

                    case CreateNewChefResult.Success:
                        ViewBag.SuccessText = "Chef Was Created Successfully";
                        return RedirectToAction("FilterChefList", "Chef");
                }

            }



            await GetStateAndDistricts();
            ViewBag.ErrorText = "Chef Was Not Created Successfully";
            return View(createNewChefByAdmin);
        }
        #endregion

        #region Register Chef By Admin

        [Route("RegisterChefByAdmin")]
        public async Task<IActionResult> RegisterChefByAdmin(int id)
        {
            RegisterChefResult result = await _userService.RegisterChefByAdmin(id);

            switch (result)
            {
                case RegisterChefResult.IsExistCorporationMobile:
                {
                    return Json(new
                    {
                        text = "User was Registered before with this Number!"
                    });
                }


                case RegisterChefResult.NotFound:

                {
                    return Json(new
                    {
                        text = "Not Found"
                    });
                }


                case RegisterChefResult.Successful:
                {

                    return Json(new
                    {
                        text = "Chef was Registered, Sent Login Information to User's Email",
                        StatusCode = HttpStatusCode.OK,

                    });
                }

            }

            return View("NotFound");
        }


        #endregion


        #region   Chef Food List

        public async Task<IActionResult> ChefFoodList(FilterChefFoodListViewModel filterFoodListViewModel)
        {
           
      
            var result = await _foodService.FilterChefFoodList(filterFoodListViewModel);

            await GetAllFoodList();
            await GetAllFoodPriceType();
            return View(result);
        }


        #endregion

        #region Create Chef Food


        [HttpGet]
        [Route("CreateNewChefFood")]
        public async Task<IActionResult> CreateNewChefFood(int id)
        {
            if (id <= 0) return NotFound();
            var chef = await _foodService.GetChefById(id);
            await GetAllFoodList();
            await GetAllFoodPriceType();
            
            return View(chef);
        }


        [HttpPost]
        [Route("CreateNewChefFood")]
        public async Task<IActionResult> CreateNewChefFood(CreateChefFoodViewModel createChefFoodViewModel)
        {
           
            if (ModelState.IsValid)
            {
                await GetAllFoodList();
                await GetAllFoodPriceType();
             
                var result = await _foodService.CreateChefFoodByAdmin(createChefFoodViewModel);

                switch (result)
                {
                    case CreateChefFoodResult.NotFound:
                        return RedirectToAction("NotFound", "Home");



                    case CreateChefFoodResult.Success:
                        ViewBag.SuccessText = "Chef food Was Created Successfully";
                        return RedirectToAction("ChefFoodList", "Chef", new {chefId= createChefFoodViewModel.ChefId});
                }
            }

            await GetAllFoodList();
            await GetAllFoodPriceType();
             return View(createChefFoodViewModel);
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


        #region SetToIsCalledStatuse

        public async Task<IActionResult> SetToIsCalledChefStatus(int id)
        {
            var result = await _userService.SetToIsCalledChefStatus(id);

            switch (result)
            {
                case ChefRequestResult.NotFound:
                    return View("NotFound");

                case ChefRequestResult.Success:
                    return Json(new
                    {
                        text = "The Chef was contacted",
                        statusCode = HttpStatusCode.OK

                    });
            }

            return RedirectToAction("NotFound", "Home");
        }
        #endregion

        #region SetToNotCalledStatuse

        public async Task<IActionResult> SetToNotCalledChefStatus(int id)
        {
            var result = await _userService.SetToNotIsCalledChefStatus(id);

            switch (result)
            {
                case ChefRequestResult.NotFound:
                    return View("NotFound");

                case ChefRequestResult.Success:
                    return Json(new
                    {
                        text = "The Chef could not be contacted",
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

        public async Task<IActionResult> GetDistrictGroup(int id)
        {
            var district = await _siteService.GetDistricts(id);
            return Json(district);
        }
        #endregion


    }
}
