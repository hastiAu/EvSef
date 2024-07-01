using EvSef.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EvSef.Core.Extensions;
using EvSef.Core.Generator;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.Entities.Food;
using EvSef.Domain.ViewModels.Food;
using EvSef.Domain.ViewModels.FoodCategory;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.Entities.CorporationFoodOrder;
using EvSef.Domain.Entities.FoodPrice;
using EvSef.Domain.ViewModels.ChefFood;
using EvSef.Domain.ViewModels.CorporationFood;
using EvSef.Domain.ViewModels.CorporationFoodOrder;
using EvSef.Domain.ViewModels.PriceType;
using EvSef.Domain.ViewModels.WeekDayFood;

namespace EvSef.Core.Services.Implementations
{
    public class FoodService: IFoodService
    {
        #region Constructor

        private readonly IFoodRepository _foodRepository;
        private readonly ICorporationFoodOrderRepository _corporationFoodOrder;

        public FoodService(IFoodRepository foodRepository, ICorporationFoodOrderRepository corporationFoodOrder)
        {
            _foodRepository = foodRepository;
            _corporationFoodOrder = corporationFoodOrder;
        }

        #endregion

        public async  Task<FilterCorporationFoodOrderViewModel> FilterCorporationFoodOrderList(FilterCorporationFoodOrderViewModel filterCorporationFoodOrderViewModel)
        {
            return await _corporationFoodOrder.CorporationFoodOrderList(filterCorporationFoodOrderViewModel);
        }

        public async Task<CreateFoodCategoryResult> CreateFoodCategoryByAdmin(CreateFoodCategoryViewModel createFoodCategoryViewModel)
        {
            if (createFoodCategoryViewModel == null && createFoodCategoryViewModel.FoodCategoryParentId != null)
            {
                 return CreateFoodCategoryResult.NotFound;
            }

            if (createFoodCategoryViewModel == null && !await _foodRepository.FoodCategoryIdIsExist(createFoodCategoryViewModel.FoodCategoryParentId.Value))
                return CreateFoodCategoryResult.FoodCategoryIsExist;
             

           FoodCategory foodCategory = new FoodCategory()
           {
               FoodCategoryTitle = createFoodCategoryViewModel.FoodCategoryTitle.SanitizeText(),
               IsActive = createFoodCategoryViewModel.IsActive,
               RegisterDate = DateTime.Now,
               CreatedUser = createFoodCategoryViewModel.CreatedUser,
               FoodCategoryParentId = createFoodCategoryViewModel.FoodCategoryParentId,
           };
           await _foodRepository.CreateFoodCategoryByAdmin(foodCategory);
           await _foodRepository.SaveChanges();

            return CreateFoodCategoryResult.Success;
        }

        public  async Task<FilterFoodCategoryViewModel> FilterFoodCategoryList(FilterFoodCategoryViewModel filterFoodCategoryViewModel)
        {
            return await _foodRepository.FilterFoodCategoryList(filterFoodCategoryViewModel);
        }

        public async Task<CreateFoodResult> CreateFoodByAdmin(CreateFoodViewModel createFoodViewModel)
        {
            if (await _foodRepository.FoodTitleIsExist(createFoodViewModel.FoodTitle))
            {
                return CreateFoodResult.FoodIsExist;
            }

            Food food = new Food()
            {
                FoodTitle = createFoodViewModel.FoodTitle.SanitizeText(),
                IsActive = createFoodViewModel.IsActive,
                RegisterDate = DateTime.Now,
                FoodDescription = createFoodViewModel.FoodDescription.SanitizeText(),
                IsDelete = false,
                CreatedUser = createFoodViewModel.CreatedUser,
            };

            if (createFoodViewModel.FoodAvatar != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(createFoodViewModel.FoodAvatar.FileName);
                createFoodViewModel.FoodAvatar.AddImageToServer(imageName, FilePath.FilePath.FoodAvatarServer, 100,
                    100, FilePath.FilePath.FoodAvatarThumbServer);
                food.ImageFood = imageName;

            }


            await _foodRepository.CreateFoodByAdmin(food);
            await _foodRepository.SaveChanges();

            if (createFoodViewModel.SelectedFoodCategory != null)
            {
                await AddFoodCategoryToFood(food.FoodId, createFoodViewModel.SelectedFoodCategory);
                await _foodRepository.SaveChanges();
            }

            return CreateFoodResult.Success;
        }


         

        public async Task AddFoodCategoryToFood(int foodId, List<int> foodCategoryId)
        {
            if (!foodCategoryId.Any())
                return;

            foreach (var foodCat in foodCategoryId)
            {
                FoodSelectedCategory? foodSelectedCategory = new FoodSelectedCategory()
                {
                    FoodId = foodId,
                    FoodCategoryId = foodCat,
                    RegisterDate = DateTime.Now,
                    
                };
                await _foodRepository.AddFoodCategoryToFood(foodSelectedCategory);
                await _foodRepository.SaveChanges();
            }
        }

