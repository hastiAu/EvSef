using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;
using EvSef.Domain.Entities.Account;
using EvSef.Web.ViewComponents;
using EvSef.Domain.ViewModels.Corporation;
using EvSef.Web.Identity;

namespace EvSef.Web.Controllers
{
   

    public class AccountController : SiteBaseController
    {

        #region Constructor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Persons

        [HttpGet]
        [Route("Register")]
        public IActionResult RegisterPerson()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterPerson(RegisterPersonViewModel registerPersonViewModel)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterPerson(registerPersonViewModel);

                switch (result)
                {
                    case RegisterPersonResult.NotFound:
                        TempData[ErrorMessage] = "NotFound";
                        break;

                    case RegisterPersonResult.PersonExists:
                        TempData[WarningMessage] = "You are registered Before with this Mobile Number";
                        break;
                    case RegisterPersonResult.Success:
                        TempData[SuccessMessage] = "Your Registration was Successful, You can Login";
                        return RedirectToAction("Index", "Home");

                }
            }

            return View(registerPersonViewModel);
        }

        #endregion


        #region Login

        
        [HttpGet("Login")]
        public IActionResult Login(string returnUrl = null)
        {
            
            LoginViewModel loginViewModel = new LoginViewModel();
            ViewData["ReturnUrl"] = returnUrl;
            return PartialView("LoginModalPartial", loginViewModel);
        }

      

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginClient(login);

                switch (result)
                {
                    case LoginClientResult.UserNotFound:
                        TempData[ErrorMessage] = "User Is not Found";
                        break;

                    case LoginClientResult.NotActive:
                        TempData[WarningMessage] = "You Are not Active User";
                        break;

                    case LoginClientResult.Success:
                        var client = await _userService.GetClientByMobile(login.Mobile);
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, client.ClientId.ToString()),
                            new Claim(ClaimTypes.NameIdentifier,client.RelatedId.ToString()),
                            new Claim(ClaimTypes.MobilePhone, client.MobileNumber),
                            new Claim(ClaimTypes.Email, client.Email),
                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = login.RememberMe
                        };

                        await HttpContext.SignInAsync(principal, properties);

                        TempData[SuccessMessage] = "You are login Successfully";

                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                }
            }

            // If login fails, return the view with the login modal

            ViewData["ReturnUrl"] = returnUrl;
            return RedirectToAction("Index", "Home", PartialView("LoginModalPartial", login));
        }
 


        #endregion




        #region LogOut

        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData[InfoMessage] = "You Logout SuccessFully";
            return RedirectToAction("Index", "Home");

        }

        #endregion

        #region Corporations

        [HttpGet("CorporationRegister")]
        public IActionResult CorporationRegisterRequest()
        {

            CorporationRequestViewModel corporationViewModel = new CorporationRequestViewModel();
            return PartialView("CorporationRegisterPartial", corporationViewModel);
        }


        [HttpPost()]
        [Route("CorporationRegister")]
        public async Task<IActionResult> CorporationRegisterRequest(CorporationRequestViewModel corporationRequestViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateCorporationRequest(corporationRequestViewModel);


                switch (result)
                {
                    case CorporationRequestResult.Failed:
                        TempData[ErrorMessage] = "Your Request is not Valid";
                        return RedirectToAction("Index", "Home", corporationRequestViewModel);


                    case CorporationRequestResult.UserHasRequestWithThisNumber:
                        TempData[WarningMessage] = "You Sent a Request with this number Before, Wait for Our Staff Call";
                        return RedirectToAction("Index", "Home");

                    case CorporationRequestResult.Successfully:
                        TempData[SuccessMessage] = "Your Request send, Our Staff Calling You As soon As Possible";
                        return RedirectToAction("Index", "Home");
                }
            }


            return RedirectToAction("Index", "Home", corporationRequestViewModel);

        }

        #endregion
    }
}