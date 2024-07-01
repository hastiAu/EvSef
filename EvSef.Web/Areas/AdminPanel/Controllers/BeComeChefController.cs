using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.BeComeChef;
using EvSef.Domain.ViewModels.JoinUs;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class BeComeChefController : BaseAdminController
    {

        #region Constructor

        private readonly ISiteService _siteService;


        public BeComeChefController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion

        #region BeComeChefList

        [HttpGet]
        [Route("BeComeChefList")]
        public async Task<IActionResult> Index(FilterBeComeChefViewModel filterBeComeChefViewModel)
        {
            var result = await _siteService.FilterBeComeChefList(filterBeComeChefViewModel);
            return View(result);
        }
        #endregion

        #region CreateJoinUsByAdmin

        [HttpGet]
        [Route("CreateBeComeChef")]
        public IActionResult CreateBeComeChefByAdmin()
        {
            return View();
        }



        [HttpPost]
        [Route("createBeComeChef")]
        public async Task<IActionResult> CreateBeComeChefByAdmin(CreateBeComeChefViewModel createBeComeChefViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _siteService.CreateBeComeChefByAdmin(createBeComeChefViewModel);


                switch (result)
                {
                    case CreateBeComeChefResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateBeComeChefResult.CreateBeChefTitleIsExist:
                        ModelState.AddModelError("BeComeChefTitle",
                            "The BeCome Chef was Registered before by this Title!");

                        return View(createBeComeChefViewModel);

                    case CreateBeComeChefResult.Success:
                        ViewBag.SuccessText = "The BeCome Chef Was Created Successfully";
                        return RedirectToAction("Index", "BeComeChef");
                }
            }

            return View(createBeComeChefViewModel);
        }



        #endregion
    }
}
