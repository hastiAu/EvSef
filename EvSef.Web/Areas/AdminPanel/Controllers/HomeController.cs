using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    public class HomeController : BaseAdminController
    {

        [Area("AdminPanel")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
