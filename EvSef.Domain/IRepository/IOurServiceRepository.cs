using EvSef.Domain.Entities.Restaurant;
using EvSef.Domain.ViewModels.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.OurService;
using EvSef.Domain.ViewModels.OurCustomer;
using EvSef.Domain.ViewModels.OurService;

namespace EvSef.Domain.IRepository
{
    public interface IOurServiceRepository: IAsyncDisposable
    {


        #region CreateOurServiceByAdmin

        Task CreateOurServiceByAdmin(OurService ourService);
        Task<bool> OurServiceTitleIsExist(string ourServiceTitle);

        #endregion

        #region FilterOurServiceList

        Task<FilterOurServiceViewModel> FilterOurServiceList(FilterOurServiceViewModel filterOurServiceViewModel);

        #endregion

        #region OurService In Site
        Task<List<OurServiceViewModel>> GetAllOurServiceForShowInSite();

        #endregion

        #region Save

        Task SaveChanges();

        #endregion
    }
}
