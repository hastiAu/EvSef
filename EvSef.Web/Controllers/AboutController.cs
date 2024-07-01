using EvSef.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Controllers
{
    public class AboutController : SiteBaseController
    {

        #region Constructor

    
        private readonly ISiteService _siteService;

        public AboutController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        #endregion

        [Route("About")]
        public async Task< IActionResult> AboutUs()
        {
            var result = await _siteService.GetAllAboutUsInSiteForShowInSite();
            return View(result);
        }
    }
}
