using EvSef.Core.Services.Interfaces;
using EvSef.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EvSef.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Constructor


        private readonly ILogger<HomeController> _logger;
        private readonly ISiteService _siteService;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, ISiteService siteService, IOrderService orderService)
        {
            _logger = logger;
            _siteService = siteService;
            _orderService = orderService;
        }

        #endregion


        public async Task< IActionResult> Index()
        {
            var text = await _siteService.GetSiteSettingForEdit();
            var logo = text.SiteLogo;
            ViewData["Logo"] = logo;
            return View();
        }
 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
