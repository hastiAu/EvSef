using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.AboutUs
{
    public class AboutUs
    {
        [Key]
        public int AboutUsId  { get; set; }

        [Display(Name = "AboutUs Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string AboutUsTitle { get; set; }

        [Display(Name = "AboutUs Description")]
        [MaxLength(1000, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string AboutUsDescription { get; set; }

        [Display(Name = "AboutUs Image 1")]
        [Required(ErrorMessage = "{0} is required")]
        public string AboutUsImage1 { get; set; }

        [Display(Name = "AboutUs Image 2")]
        [Required(ErrorMessage = "{0} is required")]
        public string AboutUsImage2 { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }
    }
}