        public async Task<List<PriceTypeTitleViewModel>> GetAllFoodPriceType()
        {
            return await _foodRepository.GetAllFoodPriceType();
        }

        public async Task<FilterFoodViewModel> FilterFoodList(FilterFoodViewModel filterFoodViewModel)
        {
            return await  _foodRepository.FilterFoodList(filterFoodViewModel);
        }

        public async Task<FilterFoodViewModel> GetFoodsWithCategories()
        {
            return await _foodRepository.GetFoodsWithCategories();
        }



        public async Task<CreateChefFoodResult> CreateChefFoodByAdmin(CreateChefFoodViewModel createChefFoodViewModel)
        {
            if (createChefFoodViewModel == null)
            {
                return CreateChefFoodResult.NotFound;
            }

          
            ChefFood chefFood = new ChefFood()
            {
                ChefId = createChefFoodViewModel.ChefId,
                FoodId = createChefFoodViewModel.FoodSelectedId,
                IsActive = createChefFoodViewModel.IsActive,
                ChefFoodLimitCount = createChefFoodViewModel.ChefFoodLimitCount,
                RegisterDate = DateTime.Now,
                CreatedUser = createChefFoodViewModel.CreatedUser,

            };
            await _foodRepository.CreateChefFoodByAdmin(chefFood);
            await _foodRepository.SaveChanges();

            var chefFoodId = chefFood.ChefFoodId;

            ChefFoodPrice chefFoodPrice = new ChefFoodPrice()
            {
                ChefFoodId = chefFoodId,
                PriceTypeId = createChefFoodViewModel.SelectedPriceType,
                ChefFoodsPrice = createChefFoodViewModel.ChefFoodsPrice,
                ChefFoodPriceDiscount = createChefFoodViewModel.ChefFoodPriceDiscount,
                ChefFoodPriceFromDate = createChefFoodViewModel.ChefFoodPriceFromDate,
                ChefFoodPriceToDate = createChefFoodViewModel.ChefFoodPriceToDate,
                ChefFoodPriceIsDefault = createChefFoodViewModel.ChefFoodPriceIsDefault,
                RegisterDate = DateTime.Now,
                CreatedUser = createChefFoodViewModel.CreatedUser

            };

            await _foodRepository.CreateChefFoodPrice(chefFoodPrice);
            await _foodRepository.SaveChanges();


            return CreateChefFoodResult.Success;

        }

        public async Task<CreateChefFoodViewModel> GetChefById(int chefId)
        {
            return await _foodRepository.GetChefById(chefId);
        }

        public  async Task<List<FoodViewModel>> GetFoodByChefIdForCreate()
        {
            return await _foodRepository.GetFoodByChefIdForCreate();
        }

        public async Task<FilterChefFoodListViewModel> FilterChefFoodList(FilterChefFoodListViewModel filterChefFoodListViewModel)
        {
            return await _foodRepository.FilterChefFoodList(filterChefFoodListViewModel);
        }


        public async Task<List<FoodCategoryViewModel>> GetAllFoodCategory()
        {
            return await _foodRepository.GetAllFoodCategory();
        }

        public async Task<List<FoodViewModel>> GetAllFoods()
        {
            return await _foodRepository.GetAllFoods();
        }


        public async  Task<CreateCorporationFoodOrderResult> CreateCorporationFoodByAdmin(CreateCorporationFoodOrderViewModel createCorporationFoodOrderViewModel)
        {
            if (createCorporationFoodOrderViewModel == null)
            {
                return CreateCorporationFoodOrderResult.NotFound;
            }

            if (await _corporationFoodOrder.CorporationFoodTitleIsExist(createCorporationFoodOrderViewModel
                    .CorporationFoodOrderTitle))
            {
                return CreateCorporationFoodOrderResult.CorporationFoodOrderIsExist;
            }

            CorporationFoodOrder corporationFoodOrder = new CorporationFoodOrder()
            {
                CorporationFoodOrderTitle = createCorporationFoodOrderViewModel.CorporationFoodOrderTitle,
                CorporationFoodOrderDescription = createCorporationFoodOrderViewModel.CorporationFoodOrderDescription,
                CreatedUser = createCorporationFoodOrderViewModel.CreatedUser,
                IsActive = createCorporationFoodOrderViewModel.IsActive,
                RegisterDate = DateTime.Now,
                

            };


            if (createCorporationFoodOrderViewModel.CorporationFoodOrderAvatar != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(createCorporationFoodOrderViewModel.CorporationFoodOrderAvatar.FileName);
                createCorporationFoodOrderViewModel.CorporationFoodOrderAvatar.AddImageToServer(imageName, FilePath.FilePath.CorporationFoodOrderServer, 100,
                    100, FilePath.FilePath.CorporationFoodOrderThumbServer);
                corporationFoodOrder.CorporationFoodOrderImage = imageName;

            }

            await _corporationFoodOrder.CreateCorporationFoodOrderByAdmin(corporationFoodOrder);
            await _corporationFoodOrder.SaveChanges();

            return CreateCorporationFoodOrderResult.Success;
        }

     

