using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.IRepository
{
    public interface IFaqRepository :IAsyncDisposable
    {
        #region Save

        Task SaveChanges();

        #endregion
    }
}
