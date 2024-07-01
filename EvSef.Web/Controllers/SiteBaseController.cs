using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Controllers
{
    public class SiteBaseController : Controller
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
