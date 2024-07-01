using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EvSef.Domain.ViewModels.Instagram
{
    public class CreateInstagramViewModel
    {
       

        [Display(Name = "Instagram Post Photo")]
        [Required(ErrorMessage = "{0} is required")]
        public IFormFile InstagramPostPhoto { get; set; }


        [Display(Name = "Instagram Url")]
        [Required(ErrorMessage = "{0} is required")]
        public string InstagramUrl { get; set; }


        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public int CreatedUser { get; set; }
    }

    public enum CreateInstagramResult
    {
        Success,
        NotFound,
        InstagramUrlIsExist
    }
}
