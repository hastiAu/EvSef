using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Core.Services.Implementations;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.IRepository;
using EvSef.Infra.Data.Repository;
using EvSef.Core.Convertors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EvSef.Infra.IoC.Dependency
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            #region Services Injection

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ISiteService, SiteService>();
            service.AddScoped<IFoodService, FoodService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<IViewRenderService, RenderViewToString>();
            service.AddHttpContextAccessor();


            #endregion


            #region Repositories Injection

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ISiteRepository, SiteRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IMainSliderRepository, MainSliderRepository>();
            service.AddScoped<IChefRepository, ChefRepository>();
            service.AddScoped<IFoodRepository, FoodRepository>();
            service.AddScoped<IOurCustomerRepository, OurCustomerRepository>();
            service.AddScoped<ICorporationFoodOrderRepository, CorporationFoodOrderRepository>();
            service.AddScoped<IJoinUsRepository, JoinUsRepository>();
            service.AddScoped<IBeComeChefRepository, BeComeChefRepository>();
            service.AddScoped<IOurServiceRepository, OurServiceRepository>();
            service.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
            service.AddScoped<IFaqRepository, FaqRepository>();
            service.AddScoped<IAboutUsRepository, AboutUsRepository>();
            service.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            service.AddScoped<ICustomFoodRepository, CustomFoodRepository>();
            service.AddScoped<IInstagramRepository, InstagramRepository>();
            service.AddScoped<ISiteSettingRepository, SiteSettingRepository>();
         

            #endregion
        }
    }
}
