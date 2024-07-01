using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EvSef.Domain.ViewModels.AboutUs
{
    public class CreateAboutUsViewModel
    {
        [Display(Name = "AboutUs Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string AboutUsTitle { get; set; }

        [Display(Name = "AboutUs Description")]
        [MaxLength(1000, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string AboutUsDescription { get; set; }

        [Display(Name = "AboutUs Photo 1")]
        [Required(ErrorMessage = "{0} is required")]
        public IFormFile AboutUsPhoto1 { get; set; }


        [Display(Name = "Custom Food Image")]
        public string CustomFoodImage { get; set; }

        [Display(Name = "AboutUs Photo 2")]
        [Required(ErrorMessage = "{0} is required")]
        public IFormFile AboutUsPhoto2 { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }
    }

    public enum CreateAboutUsResult
    {
        Success,
        NotFound,
        AboutUsTitleIsExist
    }
}
