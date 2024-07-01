using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.OurService
{
    public class CreateOurServiceViewModel
    {


        [Display(Name = "Our Service Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string OurServiceTitle { get; set; }

        [Display(Name = "Our Service Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string OurServiceDescription { get; set; }

        [Display(Name = "OurService FontName")]
        public string OurServiceFontName { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }
    }


    public enum CreateOurServiceResult
    {
        Success,
        NotFound,
        OurServiceTitleIsExist
    }
}
