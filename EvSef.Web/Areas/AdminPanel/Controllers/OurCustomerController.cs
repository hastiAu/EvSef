using EvSef.Core.Services.Implementations;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.Chef;
using EvSef.Domain.ViewModels.OurCustomer;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class OurCustomerController : BaseAdminController 
    {

        #region Constructor

        private readonly ISiteService _siteService;

        public OurCustomerController(ISiteService siteService)
        {
            _siteService = siteService; 
        }

        #endregion


        #region Filter Our Customer List

        [HttpGet]
        [Route("OurCustomerList")]
        public async Task<IActionResult> Index(FilterOurCustomerViewModel filterOurCustomerViewModel)
        {
            var result = await _siteService.FilterOurCustomerList(filterOurCustomerViewModel);
            return View(result);
        }


        #endregion

        #region Create Our Customer

        [HttpGet]
        [Route("CreateOurCustomer")]
        public IActionResult CreateOurCustomer()
        {
            return View();
        }


        [HttpPost]
        [Route("CreateOurCustomer")]
        public async Task<IActionResult> CreateOurCustomer(CreateOurCustomerViewModel createOurCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _siteService.CreateOurCustomerByAdmin(createOurCustomerViewModel);


                switch (result)
                {
                    case CreateOurCustomerResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateOurCustomerResult.CustomerNameIsExist:
                        ModelState.AddModelError("CustomerName",
                            "The CustomerName was Registered before by this Name!");

                        return View(createOurCustomerViewModel);

                    case CreateOurCustomerResult.Success:
                        ViewBag.SuccessText = "Our Customer Was Created Successfully";
                        return RedirectToAction("Index", "OurCustomer");
                }
            }

            return View(createOurCustomerViewModel);
        }

        #endregion


    }
}
