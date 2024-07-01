using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.SiteSetting
{
    public class SiteSettingViewModel
    {
        public int SiteSettingId { get; set; }

        [Display(Name = "Site Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string SiteName { get; set; }

        [Display(Name = "Site AboutUs")]
         [Required(ErrorMessage = "{0} is required")]
        public string SiteAboutUs { get; set; }


        [Display(Name = "Site Url")]
        [MaxLength(150, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Url]
        public string SiteUrl { get; set; }

        [Display(Name = "Instagram Url")]
        [MaxLength(150, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Url(ErrorMessage = "Site URL")]
        public string InstagramUrl { get; set; }

        [Display(Name = "Site Phone")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string SitePhone { get; set; }

        [Display(Name = "Site Customer Phone")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string SiteCustomerPhone { get; set; }

        [Display(Name = "Site E-mail")]
        [MaxLength(150, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string SiteEmail { get; set; }

        [Display(Name = "Site CopyRight")]
        [MaxLength(200, ErrorMessage = "{0} Length must be less than {1} Character")]
       
        public string SiteCopyRight { get; set; }

        [Display(Name = "Logo File")]
        public IFormFile LogoFile { get; set; }


        [Display(Name = "Site Logo")]
        [MaxLength(200, ErrorMessage = "{0} Length must be less than {1} Character")]

        public string SiteLogo { get; set; }

        [Display(Name = "Slogan Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string SloganTitle { get; set; }



        [Display(Name = "Corporation FormTitle1")]
        [Required(ErrorMessage = "{0} is required")]
        public string CorporationFormTitle1 { get; set; }

        [Display(Name = "Corporation FormTitle2")]
        [Required(ErrorMessage = "{0} is required")]
        public string CorporationFormTitle2 { get; set; }

        [Display(Name = "SliderPhoto")]
        [Required(ErrorMessage = "{0} is required")]
        public string SliderPhoto { get; set; }

        [Display(Name = "Slider Photo File")]
        public IFormFile SliderPhotoFile { get; set; }


        [Display(Name = "Our Service Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string OurServiceTitle { get; set; }

        [Display(Name = "Food Menu Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string FoodMenuTitle { get; set; }

        [Display(Name = "Our Chef Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string OurChefTitle { get; set; }


        [Display(Name = "Corporation Food Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string CorporationFoodTitle { get; set; }

        [Display(Name = "Corporation Food Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string CorporationFoodDescription { get; set; }

        [Display(Name = "How Order Corporation Food")]
        [Required(ErrorMessage = "{0} is required")]
        public string HowOrderCorporationFoodTitle { get; set; }


        [Display(Name = "BeChef Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string BeChefTitle { get; set; }

        [Display(Name = "BeChef Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string BeChefDescription { get; set; }

        [Display(Name = "BeChef Image")]
        [MaxLength(500, ErrorMessage = "{0} Length must be less than {1} Character")]
        public string BeChefImage { get; set; }

        [Display(Name = "BeChef Image")]
        public IFormFile BeChefImageFile { get; set; }


        [Display(Name = "JoinChef Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string JoinChefTitle { get; set; }

        [Display(Name = "Reason Chef Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string ReasonChefTitle { get; set; }

        [Display(Name = "Tax")]
        [Required(ErrorMessage = "{0} is required")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Tax { get; set; }

    }

    public enum SiteSettingEditResult
    {
        SiteSettingEdited,
        SiteSettingNotFound
    }
}
