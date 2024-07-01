using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.SiteSetting;
using EvSef.Domain.ViewModels.SiteSetting;

namespace EvSef.Domain.IRepository
{
    public interface ISiteSettingRepository : IAsyncDisposable
    {
        #region SiteSetting

        Task<SiteSettingViewModel?> GetSitSettingForEdit();
        void UpdateSiteSetting(SiteSetting siteSetting);
        Task<SiteSetting> GetSiteSettingById(int id);

        #endregion

 

        #region Save

        Task SaveChanges();

        #endregion
    }
}
