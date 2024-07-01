using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BaseAdminController : Controller
    {
        protected string SuccessMessage = "SuccessMessage";
        protected string ErrorMessage = "ErrorMessage";
        protected string WarningMessage = "WarningMessage";
        protected string InfoMessage = "InfoMessage";

        public IActionResult NotFound()
        {

     
            return View();
        }
    }
}
