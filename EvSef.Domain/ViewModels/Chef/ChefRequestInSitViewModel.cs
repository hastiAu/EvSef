using EvSef.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Chef
{
    public class ChefRequestInSitViewModel
    {


        [Display(Name = "ChefFirstName")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FirstName { get; set; }

        [Display(Name = "ChefLastName ")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string LastName { get; set; }
 

        [Display(Name = "Mobile Number")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string MobileNumber { get; set; }

        [Display(Name = "Email")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
         public string Email { get; set; }


        [Display(Name = "Meals Number")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string MealsNumber { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "User State")]
        public UserState UserState { get; set; }
 

        [Display(Name = "Chef Request State")]
        [Required(ErrorMessage = "{0} is required")]
        public ChefRequestState ChefRequestState { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "{0} is required")]
        public string State { get; set; }

        [Display(Name = "District")]
        [Required(ErrorMessage = "{0} is required")]
        public string District { get; set; }
        public int? LocationId { get; set; }
    }

    public enum ChefRequestInSiteResult
    {
        Successfully,
        Failed,
        UserHasRequestWithThisNumber,
    }
}
