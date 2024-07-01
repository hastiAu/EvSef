using System.IO;

namespace EvSef.Core.FilePath
{
    public class FilePath
    {
        #region User Avatar
        //we use these two methods for Showing user Avatar
        public static readonly string UserAvatarImage = "/Images/AvatarImage/Origin/";
        public static readonly string UserAvatarThumbImage = "/Images/AvatarImage/Thumb/";

        //we use these two methods for Saving user Avatar
        public static readonly string UserAvatarServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/AvatarImage/Origin/");
        public static readonly string UserAvatarThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/AvatarImage/Thumb/");

        #endregion

        #region Corporation Avatar
        //we use these two methods for Showing Corporation Avatar  
        public static readonly string CorporationAvatarImage = "/Images/CorporationAvatarImage/Origin/";
        public static readonly string CorporationAvatarThumbImage = "/Images/CorporationAvatarImage/Thumb/";

        //we use these two methods for Saving Corporation Avatar  
        public static readonly string CorporationAvatarServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/CorporationAvatarImage/Origin/");
        public static readonly string CorporationAvatarThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CorporationImages/AvatarImage/Thumb/");

        #endregion

        #region Chef Avatar
        //we use these two methods for Showing Corporation Avatar  
        public static readonly string ChefAvatarImage = "/Images/ChefAvatarImage/Origin/";
        public static readonly string ChefAvatarThumbImage = "/Images/ChefAvatarImage/Thumb/";

        //we use these two methods for Saving Corporation Avatar  
        public static readonly string ChefAvatarServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/ChefAvatarImage/Origin/");
        public static readonly string ChefAvatarThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/ChefAvatarImage/Thumb/");

        #endregion

        #region Food Avatar
        //we use these two methods for Showing Food Avatar  
        public static readonly string FoodAvatarImage = "/Images/FoodAvatarImage/Origin/";
        public static readonly string FoodAvatarThumbImage = "/Images/FoodAvatarImage/Thumb/";

        //we use these two methods for Saving Food Avatar  
        public static readonly string FoodAvatarServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/FoodAvatarImage/Origin/");
        public static readonly string FoodAvatarThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/FoodAvatarImage/Thumb/");

        #endregion

        #region Our Corporation Food Order Avatar
        //we use these two methods for Showing Food Avatar  
        public static readonly string CorporationFoodOrderAvatarImage = "/Images/CorporationFoodOrderImage/Origin/";
        public static readonly string CorporationFoodOrderAvatarImageThumbImage = "/Images/CorporationFoodOrderImage/Thumb/";

        //we use these two methods for Saving Food Avatar  
        public static readonly string CorporationFoodOrderServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/CorporationFoodOrderImage/Origin/");
        public static readonly string CorporationFoodOrderThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/CorporationFoodOrderImage/Thumb/");

        #endregion

        #region Our Customer Avatar
        //we use these two methods for Showing Food Avatar  
        public static readonly string OurCustomerAvatarImage = "/Images/OurCustomerImage/Origin/";
        public static readonly string OurCustomerThumbImage = "/Images/OurCustomerImage/Thumb/";

        //we use these two methods for Saving Food Avatar  
        public static readonly string OurCustomerServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/OurCustomerImage/Origin/");
        public static readonly string OurCustomerThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/OurCustomerAvatarImage/Thumb/");

        #endregion

        #region Our JoinUs Avatar
        //we use these two methods for Showing Food Avatar  
        public static readonly string JoinUsAvatarImage = "/Images/JoinUsImage/Origin/";
        public static readonly string JoinUsThumbImage = "/Images/JoinUsImage/Thumb/";

        //we use these two methods for Saving Food Avatar  
        public static readonly string JoinUsServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/JoinUsImage/Origin/");
        public static readonly string JoinUsThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/JoinUsImage/Thumb/");

        #endregion

        #region Our BeComeChef Avatar
        //we use these two methods for Showing Food Avatar  
        public static readonly string BeComeChefAvatarImage = "/Images/BeComeChefImage/Origin/";
        public static readonly string BeComeChefThumbImage = "/Images/BeComeChefImage/Thumb/";

        //we use these two methods for Saving Food Avatar  
        public static readonly string BeComeChefServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/BeComeChefImage/Origin/");
        public static readonly string BeComeChefThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/BeComeChefImage/Thumb/");

        #endregion

        #region SiteSetting

        //we use these two methods for Showing SiteSetting Avatar  
        public static readonly string SiteSettingImage = "/Images/SiteSettingImage/Origin/";
        public static readonly string SiteSettingThumbImage = "/Images/SiteSettingImage/Thumb/";

        //we use these two methods for Saving SiteSetting Avatar  
        public static readonly string SiteSettingServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/SiteSettingImage/Origin/");
        public static readonly string SiteSettingThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/SiteSettingImage/Thumb/");

        #endregion

        #region About Us

        //we use these two methods for Showing SiteSetting Avatar  
        public static readonly string AboutUsImage = "/Images/AboutUsImage/Origin/";
        public static readonly string AboutUsThumbImage = "/Images/AboutUsImage/Thumb/";

        //we use these two methods for Saving SiteSetting Avatar  
        public static readonly string AboutUsServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/AboutUsImage/Origin/");
        public static readonly string AboutUsThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/AboutUsImage/Thumb/");

        #endregion

        #region Custom Food

        //we use these two methods for Showing SiteSetting Avatar  
        public static readonly string CustomFoodImage = "/Images/CustomFoodImage/Origin/";
        public static readonly string CustomFoodThumbImage = "/Images/CustomFoodImage/Thumb/";

        //we use these two methods for Saving SiteSetting Avatar  
        public static readonly string CustomFoodServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/CustomFoodImage/Origin/");
        public static readonly string CustomFoodThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/CustomFoodImage/Thumb/");

        #endregion

        #region Instagram

        //we use these two methods for Showing SiteSetting Avatar  
        public static readonly string InstagramImage = "/Images/InstagramImage/Origin/";
        public static readonly string InstagramThumbImage = "/Images/InstagramImage/Thumb/";

        //we use these two methods for Saving SiteSetting Avatar  
        public static readonly string InstagramImageServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/InstagramImage/Origin/");
        public static readonly string InstagramImageThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/InstagramImage/Thumb/");

        #endregion

        #region Main Slider

        //we use these two methods for Showing SiteSetting Avatar  
        public static readonly string MainSliderImage = "/Images/MainSliderImage/Origin/";
        public static readonly string MainSliderThumbImage = "/Images/MainSliderImage/Thumb/";

        //we use these two methods for Saving SiteSetting Avatar  
        public static readonly string MainSliderServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/MainSliderImage/Origin/");
        public static readonly string MainSliderThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/MainSliderImage/Thumb/");

        #endregion
    }
}


 