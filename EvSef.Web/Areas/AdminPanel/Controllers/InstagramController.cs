using EvSef.Core.Services.Interfaces;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.Instagram;
using EvSef.Web.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class InstagramController : BaseAdminController
    {

        #region Constructor

        private readonly ISiteService _siteService;


        public InstagramController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion


        #region Instagram List

        [HttpGet]
        [Route("InstagramPostList")]
        public async Task<IActionResult> Index(InstagramListViewModel instagramListViewModel)
        {
            var result = await _siteService.InstagramPostList(instagramListViewModel);
            return View(result);
        }

        #endregion

        #region Create Instagram

        [HttpGet]
        [Route("CreateInstagramPost")]
        public IActionResult CreateInstagramPostByAdmin()
        {
          
            return View();
        }

        [HttpPost]
        [Route("CreateInstagramPost")]
        public async Task<IActionResult> CreateInstagramPostByAdmin(CreateInstagramViewModel createInstagramViewModel, int id)
        {
            var userId = User.GetCurrentUserId();
            if (ModelState.IsValid)
            {
                var result = await _siteService.CreateInstagramPostByAdmin(createInstagramViewModel, userId);


                switch (result)
                {
                    case CreateInstagramResult.NotFound:
                        return RedirectToAction("NotFound", "Home");

                    case CreateInstagramResult.InstagramUrlIsExist:
                        ModelState.AddModelError("Url",
                            "The Instgram url was Registered before by this Title!");

                        return View(createInstagramViewModel);

                    case CreateInstagramResult.Success:
                        ViewBag.SuccessText = "The Instagram Post Was Created Successfully";
                        return RedirectToAction("Index", "Instagram");
                }
            }

            return View(createInstagramViewModel);
        }



        #endregion
    }
}
