using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.ContactInfo;
using EvSef.Domain.Entities.Order;
using EvSef.Domain.ViewModels.Cart;


namespace EvSef.Domain.IRepository
{
    public interface IOrderRepository : IAsyncDisposable
    {
        #region Show CartItem

        Task<CartItemViewModel> GetItemByChefFoodId(int chefFoodId);
        Task<List<CartAddressViewModel>> GetClientContactInfoById(int clientId);
        Task CreateNewContactInfoByClient(ContactInfo contactInfo);
        Task<bool> AddressIsExists(string address);
        Task<RelatedType> GetRelatedTypeByClientId(int clientId);
        CartAddressViewModel GetAddressDetailsById(int contactInfoId);
        #endregion

    

        #region Create Order

        //Task CreateOrder (Order order);

        #endregion

        #region Save

        Task SaveChanges();

        #endregion
    }
}