        public async Task<CreatePriceTypeResult> CreateFoodSettingByAdmin(CreatePriceTypeViewModel createPriceTypeViewModel)
        {

            if (createPriceTypeViewModel == null)
            {
                return CreatePriceTypeResult.NotFound;
            }

            if (await _foodRepository.PriceTypeIsExist(createPriceTypeViewModel.PriceTypeName))
            {
                return CreatePriceTypeResult.PriceTypeIsExist;
            }

            PriceType priceType = new PriceType()
            {
                 
                PriceTypeName = createPriceTypeViewModel.PriceTypeName,
                PriceTypeCurrency = createPriceTypeViewModel.PriceTypeCurrency,
                RegisterDate = DateTime.Now,
                CreatedUser = createPriceTypeViewModel.CreatedUser,
                PriceTypeIsDefault = createPriceTypeViewModel.PriceTypeIsDefault,
                IsDelete = false,

            };

 

            await _foodRepository.CreateFoodSettingByAdmin(priceType);
            await _corporationFoodOrder.SaveChanges();

            return CreatePriceTypeResult.Success;
        }

        public async Task<List<AdminListPriceTypeViewModel>> FoodSettingList()
        {
            return await _foodRepository.FoodSettingList();
        }

        public async Task<List<ChefFoodViewModel>> GetAllChefFoods()
        {
            return await _foodRepository.GetAllChefFoods();
        }

        public  async Task<CreateWeekDayFoodResult> CreateWeekDAyFoodByAdmin(CreateWeekDayFoodViewModel createWeekDayFoodViewModel)
        {
            if (createWeekDayFoodViewModel == null)
            {
                return CreateWeekDayFoodResult.Error;
            }

            if (createWeekDayFoodViewModel.SelectedChefFoodId == null)
            {
                return CreateWeekDayFoodResult.Error;

            }

            WeekDayFood weekDayFood = new WeekDayFood()
            {
                ChefFoodId = createWeekDayFoodViewModel.SelectedChefFoodId,
                WeekDayName = createWeekDayFoodViewModel.WeekDayName,
                IsActive = createWeekDayFoodViewModel.IsActive,
                RegisterDate = DateTime.Now,
                CreatedUser = createWeekDayFoodViewModel.CreatedUser,
              

            };

            await _foodRepository.CreateWeekDayFoodByAdmin(weekDayFood);
            await _foodRepository.SaveChanges();
            return CreateWeekDayFoodResult.Success;
        }

        public  async Task<FilterWeekDayViewModel> FilterWeekDayFoods(FilterWeekDayViewModel filterWeekDayViewModel)
        {
            return await _foodRepository.FilterWeekDayFoods(filterWeekDayViewModel);
        }

  

        public async  Task<CreateCorporationFoodResult> CreateCorporationFood(CreateCorporationFoodViewModel createCorporationFoodViewModel)
        {
            CorporationFood corporationFood = new CorporationFood()

            {
                CorporationId = createCorporationFoodViewModel.CorporationId,
                IsDelete = false,
                IsActive = createCorporationFoodViewModel.IsActive,
                RegisterDate = DateTime.Now,
                CorporationOrderFromDate = createCorporationFoodViewModel.CorporationOrderFromDate,
                CorporationOrderToDate = createCorporationFoodViewModel.CorporationOrderToDate,
                CreatedUser = createCorporationFoodViewModel.CreatedUser,
                ChefFoodId = createCorporationFoodViewModel.SelectedChefFoodId,
                FoodAmount = createCorporationFoodViewModel.FoodAmount,
                WeekDayName = createCorporationFoodViewModel.WeekDayName,
             };

            await _foodRepository.CreateCorporationFoodOrder(corporationFood);
            await _foodRepository.SaveChanges();

            return CreateCorporationFoodResult.Success;
        }

        public async Task<CreateCorporationFoodViewModel> GetCorporationById(int corporationId)
        {
            return await _foodRepository.GetCorporationById(corporationId);
        }

        public async Task<FilterCorporationFoodOrder> GetOrdersByCorporationId(int corporationId,
            FilterCorporationFoodOrder filterCorporationFoodOrder)
        {
            return await _foodRepository.GetOrdersByCorporationId(corporationId, filterCorporationFoodOrder);
        }

        #region Corporation Food Order In Site

        public async Task<List<CorporationFoodOrderViewModel>> GetAllHowOrderCorporationFoodForShowInSite()
        {
            return await _corporationFoodOrder.GetAllHowOrderCorporationFoodForShowInSite();
        }

        #endregion

        #region WeekDay Food In Site
        public async Task<List<WeekDailyFoodMenuInSiteViewModel>> GetDailyFoodMenuForShowInSite(string weekDayName)
        {
            return await _foodRepository.GetDailyFoodMenuForShowInSite(weekDayName);
        }

        public  async Task<List<WeekDayName>> GetAllWeekDayName()
        {
            return await _foodRepository.GetAllWeekDayName();
        }

        #endregion
    }
}
