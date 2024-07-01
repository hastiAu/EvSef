using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.AboutUs;
using EvSef.Domain.ViewModels.AboutUs;

namespace EvSef.Domain.IRepository
{
    public interface IAboutUsRepository : IAsyncDisposable
    {
        #region Create AboutUs

        Task CreateAboutUsByAdmin(AboutUs aboutUs);

        Task<bool> AboutUsTitleIsExist(string aboutUsTitle);

        #endregion

        #region AboutUs

        Task<FilterAboutUsListViewModel> FilterAboutUsList(FilterAboutUsListViewModel filterAboutUs);

        #endregion

        #region AboutUs In Site

        Task<List<AboutUsViewModel>> GetAllAboutUsInSiteForShowInSite();

       #endregion

        #region Save

        Task SaveChanges();

        #endregion
    }
}
