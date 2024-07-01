using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.BeComeChef;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class AboutUsController : BaseAdminController
    {
        #region Constructor

        private readonly ISiteService _siteService;


        public AboutUsController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion

        #region AboutUs List

        [HttpGet]
        [Route("AboutUsList")]
        public async Task<IActionResult> Index(FilterAboutUsListViewModel filterAboutUsListViewModel)
        {
            var result = await _siteService.FilterAboutUsList(filterAboutUsListViewModel);
            return View(result);
        }

        #endregion

        #region  Create AboutUs

        [HttpGet]
        [Route("CreateAboutUs")]
        public IActionResult CreateAboutUsByAdmin()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateAboutUs")]
        public async Task<IActionResult> CreateAboutUsByAdmin(CreateAboutUsViewModel createAboutUsViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _siteService.CreateAboutUsByAdmin(createAboutUsViewModel);


                switch (result)
                {
                    case CreateAboutUsResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateAboutUsResult.AboutUsTitleIsExist:
                        ModelState.AddModelError("AboutUsTitle",
                            "The AboutUs Title was Registered before by this Title!");

                        return View(createAboutUsViewModel);

                    case CreateAboutUsResult.Success:
                        ViewBag.SuccessText = "The AboutUs Was Created Successfully";
                        return RedirectToAction("Index", "AboutUs");
                }
            }

            return View(createAboutUsViewModel);
        }



        #endregion
    }
}
