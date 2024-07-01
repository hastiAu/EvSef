using System.Reflection.Metadata.Ecma335;
using EvSef.Core.Services.Implementations;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.Common;
using EvSef.Web.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using EvSef.Domain.Entities.UserType;
using DocumentFormat.OpenXml.Spreadsheet;
using EvSef.Core.Extensions;
using EvSef.Domain.ViewModels.Cart;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using EvSef.Domain.Entities.Wallet;
using Google.Apis.Admin.Directory.directory_v1.Data;
using EvSef.Domain.ViewModels.ManagementPerson;
using Microsoft.AspNetCore.Http.HttpResults;




namespace EvSef.Web.Areas.UserPanel.Controllers
{
    public class HomeController : BaseUsePanelController
    {
        #region Constructor   

        private readonly IOrderService _orderService;
        private readonly ISiteService _siteService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IOrderService orderService, ISiteService siteService, ILogger<HomeController> logger)
        {
            _orderService = orderService;
            _siteService = siteService;
            _logger = logger;
        }

        #endregion


        #region GetTax

        public async Task GetTax()
        {
            var text = await _siteService.GetSiteSettingForEdit();
            var tax = text.Tax;
            ViewData["Tax"] = tax;

        }

        #endregion



        [Authorize]
        [HttpGet("/UserPanel/CheckOut")]
        public async Task<IActionResult> CheckOut()
        {


            var text = await _siteService.GetSiteSettingForEdit();
            var tax = text.Tax;

            var userId = User.GetCurrentUserId();

            // Get Items From Session
            var cartItems = _orderService.GetFromSession();

            // Update ClientId In ShowCart after Login
            foreach (var item in cartItems)
            {
                if (item.ClientId == 0)
                {
                    item.ClientId = userId;
                }
            }


            // Get user addresses
            var userAddresses = await _orderService.GetClientContactInfoById(userId);



            // we check it in repo and create a list:
            //    List<CartAddressViewModel> cartAddresses = new List<CartAddressViewModel>();
            //so we don't need to check if null, because in repo 100% create a list for it with object, but not null
            var selectedContactInfoId = _orderService.GetSelectedContactInfoIdFromSession() ?? 0;




            // Create CartViewModel


            //First get 0/0/1 then after run 2 script it will  be change to the new date
            var deliveryAndPaymentDetails = GetDeliveryAndPaymentDetailsFromSession();

            // Create CartViewModel
            var cartViewModel = new CartViewModel
            {
                Items = cartItems,
                Tax = tax,
                SelectedContactInfoId = selectedContactInfoId,
                CartAddresses = userAddresses,
                CartDeliveryDateViewModel = deliveryAndPaymentDetails
            };

            ViewData["Address"] = selectedContactInfoId;
            await GetStateAndDistricts();

            return View(cartViewModel);


            // Handle case where SelectedContactInfoId is not available
            // Redirect or show an error message
            //return RedirectToAction("Index", "Home", new { area = "" });
        }


        [HttpPost]
     
