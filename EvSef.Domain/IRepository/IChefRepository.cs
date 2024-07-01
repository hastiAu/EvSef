using EvSef.Domain.Entities.Account;
using EvSef.Domain.Entities.UserType;
using EvSef.Domain.ViewModels.Chef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.IRepository
{
    public interface IChefRepository : IAsyncDisposable
    {
        #region Chef Request In Site

        Task CreateChefRequestInSite(Chef chef);
       Task<bool>IsExistChefMobileNumber (string chefMobile);
       Task<bool>IsExistChefByEmail (string chefEmail);

        #endregion

        #region Chef Admin

        Task CreateNewChefByAdmin(Chef chef);
        Task CreateChefByAdmin(Chef chef);
        Task InsertChefInClient(Client client);
        Task<FilterChefRequestListViewModel> FilterChefRequestList(FilterChefRequestListViewModel filterChef);
        Task<FilterChefListViewModel> FilterChefList(FilterChefListViewModel filterChefListViewModel);
        Task<Chef> GetChefRequestById(int chefId);
        void UpdateChef(Chef chef);

        #endregion

        #region Our Chef In Site

        Task<List<ChefViewModel>> GetAllChefForShowInSite();

        #endregion


        #region Save

        Task SaveChanges();

        #endregion
    }
}
