using EvSef.Domain.Entities.BeComeChef;
using EvSef.Domain.ViewModels.BeComeChef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Restaurant;
using EvSef.Domain.ViewModels.Restaurant;

namespace EvSef.Domain.IRepository
{
    public interface IRestaurantsRepository : IAsyncDisposable
    {

        #region CreateRestaurantByAdmin

        Task CreateRestaurantByAdmin(Restaurant restaurant);
        Task<bool> RestaurantNameIsExist(string restaurantName);

        #endregion



        #region FilterRestaurantList

        Task<FilterRestaurantViewModel> FilterRestaurantList(FilterRestaurantViewModel filterRestaurantViewModel);

        #endregion

        #region Restaurant In site

        Task<List<RestaurantListViewModel>> GetAllRestaurantsForShowInSite();

        #endregion


        #region Save

        Task SaveChanges();

        #endregion
    }
}
