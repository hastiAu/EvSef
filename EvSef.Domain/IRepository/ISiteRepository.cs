using EvSef.Domain.Entities.ContactInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.IRepository
{
    public interface ISiteRepository : IAsyncDisposable
    {
        #region State & District
        Task<List<ContactLocation>> GetStates();
        Task<List<ContactLocation>> GetDistricts(int locationId);
     

        #endregion
    }
}
