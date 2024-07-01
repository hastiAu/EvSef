using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EvSef.Domain.ViewModels.BeComeChef
{
    public class CreateBeComeChefViewModel
    {
        [Display(Name = "BeCome Chef Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string BeComeChefTitle { get; set; }


        [Display(Name = "BeCome Chef Avatar")]
        public IFormFile BeComeChefAvatar { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }
    }

    public enum CreateBeComeChefResult
    {
        Success,
        NotFound,
        CreateBeChefTitleIsExist
    }
}
