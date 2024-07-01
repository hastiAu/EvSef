using EvSef.Domain.Entities.AboutUs;
using EvSef.Domain.Entities.CustomFood;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.CustomFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.IRepository
{
    public interface ICustomFoodRepository :IAsyncDisposable
    {

        #region Create CustomFood

        Task CreateCustomFoodByAdmin(CustomFood customFood);

        Task<bool> CustomFoodTitleIsExist(string customFoodTitle);

        #endregion


        #region CustomFood List

        Task<FilterCustomFoodViewModel> FilterCustomFoodList(FilterCustomFoodViewModel filterCustomFoodViewModel);

        #endregion


        #region CustomFood In Site

        Task<List<CustomFoodViewModel>> GetAllCustomFoodForShowInSite();

        #endregion

        #region Save

        Task SaveChanges();

        #endregion
    }
}
