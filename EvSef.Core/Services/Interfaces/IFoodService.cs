using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Food;
using EvSef.Domain.ViewModels.ChefFood;
using EvSef.Domain.ViewModels.CorporationFood;
using EvSef.Domain.ViewModels.CorporationFoodOrder;
using EvSef.Domain.ViewModels.Food;
using EvSef.Domain.ViewModels.FoodCategory;
using EvSef.Domain.ViewModels.PriceType;
using EvSef.Domain.ViewModels.WeekDayFood;

namespace EvSef.Core.Services.Interfaces
{
    public interface IFoodService
    {

        #region CorporationFoodOrderList

        Task<FilterCorporationFoodOrderViewModel> FilterCorporationFoodOrderList(FilterCorporationFoodOrderViewModel filterCorporationFoodOrderViewModel);

        #endregion

        #region FoodCategory

        Task<CreateFoodCategoryResult> CreateFoodCategoryByAdmin(CreateFoodCategoryViewModel createFoodCategoryViewModel);
        Task<FilterFoodCategoryViewModel> FilterFoodCategoryList(FilterFoodCategoryViewModel filterFoodCategoryViewModel);

        #endregion

        #region Food

        Task<CreateFoodResult> CreateFoodByAdmin(CreateFoodViewModel createFoodViewModel);
        Task<List<FoodCategoryViewModel>> GetAllFoodCategory();
        Task<List<FoodViewModel>> GetAllFoods();
        Task<List<PriceTypeTitleViewModel>> GetAllFoodPriceType();
        Task<FilterFoodViewModel> FilterFoodList(FilterFoodViewModel filterFoodViewModel);
        Task<FilterFoodViewModel> GetFoodsWithCategories();
        #endregion

        #region Chef Food

        Task<CreateChefFoodResult> CreateChefFoodByAdmin(CreateChefFoodViewModel createChefFoodViewModel);
        Task<CreateChefFoodViewModel> GetChefById(int chefId);
        Task<List<FoodViewModel>> GetFoodByChefIdForCreate();
        Task<FilterChefFoodListViewModel> FilterChefFoodList(FilterChefFoodListViewModel filterChefFoodListViewModel);


        #endregion

        #region CreateCorporationFoodOrder

        Task<CreateCorporationFoodOrderResult> CreateCorporationFoodByAdmin(CreateCorporationFoodOrderViewModel createCorporationFoodOrderViewModel);

        #endregion

        #region Corporation Food Order In Site

        Task<List<CorporationFoodOrderViewModel>> GetAllHowOrderCorporationFoodForShowInSite();

        #endregion

        #region FoodSetting

        Task<CreatePriceTypeResult> CreateFoodSettingByAdmin(CreatePriceTypeViewModel createPriceTypeViewModel);
        Task<List<AdminListPriceTypeViewModel>> FoodSettingList();

        #endregion

        #region Week Day Food


        Task<List<ChefFoodViewModel>> GetAllChefFoods();
        Task<CreateWeekDayFoodResult> CreateWeekDAyFoodByAdmin(CreateWeekDayFoodViewModel createWeekDayFoodViewModel);
        Task<FilterWeekDayViewModel> FilterWeekDayFoods(FilterWeekDayViewModel filterWeekDayViewModel);

        #endregion

        #region WeekDay Food In Site

        Task<List<WeekDailyFoodMenuInSiteViewModel>> GetDailyFoodMenuForShowInSite(string weekDayName);
        Task<List<WeekDayName>> GetAllWeekDayName();
        #endregion

        #region Corporation Food

        Task<CreateCorporationFoodResult> CreateCorporationFood(CreateCorporationFoodViewModel createCorporationFoodViewModel);
        Task<CreateCorporationFoodViewModel> GetCorporationById(int corporationId);

        Task<FilterCorporationFoodOrder> GetOrdersByCorporationId(int corporationId,
            FilterCorporationFoodOrder filterCorporationFoodOrder);


        #endregion

    }
}
