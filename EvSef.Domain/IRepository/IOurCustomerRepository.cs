using Google.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.OurCustomer;
using EvSef.Domain.ViewModels.OurCustomer;

namespace EvSef.Domain.IRepository
{
    public interface IOurCustomerRepository : IAsyncDisposable
    {


        #region OurCustomerList

        Task<FilterOurCustomerViewModel> FilterOurCustomerList(FilterOurCustomerViewModel filterOurCustomerViewModel);

        #endregion

        #region OurCustomer

        Task CreateOurCustomerByAdmin(OurCustomer ourCustomer);

        Task<bool> IsExistOurCustomerName(string ourCustomerName);


        #endregion

        #region OurCustomer In Site

        Task<List<OurCustomerViewModel>> GetAllOurCustomerForShowInSite();

         #endregion

        #region Save

        Task SaveChanges();

        #endregion
    }
}
