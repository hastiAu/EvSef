using EvSef.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Corporation

{
    public class CorporationRequestViewModel
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
 


        [Display(Name = "Phone Number")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string Mobile { get; set; }


        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }
 

        [Display(Name = "Corporation Request State")]
        [Required(ErrorMessage = "{0} is required")]
        public CorporationRequestState CorporationRequestState { get; set; }

 
        [Display(Name = "Active")]
        public int IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }
        public int CreatedUser { get; set; }
    }

    public enum CorporationRequestResult
    {
        Successfully,
        Failed,
        UserHasRequestWithThisNumber,
    }
}
