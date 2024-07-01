using EvSef.Domain.Entities.ContactInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.BeComeChef;
using EvSef.Domain.ViewModels.CustomFood;
using EvSef.Domain.ViewModels.Instagram;
using EvSef.Domain.ViewModels.JoinUs;
using EvSef.Domain.ViewModels.MainSlider;
using EvSef.Domain.ViewModels.OurCustomer;
using EvSef.Domain.ViewModels.OurService;
using EvSef.Domain.ViewModels.Restaurant;
using EvSef.Domain.ViewModels.SiteSetting;
using EvSef.Domain.ViewModels.SocialMedia;
using EvSef.Domain.ViewModels.Cart;

namespace EvSef.Core.Services.Interfaces
{
    public interface ISiteService
    {

        #region State & District

        Task<List<ContactLocation>> GetStates();
        Task<List<ContactLocation>> GetDistricts(int locationId);


        #endregion

        #region Our Customer

        Task<CreateOurCustomerResult> CreateOurCustomerByAdmin(CreateOurCustomerViewModel createOurCustomerViewModel);
        Task<FilterOurCustomerViewModel> FilterOurCustomerList(FilterOurCustomerViewModel filterOurCustomerViewModel);

        #endregion

        #region OurCustomer In Site

        Task<List<OurCustomerViewModel>> GetAllOurCustomerForShowInSite();

        #endregion

        #region JoinUs

        Task<CreateJoinUsResult> CreateJoinUsByAdmin(CreateJoinUsViewModel createJoinUsViewModel);
        Task<FilterJoinUsViewModel> FilterJoinUsList(FilterJoinUsViewModel filterJoinUsViewModel);

        #endregion

        #region JoinUs In Site

        Task<List<JoinUsViewModel>> GetAllJoinUsForShowInSite();

        #endregion

        #region BeCome Chef

        Task<CreateBeComeChefResult> CreateBeComeChefByAdmin(CreateBeComeChefViewModel createBeComeChefViewModel);
        Task<FilterBeComeChefViewModel> FilterBeComeChefList(FilterBeComeChefViewModel filterBeComeChefViewModel);

        #endregion

        #region BeComeChef(WhyUs) In Site
        Task<List<BeComeChefViewModel>> GetAllBeComeChefForShowInSite();

        #endregion

        #region Restaurant

        Task<CreateRestaurantResult> CreateRestaurantByAdmin(CreateRestaurantViewModel createRestaurantViewModel);
        Task<FilterRestaurantViewModel> FilterRestaurantList(FilterRestaurantViewModel filterRestaurantViewModel);

        #endregion

        #region Restaurant In site

        Task<List<RestaurantListViewModel>> GetAllRestaurantsForShowInSite();

        #endregion

        #region OurService

        Task<CreateOurServiceResult> CreateOurServiceByAdmin(CreateOurServiceViewModel createOurServiceViewModel);
        Task<FilterOurServiceViewModel> FilterOurServiceList(FilterOurServiceViewModel filterOurServiceViewModel);

        #endregion

        #region OurService In Site
        Task<List<OurServiceViewModel>> GetAllOurServiceForShowInSite();

        #endregion

        #region SiteSetting

        Task<SiteSettingViewModel?> GetSiteSettingForEdit();
        Task<SiteSettingEditResult> UpdateSiteSetting(SiteSettingViewModel siteSettingViewModel);

        #endregion

        #region AboutUs

        Task<CreateAboutUsResult> CreateAboutUsByAdmin(CreateAboutUsViewModel createAboutUsViewModel);
        Task<FilterAboutUsListViewModel> FilterAboutUsList(FilterAboutUsListViewModel filterAboutUs);

        #endregion

        #region AboutUs In Site

        Task<List<AboutUsViewModel>> GetAllAboutUsInSiteForShowInSite();

        #endregion

        #region Social Media

        Task<CreateOurServiceResult> CreateSocialMediaByAdmin(CreateSocialMediaViewModel createSocialMediaViewModel);

        Task<FilterSocialMediaListViewModel> FilterSocialMediaList(
            FilterSocialMediaListViewModel filterSocialMediaListViewModel);

        #endregion

        #region CustomFood

        Task<CreateCustomFoodResult> CreateCustomFoodByAdmin(CreateCustomFoodViewModel createCustomFoodViewModel);
        Task<FilterCustomFoodViewModel> FilterCustomFoodList(FilterCustomFoodViewModel filterCustomFoodViewModel);

        #endregion

        #region CustomFood In Site

        Task<List<CustomFoodViewModel>> GetAllCustomFoodForShowInSite();

        #endregion

        #region Instagram

        Task<CreateInstagramResult> CreateInstagramPostByAdmin(CreateInstagramViewModel createInstagramViewModel, int id);
        Task<InstagramListViewModel> InstagramPostList(InstagramListViewModel instagramListViewModel);

        #endregion

        #region Instagram In Site


        Task<List<InstagramViewModel>> GetAllInstagramPostForShowInSite();
        #endregion

        #region Main Slider

        Task<CreateMainSliderResult> CreateMainSliderByAdmin(CreateMainSliderViewModel createMainSliderViewModel);
        Task<FilterMainSliderViewModel> FilterMainSliderList(FilterMainSliderViewModel filterMainSlider);

        #endregion

        #region Main Slider In Site
        Task<List<MainSliderViewModel>> GetAllMainSliderForShowInSite();

        #endregion




    }
}
