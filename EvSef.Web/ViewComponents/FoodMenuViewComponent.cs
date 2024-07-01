using EvSef.Core.Services.Interfaces;
using EvSef.Domain.Entities.Food;
using EvSef.Domain.ViewModels.SiteSetting;
using Microsoft.AspNetCore.Mvc;

namespace EvSef.Web.ViewComponents
{
    public class FoodMenuViewComponent: ViewComponent
    {
        #region Constructor

         private readonly ISiteService _siteService;
         private readonly IFoodService _foodService;

         public FoodMenuViewComponent(ISiteService siteService, IFoodService foodService)
         {
             _siteService = siteService;
             _foodService = foodService;    
         }

         #endregion
        public async Task<IViewComponentResult> InvokeAsync(string weekDayName = "Saturday")
        {

            SiteSettingViewModel? siteSetting = await _siteService.GetSiteSettingForEdit();
            var text = siteSetting.FoodMenuTitle;
            ViewData["FoodMenuTitle"] = text;
            ViewBag.CurrentWeekDay = weekDayName;

            var foodMenu = await _foodService.GetDailyFoodMenuForShowInSite(weekDayName);
            return await Task.FromResult((IViewComponentResult)View("FoodMenu", foodMenu));
        }
    }
}
