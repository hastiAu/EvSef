using EvSef.Core.Convertors;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.JoinUs;
using EvSef.Domain.ViewModels.OurCustomer;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class JoinUsController : BaseAdminController
    {
        #region Constructor

        private readonly ISiteService _siteService;


        public JoinUsController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion
        [HttpGet]
        [Route("JoinUsList")]
        public async Task<IActionResult> Index(FilterJoinUsViewModel filterJoinUsViewModel)
        {
            var result= await _siteService.FilterJoinUsList(filterJoinUsViewModel);
            return View(result);
        }

        #region Create JoinUs ByAdmin

        [HttpGet]
        [Route("CreateJoinUs")]
        public IActionResult CreateJoinUsByAdmin()
        {
            return View();
        }



        [HttpPost]
        [Route("CreateJoinUs")]
        public async Task<IActionResult> CreateJoinUsByAdmin(CreateJoinUsViewModel createJoinUsViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _siteService.CreateJoinUsByAdmin(createJoinUsViewModel);


                switch (result)
                {
                    case CreateJoinUsResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateJoinUsResult.JoinUsTitleIsExist:
                        ModelState.AddModelError("JoinUsTitle",
                            "The JoinUs was Registered before by this Name!");

                        return View(createJoinUsViewModel);

                    case CreateJoinUsResult.Success:
                        ViewBag.SuccessText = "The JoinUs Was Created Successfully";
                        return RedirectToAction("Index", "JoinUs");
                }
            }

            return View(createJoinUsViewModel);
        }



        #endregion
    }
}
