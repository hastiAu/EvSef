using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.BeComeChef;
using EvSef.Domain.Entities.Restaurant;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.BeComeChef;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Domain.ViewModels.Restaurant;
using EvSef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class RestaurantsRepository:IRestaurantsRepository
    {

        #region Constructor

        private readonly EvSefDbContext _context;

        public RestaurantsRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion

        #region FilterRestaurantList

        public async Task<FilterRestaurantViewModel> FilterRestaurantList(FilterRestaurantViewModel filterRestaurantViewModel)
        {

            var query = _context.Restaurants.AsQueryable();

            #region Filter

            switch (filterRestaurantViewModel.RestaurantState)
            {
                case RestaurantState.Active:
                {
                    query = query.Where(q => q.IsActive);
                    break;
                }

                case RestaurantState.InActivate:
                {
                    query = query.Where(q => !q.IsActive);
                    break;
                }
                case RestaurantState.All:
                {

                    break;
                }

            }

            if (!string.IsNullOrEmpty(filterRestaurantViewModel.RestaurantName))
            {
                query = query.Where(q => q.RestaurantName.ToLower().Contains(filterRestaurantViewModel.RestaurantName.ToLower()));

            }


            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterRestaurantViewModel.PageId, allEntitiesCount);
            var restaurant = await query.OrderBy(o => o.IsDelete == false).Pagination(pager).ToListAsync();
            filterRestaurantViewModel.SetUsers(restaurant);
            return filterRestaurantViewModel.SetPaging(pager);
        }

   
        #endregion

        #region CreateResaurant


        public async Task CreateRestaurantByAdmin(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
        }

        public  async Task<bool> RestaurantNameIsExist(string restaurantName)
        {
            return await _context.Restaurants.AnyAsync(u => u.RestaurantName == restaurantName);
        }




        #endregion

        #region RestaurantLinks In SIte

        public async Task<List<RestaurantListViewModel>> GetAllRestaurantsForShowInSite()
        {
            return await _context.Restaurants
                .Where(r => r.IsActive && !r.IsDelete)
                .Select(r => new RestaurantListViewModel()
                    {
                         RestaurantUrl = r.RestaurantUrl,
                         RestaurantName = r.RestaurantName,
                    }

                ).ToListAsync();
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

   