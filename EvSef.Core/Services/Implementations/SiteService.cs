using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using EvSef.Core.Extensions;
using EvSef.Core.Generator;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.Entities.AboutUs;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.Entities.BeComeChef;
using EvSef.Domain.Entities.ContactInfo;
using EvSef.Domain.Entities.CustomFood;
using EvSef.Domain.Entities.Instagram;
using EvSef.Domain.Entities.JoinUs;
using EvSef.Domain.Entities.MainSlider;
using EvSef.Domain.Entities.OurCustomer;
using EvSef.Domain.Entities.OurService;
using EvSef.Domain.Entities.Restaurant;
using EvSef.Domain.Entities.SocialMedia;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.BeComeChef;
using EvSef.Domain.ViewModels.Cart;
using EvSef.Domain.ViewModels.Chef;
using EvSef.Domain.ViewModels.CustomFood;
using EvSef.Domain.ViewModels.Food;
using EvSef.Domain.ViewModels.Instagram;
using EvSef.Domain.ViewModels.JoinUs;
using EvSef.Domain.ViewModels.MainSlider;
using EvSef.Domain.ViewModels.OurCustomer;
using EvSef.Domain.ViewModels.OurService;
using EvSef.Domain.ViewModels.Restaurant;
using EvSef.Domain.ViewModels.SiteSetting;
using EvSef.Domain.ViewModels.SocialMedia;
using EvSef.Infra.Data.Repository;
using Google.Protobuf.Reflection;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EvSef.Core.Services.Implementations
{
    public class SiteService : ISiteService
    {
        #region Constructor

        private readonly ISiteRepository _siteRepository;
        private readonly IOurCustomerRepository _ourCustomerRepository;
        private readonly IJoinUsRepository _joinUsRepository;
        private readonly IBeComeChefRepository _beChefRepository;
        private readonly IOurServiceRepository _ourServiceRepository;
        private readonly IRestaurantsRepository _restaurantsRepository;
        private readonly IFaqRepository _iFaqRepository;
        private readonly ISiteSettingRepository _siteSettingRepository;
        private readonly IAboutUsRepository _aboutUsRepository;
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly ICustomFoodRepository _customFoodRepository;
        private readonly IInstagramRepository _instagramRepository;
        private readonly IMainSliderRepository _mainSliderRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public SiteService(ISiteRepository siteRepository, IOurCustomerRepository ourCustomerRepository, IJoinUsRepository joinUsRepository, IBeComeChefRepository beChefRepository, IOurServiceRepository ourServiceRepository, IRestaurantsRepository restaurantsRepository, IFaqRepository iFaqRepository, ISiteSettingRepository siteSettingRepository, IAboutUsRepository aboutUsRepository, ISocialMediaRepository socialMediaRepository, ICustomFoodRepository customFoodRepository, IInstagramRepository instagramRepository, IMainSliderRepository mainSliderRepository, IHttpContextAccessor httpContextAccessor)
        {
            _siteRepository = siteRepository;
            _ourCustomerRepository = ourCustomerRepository;
            _joinUsRepository = joinUsRepository;
            _beChefRepository = beChefRepository;
            _ourServiceRepository = ourServiceRepository;
            _restaurantsRepository = restaurantsRepository;
            _iFaqRepository = iFaqRepository;
            _siteSettingRepository = siteSettingRepository;
            _aboutUsRepository = aboutUsRepository;
            _socialMediaRepository = socialMediaRepository;
            _customFoodRepository = customFoodRepository;
            _instagramRepository = instagramRepository;
            _mainSliderRepository = mainSliderRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region OurCustomer

   
        public async Task<CreateOurCustomerResult> CreateOurCustomerByAdmin(
            CreateOurCustomerViewModel createOurCustomerViewModel)
        {
            if (createOurCustomerViewModel.OurCustomerName != null)
            {
                var existName =
                    await _ourCustomerRepository.IsExistOurCustomerName(createOurCustomerViewModel.OurCustomerName);
                if (existName)
                {
                    return CreateOurCustomerResult.CustomerNameIsExist;
                }

            }

            OurCustomer ourCustomer = new OurCustomer()
            {
                OurCustomerName = createOurCustomerViewModel.OurCustomerName.SanitizeText(),
                OurCustomerDescription = createOurCustomerViewModel.OurCustomerDescription.SanitizeText(),
                IsActive = createOurCustomerViewModel.IsActive,
                IsDelete = false,
                RegisterDate = DateTime.Now,

            };

            if (createOurCustomerViewModel.CustomerAvatar != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(createOurCustomerViewModel.CustomerAvatar.FileName);
                createOurCustomerViewModel.CustomerAvatar.AddImageToServer(imageName,
                    FilePath.FilePath.OurCustomerServer, 80,
                    80, FilePath.FilePath.OurCustomerThumbImage);
                ourCustomer.CustomerImage = imageName;
            }

            await _ourCustomerRepository.CreateOurCustomerByAdmin(ourCustomer);
            await _ourCustomerRepository.SaveChanges();
            return CreateOurCustomerResult.Success;
        }

        public async Task<FilterOurCustomerViewModel> FilterOurCustomerList(
            FilterOurCustomerViewModel filterOurCustomerViewModel)
        {
            return await _ourCustomerRepository.FilterOurCustomerList(filterOurCustomerViewModel);
        }


        #endregion


        #region CustomFood In Site

        public async Task<List<CustomFoodViewModel>> GetAllCustomFoodForShowInSite()
        {
            return await _customFoodRepository.GetAllCustomFoodForShowInSite();
        }


        #endregion

        #region OurCustomer In Site

        public async Task<List<OurCustomerViewModel>> GetAllOurCustomerForShowInSite()
        {
            return await _ourCustomerRepository.GetAllOurCustomerForShowInSite();
        }


        #endregion

        #region JoinUs

        public async Task<CreateJoinUsResult> CreateJoinUsByAdmin(CreateJoinUsViewModel createJoinUsViewModel)
        {
            if (await _joinUsRepository.JoinUsIsExistByTitle(createJoinUsViewModel.JoinUsTitle))
            {
                return CreateJoinUsResult.JoinUsTitleIsExist;
            }

            if (createJoinUsViewModel.JoinUsTitle == null)
            {
                return CreateJoinUsResult.NotFound;
            }

            JoinUs joinUs = new JoinUs()
            {
                JoinUsTitle = createJoinUsViewModel.JoinUsTitle,
                JoinUsDescription = createJoinUsViewModel.JoinUsDescription,
                RegisterDate = DateTime.Now,
                CreatedUser = createJoinUsViewModel.CreatedUser,
                IsActive = createJoinUsViewModel.IsActive,
                IsDelete = false,

            };
            if (createJoinUsViewModel.JoinUsAvatar != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(createJoinUsViewModel.JoinUsAvatar.FileName);
                createJoinUsViewModel.JoinUsAvatar.AddImageToServer(imageName,
                    FilePath.FilePath.JoinUsServer, 80,
                    80, FilePath.FilePath.JoinUsThumbServer);
                joinUs.JoinUsImage = imageName;
            }

            await _joinUsRepository.CreateJoinUsByAdmin(joinUs);

            await _joinUsRepository.SaveChanges();
            return CreateJoinUsResult.Success;
        }

        public async Task<FilterJoinUsViewModel> FilterJoinUsList(FilterJoinUsViewModel filterJoinUsViewModel)
        {
            return await _joinUsRepository.FilterJoinUsList(filterJoinUsViewModel);
        }


        #endregion

        #region JoinUs In Site

        public async Task<List<JoinUsViewModel>> GetAllJoinUsForShowInSite()
        {
            return await _joinUsRepository.GetAllJoinUsForShowInSite();
        }

        #endregion

        #region BeComeChef

        public async Task<CreateBeComeChefResult> CreateBeComeChefByAdmin(
            CreateBeComeChefViewModel createBeComeChefViewModel)
        {
            if (await _beChefRepository.BeComeChefIsExistByTitle(createBeComeChefViewModel.BeComeChefTitle))
            {
                return CreateBeComeChefResult.CreateBeChefTitleIsExist;
            }

            if (createBeComeChefViewModel.BeComeChefTitle == null)
            {
                return CreateBeComeChefResult.NotFound;
            }

            BeComeChef beChef = new BeComeChef()
            {
                BeComeChefTitle = createBeComeChefViewModel.BeComeChefTitle,
                IsActive = createBeComeChefViewModel.IsActive,
                IsDelete = false,
                CreatedUser = createBeComeChefViewModel.CreatedUser


            };

            if (createBeComeChefViewModel.BeComeChefAvatar != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(createBeComeChefViewModel.BeComeChefAvatar.FileName);
                createBeComeChefViewModel.BeComeChefAvatar.AddImageToServer(imageName,
                    FilePath.FilePath.BeComeChefServer, 80,
                    80, FilePath.FilePath.BeComeChefThumbServer);
                beChef.BeComeChefImage = imageName;
            }

            await _beChefRepository.CreateBeComeChefByAdmin(beChef);

            await _beChefRepository.SaveChanges();
            return CreateBeComeChefResult.Success;
        }

        public async Task<FilterBeComeChefViewModel> FilterBeComeChefList(
            FilterBeComeChefViewModel filterBeComeChefViewModel)
        {
            return await _beChefRepository.FilterBeComeChefList(filterBeComeChefViewModel);
        }



        #endregion

        #region BeComeChef(WhyUs) In Site
        public  async Task<List<BeComeChefViewModel>> GetAllBeComeChefForShowInSite()
        {
           return await _beChefRepository.GetAllBeComeChefForShowInSite();
        }

        #endregion


        #region Restaurant


        public async Task<CreateRestaurantResult> CreateRestaurantByAdmin(
            CreateRestaurantViewModel createRestaurantViewModel)
        {
            if (await _restaurantsRepository.RestaurantNameIsExist(createRestaurantViewModel.RestaurantName))
            {
                return CreateRestaurantResult.RestaurantNameIsExist;
            }

            if (createRestaurantViewModel.RestaurantName == null)
            {
                return CreateRestaurantResult.NotFound;
            }

            Restaurant restaurant = new Restaurant()
            {
                RestaurantName = createRestaurantViewModel.RestaurantName,
                RestaurantUrl = createRestaurantViewModel.RestaurantUrl,
                IsActive = createRestaurantViewModel.IsActive,
                IsDelete = false,
                CreatedUser = createRestaurantViewModel.CreatedUser,
                Order = createRestaurantViewModel.Order

            };


            await _restaurantsRepository.CreateRestaurantByAdmin(restaurant);
            await _restaurantsRepository.SaveChanges();
            return CreateRestaurantResult.Success;
        }

        public async Task<FilterRestaurantViewModel> FilterRestaurantList(
            FilterRestaurantViewModel filterRestaurantViewModel)
        {
            return await _restaurantsRepository.FilterRestaurantList(filterRestaurantViewModel);
        }


        #endregion

        #region Restaurant In site

        public async Task<List<RestaurantListViewModel>> GetAllRestaurantsForShowInSite()
        {
            return await _restaurantsRepository.GetAllRestaurantsForShowInSite();
        }

        #endregion


        #region OurService
        public async Task<CreateOurServiceResult> CreateOurServiceByAdmin(
            CreateOurServiceViewModel createOurServiceViewModel)
        {
            if (await _ourServiceRepository.OurServiceTitleIsExist(createOurServiceViewModel.OurServiceTitle))
            {
                return CreateOurServiceResult.OurServiceTitleIsExist;
            }

            if (createOurServiceViewModel.OurServiceTitle == null)
            {
                return CreateOurServiceResult.NotFound;
            }

            OurService ourService = new OurService()
            {
                OurServiceTitle = createOurServiceViewModel.OurServiceTitle,
                OurServiceDescription = createOurServiceViewModel.OurServiceTitle,
                OurServiceFontName = createOurServiceViewModel.OurServiceFontName,
                IsActive = createOurServiceViewModel.IsActive,
                IsDelete = false,
                CreatedUser = createOurServiceViewModel.CreatedUser,
                RegisterDate = DateTime.Now


            };


            await _ourServiceRepository.CreateOurServiceByAdmin(ourService);
            await _ourServiceRepository.SaveChanges();
            return CreateOurServiceResult.Success;
        }


        public async Task<FilterOurServiceViewModel> FilterOurServiceList(
            FilterOurServiceViewModel filterOurServiceViewModel)
        {
            return await _ourServiceRepository.FilterOurServiceList(filterOurServiceViewModel);
        }



        #endregion

        #region OurServiceIn Site

        public async Task<List<OurServiceViewModel>> GetAllOurServiceForShowInSite()
        {
            return await _ourServiceRepository.GetAllOurServiceForShowInSite();
        }

        #endregion

        #region SiteSetting
        public async Task<SiteSettingViewModel?> GetSiteSettingForEdit()
        {
            return await _siteSettingRepository.GetSitSettingForEdit();

        }

        public async Task<SiteSettingEditResult> UpdateSiteSetting(SiteSettingViewModel siteSettingViewModel)
        {
            var siteSetting = await _siteSettingRepository.GetSiteSettingById(siteSettingViewModel.SiteSettingId);
            if (siteSetting == null)
            {
                return SiteSettingEditResult.SiteSettingNotFound;
            }


            siteSetting.SiteName = siteSettingViewModel.SiteName;
            siteSetting.SiteUrl = siteSettingViewModel.SiteUrl;
            siteSetting.SitePhone = siteSettingViewModel.SitePhone;
            siteSetting.SiteCustomerPhone = siteSettingViewModel.SiteCustomerPhone;
            siteSetting.SiteEmail = siteSettingViewModel.SiteEmail;
            siteSetting.SiteCopyRight = siteSettingViewModel.SiteCopyRight;
            siteSetting.SloganTitle = siteSettingViewModel.SloganTitle;
            siteSetting.CorporationFoodTitle = siteSettingViewModel.CorporationFoodTitle;
            siteSetting.CorporationFormTitle1 = siteSettingViewModel.CorporationFormTitle1;
            siteSetting.OurServiceTitle = siteSettingViewModel.OurServiceTitle;
            siteSetting.FoodMenuTitle = siteSettingViewModel.FoodMenuTitle;
            siteSetting.OurChefTitle = siteSettingViewModel.OurChefTitle;
            siteSetting.CorporationFoodTitle = siteSettingViewModel.CorporationFoodTitle;
            siteSetting.CorporationFoodDescription = siteSettingViewModel.CorporationFoodDescription;
            siteSetting.HowOrderCorporationFoodTitle = siteSettingViewModel.HowOrderCorporationFoodTitle;
            siteSetting.BeChefTitle = siteSettingViewModel.BeChefTitle;
            siteSetting.BeChefDescription = siteSettingViewModel.BeChefDescription;
            siteSetting.JoinChefTitle = siteSettingViewModel.JoinChefTitle;
            siteSetting.ReasonChefTitle = siteSettingViewModel.ReasonChefTitle;
            siteSetting.SiteAboutUs = siteSettingViewModel.SiteAboutUs;
            siteSetting.InstagramUrl = siteSettingViewModel.InstagramUrl;
            siteSetting.Tax = siteSettingViewModel.Tax;


            //Logo Image

            if (siteSettingViewModel.LogoFile != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(siteSettingViewModel.LogoFile.FileName);
                siteSettingViewModel.LogoFile.AddImageToServer(imageName, FilePath.FilePath.SiteSettingServer, 100,
                    100, FilePath.FilePath.SiteSettingThumbServer);
                siteSetting.SiteLogo = imageName;

            }


            //Slider Image


            if (siteSettingViewModel.SliderPhotoFile != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(siteSettingViewModel.SliderPhotoFile.FileName);
                siteSettingViewModel.SliderPhotoFile.AddImageToServer(imageName, FilePath.FilePath.SiteSettingServer, 100,
                    100, FilePath.FilePath.SiteSettingThumbServer);
                siteSetting.SliderPhoto = imageName;

            }
            //BeChef Image 


            if (siteSettingViewModel.BeChefImageFile != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(siteSettingViewModel.BeChefImageFile.FileName);
                siteSettingViewModel.BeChefImageFile.AddImageToServer(imageName, FilePath.FilePath.SiteSettingServer, 100,
                    100, FilePath.FilePath.SiteSettingThumbServer);
                siteSetting.BeChefImage = imageName;
            }

            _siteSettingRepository.UpdateSiteSetting(siteSetting);
            await _siteSettingRepository.SaveChanges();
            return SiteSettingEditResult.SiteSettingEdited;

        }

        #endregion

        #region AboutUs

        public async Task<CreateAboutUsResult> CreateAboutUsByAdmin(CreateAboutUsViewModel createAboutUsViewModel)
        {
            var aboutUsTitle = await _aboutUsRepository.AboutUsTitleIsExist(createAboutUsViewModel.AboutUsTitle);
            if (aboutUsTitle)
            {
                return CreateAboutUsResult.AboutUsTitleIsExist;
            }

            if (createAboutUsViewModel == null)
            {
                return CreateAboutUsResult.NotFound;
            }
            AboutUs aboutUs = new AboutUs()
            {

                AboutUsTitle = createAboutUsViewModel.AboutUsTitle,
                AboutUsDescription = createAboutUsViewModel.AboutUsDescription,
                IsActive = createAboutUsViewModel.IsActive,
                IsDelete = false,
                RegisterDate = DateTime.Now,
                CreatedUser = createAboutUsViewModel.CreatedUser,

            };


            if (createAboutUsViewModel.AboutUsPhoto1 != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(createAboutUsViewModel.AboutUsPhoto1.FileName);
                createAboutUsViewModel.AboutUsPhoto1.AddImageToServer(imageName,
                    FilePath.FilePath.AboutUsServer, 80,
                    80, FilePath.FilePath.AboutUsThumbServer);
                aboutUs.AboutUsImage1 = imageName;
            }

            if (createAboutUsViewModel.AboutUsPhoto2 != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(createAboutUsViewModel.AboutUsPhoto2.FileName);
                createAboutUsViewModel.AboutUsPhoto2.AddImageToServer(imageName,
                    FilePath.FilePath.AboutUsServer, 80,
                    80, FilePath.FilePath.AboutUsThumbServer);
                aboutUs.AboutUsImage2 = imageName;
            }

            await _aboutUsRepository.CreateAboutUsByAdmin(aboutUs);
            await _aboutUsRepository.SaveChanges();
            return CreateAboutUsResult.Success;
        }

        public async Task<FilterAboutUsListViewModel> FilterAboutUsList(FilterAboutUsListViewModel filterAboutUs)
        {
            return await _aboutUsRepository.FilterAboutUsList(filterAboutUs);
        }



        #endregion

        #region AboutUs In Site

        public async Task<List<AboutUsViewModel>> GetAllAboutUsInSiteForShowInSite()
        {
            return await _aboutUsRepository.GetAllAboutUsInSiteForShowInSite();
        }
        #endregion

        #region SocialMedia


        public async Task<CreateOurServiceResult> CreateSocialMediaByAdmin(CreateSocialMediaViewModel createSocialMediaViewModel)
        {
            var socialMediaName = await _socialMediaRepository.SocialMediaNameIsExist(createSocialMediaViewModel.SocialMediaName);
            if (socialMediaName)
            {
                return CreateOurServiceResult.OurServiceTitleIsExist;
            }

            if (socialMediaName == null)
            {
                return CreateOurServiceResult.NotFound;
            }

            SocialMedia socialMedia = new SocialMedia()
            {
                SocialMediaName = createSocialMediaViewModel.SocialMediaName,
                SocialMediaUrl = createSocialMediaViewModel.SocialMediaName,
                IsActive = createSocialMediaViewModel.IsActive,
                IsDelete = false,
                RegisterDate = DateTime.Now,
                CreatedUser = createSocialMediaViewModel.CreatedUser,
                SocialMediaIconName = createSocialMediaViewModel.SocialMediaIconName,

            };


            await _socialMediaRepository.CreateSocialMediaByAdmin(socialMedia);
            await _socialMediaRepository.SaveChanges();
            return CreateOurServiceResult.Success;
        }

        public async Task<FilterSocialMediaListViewModel> FilterSocialMediaList(FilterSocialMediaListViewModel filterSocialMediaListViewModel)
        {
            return await _socialMediaRepository.FilterSocialMediaList(filterSocialMediaListViewModel);
        }



        #endregion

        #region Custom food
        public async Task<CreateCustomFoodResult> CreateCustomFoodByAdmin(CreateCustomFoodViewModel createCustomFoodViewModel)
        {

            var customFoodName = await _customFoodRepository.CustomFoodTitleIsExist(createCustomFoodViewModel.CustomFoodTitle);
            if (customFoodName)
            {
                return CreateCustomFoodResult.CustomFoodNameIsExist;
            }

            if (customFoodName == null)
            {
                return CreateCustomFoodResult.NotFound;
            }

            CustomFood customFood = new CustomFood()
            {

                CustomFoodTitle = createCustomFoodViewModel.CustomFoodTitle,
                CustomFoodDescription = createCustomFoodViewModel.CustomFoodDescription,
                IsActive = createCustomFoodViewModel.IsActive,
                RegisterDate = DateTime.Now,
                IsDelete = false,
                CreatedUser = createCustomFoodViewModel.CreatedUser,


            };


            if (createCustomFoodViewModel.CustomFoodPhoto != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(createCustomFoodViewModel.CustomFoodPhoto.FileName);
                createCustomFoodViewModel.CustomFoodPhoto.AddImageToServer(imageName,
                    FilePath.FilePath.CustomFoodServer, 80,
                    80, FilePath.FilePath.CustomFoodThumbServer);
                customFood.CustomFoodImage = imageName;
            }

            await _customFoodRepository.CreateCustomFoodByAdmin(customFood);
            await _customFoodRepository.SaveChanges();
            return CreateCustomFoodResult.Success;
        }

        public async Task<FilterCustomFoodViewModel> FilterCustomFoodList(FilterCustomFoodViewModel filterCustomFoodViewModel)
        {
            return await _customFoodRepository.FilterCustomFoodList(filterCustomFoodViewModel);
        }


        #endregion

        #region Instagram


        public async Task<CreateInstagramResult> CreateInstagramPostByAdmin(CreateInstagramViewModel createInstagramViewModel,int id)
        {

            var instagramPost = await _instagramRepository.InstagramUrlIsExist(createInstagramViewModel.InstagramUrl);
            if (instagramPost)
            {
                return CreateInstagramResult.InstagramUrlIsExist;
            }

            if (instagramPost == null)
            {
                return CreateInstagramResult.NotFound;
            }
           
            Instagram instagram = new Instagram()
            {

                InstagramUrl = createInstagramViewModel.InstagramUrl,
                IsActive = createInstagramViewModel.IsActive,
                RegisterDate = DateTime.Now,
                IsDelete = false,
                CreatedUser = id,


            };


            if (createInstagramViewModel.InstagramPostPhoto != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(createInstagramViewModel.InstagramPostPhoto.FileName);
                createInstagramViewModel.InstagramPostPhoto.AddImageToServer(imageName,
                    FilePath.FilePath.InstagramImageServer, 80,
                    80, FilePath.FilePath.InstagramImageThumbServer);
                instagram.InstagramImage = imageName;
            }

            await _instagramRepository.CreateInstagramByAdmin(instagram);
            await _instagramRepository.SaveChanges();
            return CreateInstagramResult.Success;
        }

        public async Task<InstagramListViewModel> InstagramPostList(InstagramListViewModel instagramListViewModel)
        {
            return await _instagramRepository.InstagramPostList(instagramListViewModel);
        }


        #endregion


        #region Instagram In Site


        public  async Task<List<InstagramViewModel>> GetAllInstagramPostForShowInSite()
        {
            return await _instagramRepository.GetAllInstagramPostForShowInSite();
        }

        #endregion

        #region Main Slider



        public async Task<CreateMainSliderResult> CreateMainSliderByAdmin(CreateMainSliderViewModel createMainSliderViewModel)
        {

            var customFoodName = await _mainSliderRepository.MainSliderTitleIsExist(createMainSliderViewModel.SliderTitle);
            if (customFoodName)
            {
                return CreateMainSliderResult.MainSliderTitleIsExist;
            }

            if (customFoodName == null)
            {
                return CreateMainSliderResult.NotFound;
            }

            MainSlider mainSlider = new MainSlider()
            {

                SliderTitle = createMainSliderViewModel.SliderTitle,
                SliderDescription = createMainSliderViewModel.SliderDescription,
                IsActive = createMainSliderViewModel.IsActive,
                RegisterDate = DateTime.Now,
                IsDelete = false,
                CreatedUser = createMainSliderViewModel.CreatedUser,

            };


            if (createMainSliderViewModel.SliderPhoto != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(createMainSliderViewModel.SliderPhoto.FileName);
                createMainSliderViewModel.SliderPhoto.AddImageToServer(imageName,
                    FilePath.FilePath.MainSliderServer, 80,
                    80, FilePath.FilePath.MainSliderThumbServer);
                mainSlider.SliderImage = imageName;
            }

            await _mainSliderRepository.CreateMainSlidersByAdmin(mainSlider);
            await _mainSliderRepository.SaveChanges();
            return CreateMainSliderResult.Success;
        }

        public async Task<FilterMainSliderViewModel> FilterMainSliderList(FilterMainSliderViewModel filterMainSlider)
        {
            return await _mainSliderRepository.FilterMainSliderList(filterMainSlider);
        }



        #endregion

        #region Main Slider In Site

        public async Task<List<MainSliderViewModel>> GetAllMainSliderForShowInSite()
        {
            return await _mainSliderRepository.GetAllMainSliderForShowInSite();
        }

        #endregion

        #region State & District

        public async Task<List<ContactLocation>> GetStates()
        {
            return await _siteRepository.GetStates();
        }

        public async Task<List<ContactLocation>> GetDistricts(int locationId)
        {
            return await _siteRepository.GetDistricts(locationId);
        }


        #endregion

   
    }
}