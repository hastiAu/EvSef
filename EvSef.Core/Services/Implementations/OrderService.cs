using EvSef.Core.Services.Interfaces;
using EvSef.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Core.Extensions;
using EvSef.Core.Generator;
using EvSef.Domain.Entities.ContactInfo;
using EvSef.Domain.Entities.Order;
using EvSef.Domain.ViewModels.Cart;
using Microsoft.AspNetCore.Http;
using EvSef.Domain.ViewModels.ManagementPerson;
using EvSef.Domain.Entities.UserType;
using EvSef.Infra.Data.Repository;
using EvSef.Domain.Entities.OrderDetails;


namespace EvSef.Core.Services.Implementations
{
    public class OrderService: IOrderService
    {

        #region Constructor

        private readonly IOrderRepository _orderRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(IOrderRepository orderRepository, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region  Show CartItem

 
        public async Task<CartItemViewModel> GetItemByChefFoodId(int chefFoodId)
        {
            return await _orderRepository.GetItemByChefFoodId(chefFoodId);
        }

        public async Task<List<CartAddressViewModel>> GetClientContactInfoById(int clientId)
        {
            return await _orderRepository.GetClientContactInfoById(clientId);
        }

        public async Task<RelatedType> GetRelatedTypeByClientId(int clientId)
        {
            return await _orderRepository.GetRelatedTypeByClientId(clientId);
        }

      

        public CartAddressViewModel GetAddressDetailsById(int contactInfoId)
        {
            return _orderRepository.GetAddressDetailsById(contactInfoId);
        }

 


        public async Task<CreateCartAddressResult> CreateNewContactInfoByClient(CartAddressViewModel cartAddressViewModel, int clientId)
        {
            if(await _orderRepository.AddressIsExists(cartAddressViewModel.Address))
            {
                return CreateCartAddressResult.AddressIsExists;
            }

            if (cartAddressViewModel == null)
            {

                return CreateCartAddressResult.NotFound;

            }

            var relatedType = await _orderRepository.GetRelatedTypeByClientId(clientId);

            var contactInfo = new ContactInfo()
            {
                ContactInfoAddress = cartAddressViewModel.Address.SanitizeText(),
                ContactInfoZipCode = cartAddressViewModel.ZipCode.SanitizeText(),
                RegisterDate = DateTime.Now,
                LocationId = (int)(cartAddressViewModel.LocationId == 0 ? null : cartAddressViewModel.LocationId),
                RelatedType = relatedType,
                RelatedId = clientId,
                

            };

            await _orderRepository.CreateNewContactInfoByClient(contactInfo);
            await _orderRepository.SaveChanges();
            return CreateCartAddressResult.Success;
        }



        #endregion

        #region CreateFinalOrder

        public async Task<CheckOutResultModel> CreateFinalOrder(CheckOutViewModel checkOutViewModel, int userId)
        {
            try
            {
                if (checkOutViewModel == null || userId == 0)
                {
                    return new CheckOutResultModel { Result = CheckOutResult.NotFound, OrderNumber = null };
                }

                var orderNumber = RandomNumber.Generate(100000, 999999).ToString();
                bool isOrderNumberExists = await _orderRepository.OrderNumberIsExists(orderNumber);

                if (isOrderNumberExists)
                {
                    return new CheckOutResultModel { Result = CheckOutResult.CheckOutIsExist, OrderNumber = null };
                }

                var clientId = await _orderRepository.GetClientIdByRelatedId(userId);
                Order order = new Order()
                {
                    ClientId = clientId,
                    OrderNumber = orderNumber,
                    ContactInfoId = checkOutViewModel.CartAddresses.ContactInfoId,
                    OrderTotalTaxAmount = checkOutViewModel.Tax,
                    TotalAmount = checkOutViewModel.FinalPrice,
                    OrderType = OrderType.PreOrder,
                    OrderTotalDiscountAmount = 0,
                    OrderDescription = checkOutViewModel.CartDeliveryDateViewModel.Details,
                    DeliveryDate = checkOutViewModel.CartDeliveryDateViewModel.DeliveryDate,
                    DeliveryTime = checkOutViewModel.CartDeliveryDateViewModel.DeliveryTime,
                    PaymentType = checkOutViewModel.CartDeliveryDateViewModel.PaymentMethod,
                    RegisterDate = DateTime.Now,
                    CreatedUser = userId,
                };

                await _orderRepository.CreateFinalOrder(order);
                await _orderRepository.SaveChanges();

                return new CheckOutResultModel { Result = CheckOutResult.Success, OrderNumber = orderNumber };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateFinalOrder: {ex.Message}");
                return new CheckOutResultModel { Result = CheckOutResult.CheckOutIsExist, OrderNumber = null };
            }
        }



        #endregion

        #region Session

        //Get CartItem From Session
        public List<CartItemViewModel> GetFromSession()
        {
            var result = _httpContextAccessor.HttpContext.Session.GetJson<List<CartItemViewModel>>("ses-basket");

            if (result == null)
            {
                return new List<CartItemViewModel>();
            }
            return result;
        }

        //    return result ?? new List<CartItemViewModel>();


        //Save CartItem in Session
        public void SaveInSession(CartItemViewModel item)
        {

            var cart = GetFromSession();
            int index = cart.FindIndex(m => m.ChefFoodId == item.ChefFoodId);
            if (index != -1)
            {
                cart[index].Quantity += 1;
            }
            else
            {
                cart.Add(new CartItemViewModel()
                {
                    Quantity = item.Quantity,
                    ChefFoodId = item.ChefFoodId,
                    FoodTitle = item.FoodTitle,
                    ChefFoodsPrice = item.ChefFoodsPrice,
                    ImageFood = item.ImageFood,
                    ClientId = item.ClientId,

                });
            }


            _httpContextAccessor.HttpContext.Session.SetJson("ses-basket", cart);

        }

        public void RemoveFromSession(CartItemViewModel item)
        {
            var cart = GetFromSession();
            int index = cart.FindIndex(m => m.ChefFoodId == item.ChefFoodId);
            if (index != -1)
            {
                cart[index].Quantity--;

                // Check if quantity is zero after decrementing
                if (cart[index].Quantity <= 0)
                {
                    cart.RemoveAt(index); // Remove item from cart if quantity is zero or negative
                }
            }

            _httpContextAccessor.HttpContext.Session.SetJson("ses-basket", cart);
        }


  

        public CartDeliveryAndPaymentDetails GetDeliveryAndPaymentDetailsFromSession()
        {
            var result = _httpContextAccessor.HttpContext.Session.GetJson<CartDeliveryAndPaymentDetails>("DeliveryAndPaymentDetails");

            if (result == null)
            {
                return new CartDeliveryAndPaymentDetails();
            }


            return result;
        }


        //Save Delivery And PaymentDetails in Session

        public void SaveDeliveryAndPaymentDetailsInSession(CartDeliveryAndPaymentDetails cartDeliveryAndPaymentDetails)
        {
            // If ViewModel was null
            if (cartDeliveryAndPaymentDetails == null)
            {
                throw new ArgumentNullException(nameof(cartDeliveryAndPaymentDetails), "Delivery details cannot be null.");
            }

            _httpContextAccessor.HttpContext.Session.SetJson("DeliveryAndPaymentDetails", cartDeliveryAndPaymentDetails);
        }




        //Get ContactInfo _ Address Session
        public int? GetSelectedContactInfoIdFromSession()
        {
            var result = _httpContextAccessor.HttpContext.Session.GetJson<int>("contactInfoIdSession");

            if (result == null)
            {
                return 0;
            }


            return result;
        }

   


        //Save ContactInfo _ Address Session

        public void SaveSelectedContactInfoIdInSession(int contactInfoId)
        {
            if (contactInfoId == 0)
            {
                throw new ArgumentNullException(nameof(contactInfoId), "ContactInfo details cannot be null.");
            }

            _httpContextAccessor.HttpContext.Session.SetJson("contactInfoIdSession", contactInfoId);
        }

 



        //ClearSession
        public void ClearSession()
        {

            var session = _httpContextAccessor.HttpContext.Session;
            session.Clear();
        }

      

        #endregion

    }
}
