using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.ChefFood;
using EvSef.Domain.ViewModels.WeekDayFood;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class WeekDayFoodController : BaseAdminController
    {
        #region Constructor

        private readonly IFoodService _foodService;

        public WeekDayFoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        #endregion

        #region FilterWeekDayFoods

        public async Task<IActionResult> Index(FilterWeekDayViewModel filterWeekDayViewModel)
        {
            var result = await _foodService.FilterWeekDayFoods(filterWeekDayViewModel);
            return View(result);
        }

        #endregion


        #region Create WeekDay Food



        [HttpGet]
        [Route("CreateWeekDayFood")]
        public async Task<IActionResult> CreateWeekDayFoodByAdmin()
        {
            await GetAllChefFoodByName();
            return View();
        }


        [HttpPost]
        [Route("CreateWeekDayFood")]
        public async Task< IActionResult> CreateWeekDayFoodByAdmin(CreateWeekDayFoodViewModel createWeekDayFoodViewModel)
        {
            var result = await _foodService.CreateWeekDAyFoodByAdmin(createWeekDayFoodViewModel);

            switch (result)
            {
                case CreateWeekDayFoodResult.NotFound:
                    return RedirectToAction("NotFound", "Home");

                case CreateWeekDayFoodResult.Error:
                    await GetAllChefFoodByName();
                    return RedirectToAction("NotFound", "Home");


                case CreateWeekDayFoodResult.Success:
                    ViewBag.SuccessText = "Chef food Was Created Successfully";
                    return RedirectToAction("Index", "WeekDayFood");
            }

            await GetAllChefFoodByName();
            return View(createWeekDayFoodViewModel);
        }

        [HttpGet]
   
        public  async Task  GetAllChefFoodByName()
        {
            var allChefFoods = await _foodService.GetAllChefFoods();
            ViewData["AllChefFoods"] = allChefFoods;
        }


        #endregion
    }
}
