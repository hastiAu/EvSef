using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.ViewComponents
{
    public class SiteSearchViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("SiteSearch"));
        }
    }
}
