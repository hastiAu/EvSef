using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.ContactInfo;
using EvSef.Domain.Entities.Order;
using EvSef.Domain.ViewModels.Cart;

namespace EvSef.Core.Services.Interfaces
{
    public interface IOrderService
    {

        #region Show CartItem

        Task<CartItemViewModel> GetItemByChefFoodId(int chefFoodId);
        Task<List<CartAddressViewModel>> GetClientContactInfoById(int clientId);
        Task<CreateCartAddressResult> CreateNewContactInfoByClient(CartAddressViewModel cartAddressViewModel, int clientId);
        Task<RelatedType> GetRelatedTypeByClientId(int clientId);
        CartAddressViewModel GetAddressDetailsById(int contactInfoId);
        #endregion

        #region CreateFinalOrder

        //Task<CheckOutResult> CreateFinalOrder(CheckOutViewModel checkOutViewModel, int userId);
        Task<CheckOutResultModel> CreateFinalOrder(CheckOutViewModel checkOutViewModel, int userId);



        #endregion

        #region Session

        // CartItem Session
        List<CartItemViewModel> GetFromSession();
        void SaveInSession(CartItemViewModel item);
        void RemoveFromSession(CartItemViewModel item);
        void ClearSession();


        // CartDelivery And PaymentDetails Session
        CartDeliveryAndPaymentDetails GetDeliveryAndPaymentDetailsFromSession();
        void SaveDeliveryAndPaymentDetailsInSession(CartDeliveryAndPaymentDetails cartDeliveryAndPaymentDetails);

        // ContactInfo _ Address Session
        int? GetSelectedContactInfoIdFromSession();
        void SaveSelectedContactInfoIdInSession(int contactInfoId);


        #endregion

        #region Create Order



        #endregion
    }
}
