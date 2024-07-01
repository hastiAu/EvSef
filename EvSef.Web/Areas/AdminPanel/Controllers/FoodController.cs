using System.Reflection.Metadata.Ecma335;
using EvSef.Core.Services.Implementations;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.Entities.Food;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.Food;
using EvSef.Domain.ViewModels.FoodCategory;
using EvSef.Domain.ViewModels.PriceType;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class FoodController : BaseAdminController
    {
        #region Constructor

        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        #endregion

        #region FilterFood Category

        [HttpGet]
        [Route("FoodCategoryList")]
        public async Task<IActionResult> Index(FilterFoodCategoryViewModel filterFoodCategoryViewModel)
        {
            var result =  await _foodService.FilterFoodCategoryList(filterFoodCategoryViewModel);
            return  View(result);
        }



        #endregion

        #region CreateFoodCategory By Admin

        [HttpGet]
        [Route("CreateFoodCategory")]
        public  IActionResult  CreateFoodCategoryByAdmin()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateFoodCategory")]

        public async Task<IActionResult> CreateFoodCategoryByAdmin(CreateFoodCategoryViewModel createFoodCategoryViewModel)
        {

            if (ModelState.IsValid)
            {
                var result = await _foodService.CreateFoodCategoryByAdmin(createFoodCategoryViewModel);

                switch (result)
                {
                    case CreateFoodCategoryResult.FoodCategoryIsExist:
                        ModelState.AddModelError("FoodCategoryTitle", "Food Category Title is Exists");
                        return View(createFoodCategoryViewModel);

                    case CreateFoodCategoryResult.NotFound:
                        return RedirectToAction("NotFound");

                    case CreateFoodCategoryResult.Success:
                        return RedirectToAction("Index");
                }
            }

            return View(createFoodCategoryViewModel);
        }

        #endregion

        #region FilterFood List

        [HttpGet]
        [Route("Food List")]
        public async Task<IActionResult> FilterFoodList(FilterFoodViewModel filterFoodViewModel )
        {
            var result = await _foodService.FilterFoodList(filterFoodViewModel);
            await GetFoodsWithCategories();
            return View(result);
        }

        #endregion

        #region Create Food

        [HttpGet]
        [Route("CreateFood")]
        public async Task<IActionResult> CreateFoodByAdmin()
        {
            await GetFoodCategory();
             
            return View();
        }

        [HttpPost]
        [Route("CreateFood")]

        public async Task<IActionResult> CreateFoodByAdmin(CreateFoodViewModel createFoodViewModel)
        {

            if (ModelState.IsValid)
            {
                
                var result = await _foodService.CreateFoodByAdmin(createFoodViewModel);

                switch (result)
                {
                    case CreateFoodResult.FoodIsExist:
                        await GetFoodCategory();
                        ModelState.AddModelError("FoodTitle", "Food Title is Exists");
                        return View(createFoodViewModel);

                    case CreateFoodResult.NotFound:
                        return RedirectToAction("NotFound");

                    case CreateFoodResult.Success:
                        return RedirectToAction("FilterFoodList");
                }
            }

            await GetFoodCategory();
            return View(createFoodViewModel);
        }


        #endregion

        #region Get FoodCategory

        public async Task GetFoodCategory()
        {
            var foodCategory = await _foodService.GetAllFoodCategory();
            ViewData["FoodCategory"] = foodCategory;
        }

        
        public  async Task GetFoodsWithCategories()
        {
            var viewModel = await _foodService.GetFoodsWithCategories();
            ViewData["FilterFoodViewModel"] = viewModel;
             
        }
        #endregion

        #region Create FoodSetting ByAdmin

        [HttpGet]
        [Route("CreateFoodSetting")]
        public IActionResult CreateFoodSettingByAdmin()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateFoodSetting")]

        public async Task<IActionResult> CreateFoodSettingByAdmin(CreatePriceTypeViewModel createPriceTypeViewModel)
        {

            if (ModelState.IsValid)
            {
                var result = await _foodService.CreateFoodSettingByAdmin(createPriceTypeViewModel);

                switch (result)
                {
                    case CreatePriceTypeResult.PriceTypeIsExist:
                        ModelState.AddModelError("PriceTypename", "Price type name is Exists");
                        return View(createPriceTypeViewModel);

                    case CreatePriceTypeResult.NotFound:
                        return RedirectToAction("NotFound");

                    case CreatePriceTypeResult.Success:
                        return RedirectToAction("FoodSettingList");
                }
            }

            return View(createPriceTypeViewModel);
        }


        #endregion

        #region FoodSetting List


        [HttpGet]
        [Route("FoodSettingList")]
        public async Task<IActionResult> FoodSettingList()
        {
            var result = await _foodService.FoodSettingList();
            return View(result);
        }

        #endregion



    }
}
