using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.CorporationFoodOrder;
using EvSef.Domain.ViewModels.CorporationFoodOrder;

namespace EvSef.Domain.IRepository
{
    public interface ICorporationFoodOrderRepository: IAsyncDisposable
    {
        #region CorporationFoodOrderList

        Task<FilterCorporationFoodOrderViewModel> CorporationFoodOrderList(FilterCorporationFoodOrderViewModel filterCorporationFoodOrderViewModel);
        

            #endregion

        #region CreateCorporationFoodOrder

        Task CreateCorporationFoodOrderByAdmin(CorporationFoodOrder corporationFoodOrder);
        Task<bool> CorporationFoodTitleIsExist(string corporationFoodOrderTitle);

        #endregion

        #region Corporation Food Order In Site

        Task<List<CorporationFoodOrderViewModel>> GetAllHowOrderCorporationFoodForShowInSite();

        #endregion


        #region Save

        Task SaveChanges();

        #endregion
    }
}
