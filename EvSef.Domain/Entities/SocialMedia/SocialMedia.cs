using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.SocialMedia
{
    public class SocialMedia
    {
        [Key]
        public int SocialMediaId { get; set; }

        [Display(Name = "Social Media Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string SocialMediaName { get; set; }

        [Display(Name = "Social Media Name")]
        [Required(ErrorMessage = "{0} is required")]
        [Url(ErrorMessage = "Please fill Correct url")]
        public string SocialMediaUrl { get; set; }


        [Display(Name = "Social Media Icon Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string SocialMediaIconName { get; set; }

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
