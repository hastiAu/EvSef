using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.JoinUs;
using EvSef.Domain.ViewModels.JoinUs;

namespace EvSef.Domain.IRepository
{
    public interface IJoinUsRepository : IAsyncDisposable
    {

        #region CreateJoinUsByAdmin

        Task CreateJoinUsByAdmin(JoinUs joinUs);
        Task<bool>JoinUsIsExistByTitle(string joinUsTitle);

        #endregion

        #region FilterJoinUsList

        Task<FilterJoinUsViewModel>FilterJoinUsList(FilterJoinUsViewModel filterJoinUsViewModel);

        #endregion

        #region JoinUs In Site

        Task<List<JoinUsViewModel>> GetAllJoinUsForShowInSite();

            #endregion
        #region Save

        Task SaveChanges();

        #endregion

    }
}
