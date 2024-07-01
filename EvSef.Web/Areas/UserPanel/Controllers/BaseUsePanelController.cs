using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.Areas.UserPanel.Controllers
{
   
    [Area("UserPanel")]
 
    public class BaseUsePanelController : Controller
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
