using EvSef.Domain.Entities.AboutUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Instagram;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.Instagram;

namespace EvSef.Domain.IRepository
{
    public interface IInstagramRepository : IAsyncDisposable
    {
        #region Create Instagram Post

   
        Task CreateInstagramByAdmin(Instagram instagram);

        Task<bool> InstagramUrlIsExist(string instagramUrl);



        #endregion


        #region Instagram List
        
        Task<InstagramListViewModel> InstagramPostList(InstagramListViewModel instagramListViewModel);

        #endregion


        #region Instagram In Site


        Task<List<InstagramViewModel>> GetAllInstagramPostForShowInSite();
            #endregion
        #region Save

        Task SaveChanges();

        #endregion
    }
}
