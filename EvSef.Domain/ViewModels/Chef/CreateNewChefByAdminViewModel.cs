using EvSef.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EvSef.Domain.ViewModels.Chef
{
    public class CreateNewChefByAdminViewModel
    {

        [Display(Name = "First Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name ")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string LastName { get; set; }


        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
    
        public string Email { get; set; }

        [Display(Name = "Mobile Number")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string MobileNumber { get; set; }

        [Display(Name = "Password")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }

        [Display(Name = "Meals Number")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string MealsNumber { get; set; }


        [Display(Name = " Avatar")]
        public IFormFile ChefAvatarImage { get; set; }


        [Display(Name = "Address")]
        [Required(ErrorMessage = "{0} is required")]
        public string Address { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "{0} is required")]
        public string State { get; set; }
 
        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "{0} is required")]
        public string ZipCode { get; set; }
        public int? LocationId { get; set; }

    }

    public enum CreateNewChefResult 
    {
        Success,
        NotFound,
        MobileNumberIsExists,
        EmailIsExists
    }
}
