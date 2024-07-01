using EvSef.Domain.Entities.AboutUs;
using EvSef.Domain.Entities.MainSlider;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.MainSlider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.IRepository
{
    public interface IMainSliderRepository : IAsyncDisposable
    {
        #region Create Main Slider

        Task CreateMainSlidersByAdmin(MainSlider mainSlider);

        Task<bool> MainSliderTitleIsExist(string mainSliderTitle);

        #endregion

        #region MainSlider List

        Task<FilterMainSliderViewModel> FilterMainSliderList(FilterMainSliderViewModel filterMainSlider);

        #endregion

        #region MainSlider In Site

        Task<List<MainSliderViewModel>> GetAllMainSliderForShowInSite();

        #endregion

        #region Save

        Task SaveChanges();

        #endregion
    }
}
