using EvSef.Domain.Entities.Account;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.ManagementPerson
{
    public class CreatePersonViewModel
    {

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string LastName { get; set; }

        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "{0} is required")]
        [MinLength(6, ErrorMessage = "{0} can not be less than 6")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = " Avatar")]
        public string? Avatar { get; set; }
        public IFormFile UserAvatar { get; set; }

        [Display(Name = " UserState")]
        public UserState UserState { get; set; }
        public bool IsActive { get; set; }

        //[Display(Name = "UserRoles")]
        //public List<long> UserRoles { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "{0} is required")]
        public string Address { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "{0} is required")]
        public string State { get; set; }

        [Display(Name = "District")]
        [Required(ErrorMessage = "{0} is required")]
        public string District { get; set; }
        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "{0} is required")]
        public string ZipCode { get; set; }
        public int? LocationId { get; set; }
    }

    public  enum CreatePersonResult{
        Success,
        NotFound,
        EmailIsExists,
        MobileNumberIsExists,

    }
}
