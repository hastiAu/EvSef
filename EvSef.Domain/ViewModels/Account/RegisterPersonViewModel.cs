using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Account
{
    public class RegisterPersonViewModel
    {
      
 
        [Display(Name = "First Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FirstName { get; set; }  

        [Display(Name = "Sure Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string LastName { get; set; }  


        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; set; }  

        [Display(Name = "Phone Number")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression("[0]{1}[9]{1}[0-9]{9}", ErrorMessage = "Please Enter Valid Mobile Number")]

        public string Mobile { get; set; }  

        [Display(Name = "Password")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }

       

    }

    public enum RegisterPersonResult
    {
        Success,
        PersonExists,
        NotFound,
        EmailIsExists
    }
}
