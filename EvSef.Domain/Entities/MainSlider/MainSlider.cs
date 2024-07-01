using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.MainSlider
{
    public class MainSlider
    {
        [Key]
        public int MaidSliderId  { get; set; }

        [Display(Name = "Slider Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string SliderTitle { get; set; }

        [Display(Name = "Slider Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string SliderDescription { get; set; }


        [Display(Name = "Slider Image")]
        [MaxLength(200, ErrorMessage = "{0} Length must be less than {1} Character")]

        public string SliderImage { get; set; }

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
