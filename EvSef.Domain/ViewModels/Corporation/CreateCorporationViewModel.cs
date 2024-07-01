using EvSef.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EvSef.Domain.ViewModels.Corporation
{
    public class CreateCorporationViewModel
    {

        [Display(Name = "First Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FirstName { get; set; }

        [Display(Name = "Sure Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string LastName { get; set; }

        [Display(Name = "Corporation Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string CorporationName { get; set; }

        [Display(Name = "Staff Number")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string StaffNumber { get; set; }



        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }


        [Display(Name = "Phone Number")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string Mobile { get; set; }

        [Display(Name = "Corporation Avatar")]
        public IFormFile CorporationAvatar { get; set; }


        [Display(Name = "Corporation Request State")]
        [Required(ErrorMessage = "{0} is required")]
        public CorporationRequestState CorporationRequestState { get; set; }

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

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }
        public int CreatedUser { get; set; }
    }

    public enum CreateCorporationResult
    {
        Success,
        NotFound,
        MobileNumberIsExists,
        EmailIsExists,
    }
}
 
