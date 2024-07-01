using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.ManagementPerson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Mono.TextTemplating;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class UserController : BaseAdminController
    {
        #region Constructor

        private readonly IUserService _userService;
        private readonly ISiteService _siteService;

        public UserController(IUserService userService, ISiteService siteService)
        {
            _userService = userService;
            _siteService = siteService;
        }

        #endregion
        public async Task<IActionResult> Index(FilterPersonViewModel filter)
        {

            var person = await _userService.FilterPersons(filter);
            return View(person);
        }

        #region CreatePerson


        public async Task GetStateAndDistricts()
        {
            var state = await _siteService.GetStates();
            ViewData["State"] = state;

            var firstLocationId = state.First().LocationId;
            var district = await _siteService.GetDistricts(firstLocationId);
            ViewData["District"] = district;

        }

        [HttpGet]
        [Route("CreateUser")]
        public async Task<IActionResult> CreatePersonByAdmin( )
        {
            var state = await _siteService.GetStates();
            ViewData["State"] = state;

            var firstLocationId = state.First().LocationId;
            var district = await _siteService.GetDistricts(firstLocationId);
            ViewData["District"] = district;

            return View();
        }


        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreatePersonByAdmin(CreatePersonViewModel createPersonViewModel)
        {
           

            var result = await _userService.CreatePersonByAdmin(createPersonViewModel);
            switch (result)
            {
                  
                case CreatePersonResult.NotFound:
                    return RedirectToAction("NotFound", "Home");
                case CreatePersonResult.EmailIsExists:
                    ModelState.AddModelError("Email", "This Email is registered Before");
                    await GetStateAndDistricts();
                    return View(createPersonViewModel);
                

                case CreatePersonResult.MobileNumberIsExists:
                    ModelState.AddModelError("Mobile", "This Mobile Number is registered Before");
                    await GetStateAndDistricts();
                    return View(createPersonViewModel);

                case CreatePersonResult.Success:
                    ViewBag.SuccessText = "Person Was Created Successfully";
                    return RedirectToAction("Index", "User");
            }

            await GetStateAndDistricts();
            ViewBag.ErrorText = "Person Was Not Created Successfully";
            return View(createPersonViewModel);
        }


        public async Task<IActionResult> GetDistrictGroup(int id)
        {
            var district = await _siteService.GetDistricts(id);
            return Json(district);
        }
        #endregion
    }
}
