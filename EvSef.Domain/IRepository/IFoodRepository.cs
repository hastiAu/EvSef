using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.Entities.Food;
using EvSef.Domain.Entities.FoodPrice;
using EvSef.Domain.ViewModels.ChefFood;
using EvSef.Domain.ViewModels.CorporationFood;
using EvSef.Domain.ViewModels.Food;
using EvSef.Domain.ViewModels.FoodCategory;
using EvSef.Domain.ViewModels.PriceType;
using EvSef.Domain.ViewModels.WeekDayFood;

namespace EvSef.Domain.IRepository
{
    public interface IFoodRepository : IAsyncDisposable
    {

        #region FoodCategory

        Task CreateFoodCategoryByAdmin(FoodCategory foodCategory);
        Task<bool> FoodCategoryIsExist(string foodCategoryTitle);
        Task<bool> FoodCategoryIdIsExist(int foodCategoryId);
        Task<FilterFoodCategoryViewModel> FilterFoodCategoryList(FilterFoodCategoryViewModel filterFoodCategoryViewModel);
        #endregion

        #region Food List

        Task<FilterFoodViewModel> FilterFoodList(FilterFoodViewModel filterFoodViewModel);

        #endregion

        #region Creaet Food

        Task CreateFoodByAdmin(Food food);
        Task<bool> FoodTitleIsExist(string foodTitle);
        Task<List<FoodCategoryViewModel>> GetAllFoodCategory();
        Task<List<FoodViewModel>> GetAllFoods();
        Task<List<PriceTypeTitleViewModel>> GetAllFoodPriceType();
        Task AddFoodCategoryToFood(FoodSelectedCategory? foodSelectedCategory);
        Task<FilterFoodViewModel> GetFoodsWithCategories();

        #endregion

        #region Chef Food

        Task CreateChefFoodByAdmin(ChefFood chefFood);
        Task CreateChefFoodPrice(ChefFoodPrice chefFoodPrice);
        Task<CreateChefFoodViewModel> GetChefById(int chefId);
        Task<List<FoodViewModel>> GetFoodByChefIdForCreate();
        Task<FilterChefFoodListViewModel> FilterChefFoodList(FilterChefFoodListViewModel filterChefFoodListViewModel);

        #endregion

        #region Food Setting

        Task CreateFoodSettingByAdmin(PriceType priceType);
        Task<bool> PriceTypeIsExist(string priceTypeName);

        Task<List<AdminListPriceTypeViewModel>> FoodSettingList();

        #endregion

        #region WeekDay Food

        Task<List<ChefFoodViewModel>> GetAllChefFoods();
        Task CreateWeekDayFoodByAdmin(WeekDayFood weekDayFood);
        Task<FilterWeekDayViewModel> FilterWeekDayFoods(FilterWeekDayViewModel filterWeekDayFoodViewModel);

        #endregion

        #region Create Corporation Food Order

        Task CreateCorporationFoodOrder(CorporationFood corporationFood);

        Task<CreateCorporationFoodViewModel> GetCorporationById(int corporationId);
        Task<FilterCorporationFoodOrder> GetOrdersByCorporationId(int corporationId,
            FilterCorporationFoodOrder filterCorporationFoodOrder);
        #endregion

        #region WeekDay Food In Site

        Task<List<WeekDailyFoodMenuInSiteViewModel>> GetDailyFoodMenuForShowInSite(string weekDayName);
        Task<List<WeekDayName>> GetAllWeekDayName();
        #endregion

        #region Save

        Task SaveChanges();


        #endregion

    }
}
