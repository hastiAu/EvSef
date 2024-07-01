using EvSef.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Food;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.FoodCategory;
using Microsoft.EntityFrameworkCore;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.Entities.FoodPrice;
using EvSef.Domain.ViewModels.Chef;
using EvSef.Domain.ViewModels.Food;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Domain.ViewModels.PriceType;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EvSef.Domain.ViewModels.ChefFood;
using EvSef.Domain.ViewModels.WeekDayFood;
using Microsoft.IdentityModel.Tokens;
using Google.Protobuf.WellKnownTypes;
using Enum = System.Enum;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using EvSef.Domain.ViewModels.CorporationFood;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EvSef.Infra.Data.Repository
{
    public class FoodRepository : IFoodRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public FoodRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Food Category

        public async Task CreateFoodCategoryByAdmin(FoodCategory foodCategory)
        {
            await _context.FoodCategories.AddAsync(foodCategory);
        }



        public async Task<bool> FoodCategoryIsExist(string foodCategoryTitle)
        {
            return await _context.FoodCategories.AnyAsync(u => u.FoodCategoryTitle == foodCategoryTitle);
        }

        public async Task<bool> FoodCategoryIdIsExist(int foodCategoryId)
        {
            return await _context.FoodCategories.AnyAsync(u =>
                u.FoodCategoryParentId == foodCategoryId && u.FoodCategoryParentId == null);
        }

        public async Task<FilterFoodCategoryViewModel> FilterFoodCategoryList(
            FilterFoodCategoryViewModel filterFoodCategoryViewModel)
        {
            var query = _context.FoodCategories.Where(u => !u.IsDelete).AsQueryable();

            #region Filter

            switch (filterFoodCategoryViewModel.FoodCategoryState)
            {
                case FoodCategoryState.All:
                    break;

                case FoodCategoryState.Active:
                    break;
                case FoodCategoryState.InActivate:
                    break;
            }

            if (!string.IsNullOrEmpty(filterFoodCategoryViewModel.FoodCategoryTitle))
            {
                query = query.Where(q => q.FoodCategoryTitle.ToLower().Contains(q.FoodCategoryTitle.ToLower()));
            }


            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterFoodCategoryViewModel.PageId, allEntitiesCount);
            var foodCat = await query.OrderBy(o => o.IsDelete == false).Pagination(pager).ToListAsync();
            filterFoodCategoryViewModel.SetFoodCat(foodCat);
            return filterFoodCategoryViewModel.SetPaging(pager);



            #endregion
        }

        public async Task<FilterFoodViewModel> FilterFoodList(FilterFoodViewModel filterFoodViewModel)
        {
            var query = _context.Foods.AsQueryable();

            #region Filter

            switch (filterFoodViewModel.FilterFoodState)
            {
                case FilterFoodState.Active:
                    {
                        query = query.Where(q => q.IsActive);
                        break;
                    }

                case FilterFoodState.InActivate:
                    {
                        query = query.Where(q => !q.IsActive);
                        break;
                    }
                case FilterFoodState.All:
                    {

                        break;
                    }

            }

            if (!string.IsNullOrEmpty(filterFoodViewModel.FoodTitle))
            {
                query = query.Where(q => q.FoodTitle.ToLower().Contains(filterFoodViewModel.FoodTitle.ToLower()));

            }



            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterFoodViewModel.PageId, allEntitiesCount);
            var foods = await query.OrderBy(o => o.IsDelete == false).Pagination(pager).ToListAsync();
            filterFoodViewModel.SetUsers(foods);
            return filterFoodViewModel.SetPaging(pager);
        }

        #endregion

        #region Food

        public async Task CreateFoodByAdmin(Food food)
        {
            await _context.Foods.AddAsync(food);
        }

        public async Task<bool> FoodTitleIsExist(string foodTitle)
        {
            return await _context.Foods.AnyAsync(u => u.FoodTitle == foodTitle);
        }

        public async Task<List<FoodCategoryViewModel>> GetAllFoodCategory()
        {
            var result = await _context.FoodCategories.Where(u => !u.IsDelete)
                .Select(u => new FoodCategoryViewModel()
                {
                    FoodCategoryTitle = u.FoodCategoryTitle,
                    FoodCategoryId = u.FoodCategoryId,
                }
                ).ToListAsync();

            return result;
        }

        public async Task<List<FoodViewModel>> GetAllFoods()
        {
            var result = await _context.Foods.Where(u => !u.IsDelete)
                .Select(u => new FoodViewModel()
                {
                    FoodTitle = u.FoodTitle,
                    FoodId = u.FoodId,

                }
                ).ToListAsync();

            return result;
        }

        public async Task<List<PriceTypeTitleViewModel>> GetAllFoodPriceType()
        {
            var result = await _context.PriceTypes.Where(u => !u.IsDelete)
                .Select(u => new PriceTypeTitleViewModel()

                {
                    PriceTypeName = u.PriceTypeName,
                    PriceTypeId = u.PriceTypeId,
                }
                ).ToListAsync();
            return result;
        }


        public async Task AddFoodCategoryToFood(FoodSelectedCategory? foodSelectedCategory)
        {
            await _context.FoodSelectedCategories.AddAsync(foodSelectedCategory);
        }

        public async Task<FilterFoodViewModel> GetFoodsWithCategories()
        {
            var foodsWithCategories = await _context.Foods
                .Include(f => f.FoodSelectedCategories)
                .ThenInclude(fsc => fsc.FoodCategory)
                .ToListAsync();

            var filterFoodViewModel = new FilterFoodViewModel
            {
                Foods = foodsWithCategories,
                FoodCategories = foodsWithCategories
                    .SelectMany(f => f.FoodSelectedCategories)
                    .Select(fsc => fsc.FoodCategory)
                    .ToList()
            };

            return filterFoodViewModel;
        }

        public async Task CreateChefFoodByAdmin(ChefFood chefFood)
        {
            await _context.ChefFoods.AddAsync(chefFood);
        }

        public async Task CreateChefFoodPrice(ChefFoodPrice chefFoodPrice)
        {
            await _context.ChefFoodPrices.AddAsync(chefFoodPrice);
        }

        public async Task<CreateChefFoodViewModel> GetChefById(int chefId)
        {

            var result = await _context.Chefs.Where(c => c.ChefId == chefId)
                .Include(c => c.ChefFood)

                .Select(n => new CreateChefFoodViewModel()

                {
                    ChefId = n.ChefId,


                }
                ).SingleOrDefaultAsync();

            return result;
        }

        #endregion


        #region Chef Food

        public async Task<List<FoodViewModel>> GetFoodByChefIdForCreate()
        {
            return await _context.Foods.Where(c => !c.IsDelete && c.IsActive)
                .Select(u => new FoodViewModel()
                {
                    FoodId = u.FoodId,
                    FoodTitle = u.FoodTitle


                }
                ).ToListAsync();
        }

        public async Task<FilterChefFoodListViewModel> FilterChefFoodList(
            FilterChefFoodListViewModel filterChefFoodListViewModel)
        {

            var query = _context.ChefFoods
                .Include(c => c.Food)
                .Include(t => t.ChefFoodPrices)
                .Where(f => f.ChefId == filterChefFoodListViewModel.ChefId)
                .Select(q => new FilterChefFoodListViewModel()
                {

                    ChefId = q.ChefId,
                    FoodTitle = q.Food.FoodTitle,
                    IsActive = q.IsActive,
                    ChefFoodPrice = q.ChefFoodPrices

                })

                .AsQueryable();

            #region Filter

            switch (filterChefFoodListViewModel.ChefFoodState)
            {
                case ChefFoodState.All:
                    break;

                case ChefFoodState.Active:
                    break;
                case ChefFoodState.InActivate:
                    break;
            }



            if (!string.IsNullOrEmpty(filterChefFoodListViewModel.FoodTitle))
            {
                query = query.Where(q => q.FoodTitle.Contains(filterChefFoodListViewModel.FoodTitle.ToLower()));

            }

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterChefFoodListViewModel.PageId, allEntitiesCount);
            var chefFood = await query.OrderBy(o => o.IsActive == true).Pagination(pager).ToListAsync();
            filterChefFoodListViewModel.SetChefFood(chefFood);
            return filterChefFoodListViewModel.SetPaging(pager);



            #endregion
        }

        #endregion


        #region Food Setting


        public async Task CreateFoodSettingByAdmin(PriceType priceType)
        {
            await _context.PriceTypes.AddAsync(priceType);
        }

        public async Task<bool> PriceTypeIsExist(string priceTypeName)
        {
            return await _context.PriceTypes.AnyAsync(u => u.PriceTypeName == priceTypeName);
        }



        public async Task<List<AdminListPriceTypeViewModel>> FoodSettingList()
        {

            return await _context.PriceTypes

                .Select(u => new AdminListPriceTypeViewModel()

                {
                    PriceTypeName = u.PriceTypeName,
                    PriceTypeIsDefault = u.PriceTypeIsDefault,
                    CreatedUser = u.CreatedUser,



                }).ToListAsync();
        }

        #endregion

        #region WeekDay Food

        public async Task<List<ChefFoodViewModel>> GetAllChefFoods()
        {
            return await _context.ChefFoods
                .Include(f => f.Food)
                .Where(a => a.IsActive)
                .Select(c => new ChefFoodViewModel()
                {
                    FoodTitle = c.Food.FoodTitle,
                    ChefId = c.ChefId,
                    ChefName = c.Chef.FirstName + " " + c.Chef.LastName,
                    ChefFoodId = c.ChefFoodId

                }
                ).ToListAsync();
        }

        public async Task CreateWeekDayFoodByAdmin(WeekDayFood weekDayFood)
        {
            await _context.WeekDayFoods.AddAsync(weekDayFood);
        }

        public async Task<FilterWeekDayViewModel> FilterWeekDayFoods(FilterWeekDayViewModel filterWeekDayFoodViewModel)
        {

            var query = _context.WeekDayFoods
                .Include(weekdayFood => weekdayFood.ChefFood)
                .ThenInclude(chefFood => chefFood.Food)
                .Select(weekdayFood => new WeekdayChefFoodViewModel
                {
                    FoodTitle = weekdayFood.ChefFood.Food.FoodTitle,
                    ChefFoodId = weekdayFood.ChefFoodId,
                    WeekDayName = weekdayFood.WeekDayName,
                    IsActive = weekdayFood.IsActive,


                });



            switch (filterWeekDayFoodViewModel.WeekDayState)
            {
                case WeekDayState.All:
                    break;

                case WeekDayState.Active:
                    break;
                case WeekDayState.InActivate:
                    break;
            }

            //if (Enum.TryParse(filterWeekDayFoodViewModel.WeekDayName.ToString(), out WeekDayName weekDayNameEnum))

            //switch (weekDayNameEnum)

            //    {
            //        case WeekDayName.Saturday:
            //        case WeekDayName.Sunday:
            //        case WeekDayName.Monday:
            //        case WeekDayName.Tuesday:
            //        case WeekDayName.Wednesday:
            //        case WeekDayName.Thursday:
            //        case WeekDayName.Friday:
            //            query = query.Where(q => q.WeekDayName == weekDayNameEnum);
            //            break;

            //    }

            if (Enum.TryParse(filterWeekDayFoodViewModel.WeekDayName.ToString(), out WeekDayName weekDayNameEnum))
            {
                query = query.Where(q => q.WeekDayName == weekDayNameEnum);
            }

            int allEntitiesCount = await query.CountAsync();


            var pager = Pagination.BuildPagination(filterWeekDayFoodViewModel.PageId, allEntitiesCount);
            var weekDay = await query
                .OrderByDescending(o => o.IsActive)
                .ThenByDescending(o => o.WeekDayName)
                .Pagination(pager)
                .ToListAsync();


            var result = new FilterWeekDayViewModel
            {
                ChefFoodId = filterWeekDayFoodViewModel.ChefFoodId,
                WeekDayFood = weekDay,
                PageId = pager.PageId,
                TakeEntity = pager.TakeEntity,
                SkipEntity = pager.SkipEntity,
                AllEntitiesCount = pager.AllEntitiesCount,
                AllPageCount = pager.AllPageCount,
                StartPage = pager.StartPage,
                EndPage = pager.EndPage
            };


            //filterWeekDayFoodViewModel.SetWeekDay(weekDay);

            //return filterWeekDayFoodViewModel.SetPaging(pager);


            return result;
        }



        #endregion

        #region CreateCorporationFoodOrder

        public async Task CreateCorporationFoodOrder(CorporationFood corporationFood)
        {
            await _context.CorporationFoods.AddAsync(corporationFood);
        }

        public async Task<CreateCorporationFoodViewModel> GetCorporationById(int corporationId)
        {

            var result = await _context.Corporations.Where(c => c.CorporationId == corporationId)

                .Select(n => new CreateCorporationFoodViewModel()

                {
                    CorporationId = n.CorporationId,


                }
                ).SingleOrDefaultAsync();

            return result;

        }

        public async Task<FilterCorporationFoodOrder> GetOrdersByCorporationId(int corporationId,
            FilterCorporationFoodOrder filterCorporationFoodOrder)
        {
            var query = _context.CorporationFoods
                .Where(cf => cf.CorporationId == corporationId)

             .AsQueryable();

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterCorporationFoodOrder.PageId, allEntitiesCount);
            var orderedQuery = await query.OrderBy(o => o.IsDelete).Pagination(pager).ToListAsync();

            // Set the ordered data to the FilterCorporationFoodOrder
            filterCorporationFoodOrder.SetCorporationFoods(orderedQuery);
            filterCorporationFoodOrder.SetPaging(pager);

            return filterCorporationFoodOrder;
        }



        #endregion


        #region WeekDay Food In Site

        public async Task<List<WeekDailyFoodMenuInSiteViewModel>> GetDailyFoodMenuForShowInSite(string weekDayName)
        {
            var foodMenu = await _context.WeekDayFoods
                .Where(wfd=> wfd.IsActive)
                 .Include(wfd => wfd.ChefFood)
                .ThenInclude(wfd => wfd.Food)
                .Include(wfd => wfd.ChefFood)
                .ThenInclude(wfd => wfd.ChefFoodPrices)

                .Select(wdf => new WeekDailyFoodMenuInSiteViewModel
                {
                    FoodTitle = wdf.ChefFood.Food.FoodTitle,
                    FoodDescription = wdf.ChefFood.Food.FoodDescription,
                    ImageFood = wdf.ChefFood.Food.ImageFood,
                    ChefFoodsPrice = wdf.ChefFood.ChefFoodPrices.Any() ? wdf.ChefFood.ChefFoodPrices.FirstOrDefault().ChefFoodsPrice : 0,
                    WeekDayName = wdf.WeekDayName,
                    ChefFoodId = wdf.ChefFoodId,

                })
                .ToListAsync();

            return foodMenu;
        }
  

        public  async Task<List<WeekDayName>> GetAllWeekDayName(   )
        {
            return await _context.WeekDayFoods.Select(w => w.WeekDayName).Distinct().ToListAsync();
        }

        #endregion

        #region DisposeAsync
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }


        #endregion

        #region SaveChanges


        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }



        #endregion
    }
}
