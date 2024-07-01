using EvSef.Domain.Entities.JoinUs;
using EvSef.Domain.ViewModels.JoinUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.BeComeChef;
using EvSef.Domain.ViewModels.BeComeChef;

namespace EvSef.Domain.IRepository
{
    public interface IBeComeChefRepository : IAsyncDisposable
    {

        #region CreateBeComeCheByAdmin

        Task CreateBeComeChefByAdmin(BeComeChef beComeChef);
        Task<bool> BeComeChefIsExistByTitle(string beComeChefTitle);

        #endregion

        #region FilterJoinUsList

        Task<FilterBeComeChefViewModel> FilterBeComeChefList(FilterBeComeChefViewModel filterBeComeChefViewModel);

        #endregion


        #region BeComeChef(WhyUs) In Site
        Task<List<BeComeChefViewModel>> GetAllBeComeChefForShowInSite();

        #endregion

        #region Save

        Task SaveChanges();

        #endregion
    }
}