        public IActionResult Checkout(CheckOutViewModel checkOutViewModel)
        {
            if (checkOutViewModel != null)
            {
                // اینجا می‌توانید داده‌های دریافتی را پردازش کنید
                // برای مثال: ذخیره‌سازی سفارش در پایگاه داده و انجام منطق چک‌اوت

                // فرض کنید که چک‌اوت با موفقیت انجام شده است
                bool isCheckoutSuccessful = true;

                if (isCheckoutSuccessful)
                {
                    return Json(new { success = true, message = "Checkout completed successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "There was an error completing the checkout." });
                }
            }
            else
            {
                // اگر داده‌ها دریافت نشدند، ممکن است یک خطای HTTP 400 (Bad Request) برگردانید
                return BadRequest("Invalid data received.");
            }
        }

     
        [HttpGet("/UserPanel/Home/GetCartItemsFromSession")]

        public IActionResult GetCartItemsFromSession()
        {
            var cartItems = _orderService.GetFromSession();
            return Json(cartItems);
        }

        #region ContactInfo Session

        [HttpPost]
        public IActionResult SaveSelectedContactInfoIdInSession(int selectedContactInfoId)
        {
            if (selectedContactInfoId != 0)
            {
                _orderService.SaveSelectedContactInfoIdInSession(selectedContactInfoId);

                var response = new
                {
                    success = true,
                    formData = selectedContactInfoId,
                    message = "Contact info ID saved successfully"
                };

                return Json(response);
            }
            else
            {

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }





        [HttpGet]
        public IActionResult GetSelectedContactInfoIdFromSession()
        {
            var contactInfoId = _orderService.GetSelectedContactInfoIdFromSession();


            return Ok(contactInfoId ?? 0);

        }

        [HttpGet]

        public IActionResult GetAddressDetailsFromSession()
        {
            int? contactInfoId = _orderService.GetSelectedContactInfoIdFromSession();
            if (contactInfoId.HasValue && contactInfoId.Value != 0)
            {
                var addressDetails = _orderService.GetAddressDetailsById(contactInfoId.Value);   // Update View : jquery-steps-init.js
                if (addressDetails != null)
                {
                    return Json(new { success = true, addressDetails });
                }
            }
            return Json(new { success = false, message = "No address details found" });
        }





        #endregion



        #region GetClientContactInfoById
        [HttpGet]
        public async Task<IActionResult> GetClientContactInfoById()
        {
            var userId = User.GetCurrentUserId();
            var userAddresses = await _orderService.GetClientContactInfoById(userId);


            return Json(userAddresses);
        }


        #endregion



        #region Add New Address
        [HttpGet]
        public async Task<IActionResult> GetAddNewAddressForm()
        {
            var state = await _siteService.GetStates();
            ViewData["State"] = state;

            var firstLocationId = state.First().LocationId;
            var district = await _siteService.GetDistricts(firstLocationId);
            ViewData["District"] = district;


            return PartialView("_AddNewAddressPartial", new CartAddressViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> AddNewAddress(CartAddressViewModel model, int clientId)
        {
            await GetStateAndDistricts();
            var userId = User.GetCurrentUserId();

            var result = await _orderService.CreateNewContactInfoByClient(model, userId);

            switch (result)
            {
                case CreateCartAddressResult.NotFound:
                    return Json(new { success = false, message = "Address not found." });

                case CreateCartAddressResult.AddressIsExists:
                    return Json(new { success = false, message = "This Address is registered Before" });

                case CreateCartAddressResult.Success:
                    var updatedAddresses = await _orderService.GetClientContactInfoById(userId); // Get the updated list of addresses
                    return Json(new { success = true, message = "Address added successfully!", addresses = updatedAddresses });


                default:
                    return Json(new { success = false, message = "An unexpected error occurred." });
            }
        }

        #endregion


        #region Delivery&Payment Session


        [HttpPost("/UserPanel/SaveDeliveryAndPaymentDetails")]
        public IActionResult SaveDeliveryAndPaymentDetails(CartViewModel model)
        {
            if (model != null && model.CartDeliveryDateViewModel != null)
            {
                var deliveryAndPaymentDetails = new CartDeliveryAndPaymentDetails
                {
                    DeliveryDate = model.CartDeliveryDateViewModel.DeliveryDate,
                    DeliveryTime = model.CartDeliveryDateViewModel.DeliveryTime,
                    Details = model.CartDeliveryDateViewModel.Details,
                    PaymentMethod = model.CartDeliveryDateViewModel.PaymentMethod
                };

                _orderService.SaveDeliveryAndPaymentDetailsInSession(deliveryAndPaymentDetails);


                var response = new
                {
                    success = true,
                    formData = model
                };

                return Json(response); // After this method, run GetDeliveryAndPaymentDetailsFromSession, both in AJax in Jquery-step and return data to checkout


            }
            else
            {

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }




        public CartDeliveryAndPaymentDetails GetDeliveryAndPaymentDetailsFromSession()
        {
            var deliveryAndPaymentDetails = _orderService.GetDeliveryAndPaymentDetailsFromSession();
            if (deliveryAndPaymentDetails == null)
            {
                deliveryAndPaymentDetails = new CartDeliveryAndPaymentDetails();
            }

            return deliveryAndPaymentDetails;
        }



        #endregion


        #region Add/Remove ToCart

        public async Task<IActionResult> AddToCart(int chefFoodId, bool stayInCartPage = false)
        {
            var userId = User.GetCurrentUserId();

            var item = await _orderService.GetItemByChefFoodId(chefFoodId);
            if (item != null)
            {
                item.ClientId = userId;
                _orderService.SaveInSession(item);

            }

            // Save returnUrl in session
            var returnUrl = stayInCartPage ? "/UserPanel/ShowCart" : "/";
            HttpContext.Session.SetString("returnUrl", returnUrl);

            // Check value in Both View: FoodMenu & ShowCart
            if (stayInCartPage)
            {
                return RedirectToAction("CheckOut", "Home", new { area = "UserPanel" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }



        public async Task<IActionResult> RemoveFromCart(int chefFoodId)
        {
            var userId = User.GetCurrentUserId();
            var item = await _orderService.GetItemByChefFoodId(chefFoodId);
            if (item != null)
            {
                item.ClientId = userId;
                _orderService.RemoveFromSession(item);
            }

            return RedirectToAction("CheckOut");
        }


        public IActionResult ClearCart()
        {
            // Clear all items from session
            _orderService.ClearSession();

            return RedirectToAction("CheckOut");
        }


        #endregion


        #region CartHistory


        [HttpGet("/UserPanel/CartHistory")]
        public IActionResult CartHistory(string menu)
        {
            ViewData["Menu"] = menu;
            return View();
        }


        #endregion

        #region CustomMenu


        [HttpGet("/UserPanel/CustomMenu")]
        public IActionResult CustomMenu(string menu)
        {
            ViewData["Menu"] = menu;
            return View();
        }

        #endregion


        #region FinancialHistory

        [HttpGet("/UserPanel/FinancialHistory")]
        public IActionResult FinancialHistory(string menu)
        {
            ViewData["Menu"] = menu;
            return View();
        }

        #endregion


        #region Help


        [HttpGet("/UserPanel/Help")]
        public IActionResult Help(string menu)
        {
            ViewData["Menu"] = menu;
            return View();
        }

        #endregion

        #region UserProfile

        [HttpGet("/UserPanel/UserProfile")]
        public IActionResult UserProfile(string menu)
        {
            ViewData["Menu"] = menu;
            return View();
        }


        #endregion


        #region LogOut


        [HttpGet("/UserPanel/LogOut")]
        public async Task<IActionResult> LogOut(string menu)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData[InfoMessage] = "You Logout Successfully";
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        #endregion


        #region State & District


        public async Task<IActionResult> GetDistrictGroup(int id)
        {
            var district = await _siteService.GetDistricts(id);
            return Json(district);
        }

        public async Task GetStateAndDistricts()
        {
            var state = await _siteService.GetStates();
            ViewData["State"] = state;

            var firstLocationId = state.First().LocationId;
            var district = await _siteService.GetDistricts(firstLocationId);
            ViewData["District"] = district;

        }


        #endregion



    }

}
