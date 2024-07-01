using EvSef.Domain.Entities.AboutUs;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.SocialMedia;

namespace EvSef.Domain.IRepository
{
    public interface ISocialMediaRepository : IAsyncDisposable
    {

        #region Create SocialMedia

        Task CreateSocialMediaByAdmin(SocialMedia socialMedia);

        Task<bool> SocialMediaNameIsExist(string socialMediaName);

        #endregion

        #region SocialMedia List

        Task<FilterSocialMediaListViewModel> FilterSocialMediaList(FilterSocialMediaListViewModel filterSocialMediaListViewModel);

        #endregion

        #region Save

        Task SaveChanges();

        #endregion
    }
}
