using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.Instagram
{
    public class Instagram
    {

        public int InstagramId { get; set; }

        [Display(Name = "Instagram Image")]
        [Required(ErrorMessage = "{0} is required")]
        public string InstagramImage { get; set; }


        [Display(Name = "Instagram Url")]
        [Required(ErrorMessage = "{0} is required")]
        [Url(ErrorMessage = "Please fill Correct url")]
        public string InstagramUrl { get; set; }

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
