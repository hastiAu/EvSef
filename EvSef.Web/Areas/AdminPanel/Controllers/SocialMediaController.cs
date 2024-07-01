using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.OurService;
using EvSef.Domain.ViewModels.SocialMedia;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class SocialMediaController : BaseAdminController
    {

        #region Constructor

        private readonly ISiteService _siteService;


        public SocialMediaController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion

        #region  Social Media List

        [HttpGet]
        [Route("Index")]
        public async Task< IActionResult> Index(FilterSocialMediaListViewModel filterSocialMediaListViewModel)
        {
            var result = await _siteService.FilterSocialMediaList(filterSocialMediaListViewModel);
            return View(result);
        }

        #endregion

        #region Cretae Social Media

        [HttpGet]
        [Route("CreateSocialMedia")]
        public IActionResult CreateSocialMediaByAdmin()
        {
            return View();
        }


        [HttpPost]
        [Route("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMediaByAdmin(CreateSocialMediaViewModel createSocialMediaViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _siteService.CreateSocialMediaByAdmin(createSocialMediaViewModel);


                switch (result)
                {
                    case CreateOurServiceResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateOurServiceResult.OurServiceTitleIsExist:
                        ModelState.AddModelError("AboutUsTitle",
                            "The Social Media Name was Registered before by this Name!");

                        return View(createSocialMediaViewModel);

                    case CreateOurServiceResult.Success:
                        ViewBag.SuccessText = "The Social Media Was Created Successfully";
                        return RedirectToAction("Index", "SocialMedia");
                }
            }

            return View(createSocialMediaViewModel);
        }

        #endregion

    }
}
