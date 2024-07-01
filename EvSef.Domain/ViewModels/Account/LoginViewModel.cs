using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Account
{
    public class LoginViewModel
    {

        [Display(Name = "Phone Number")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        //[RegularExpression("[0]{1}[9]{1}[0-9]{9}", ErrorMessage = "mobileIsNotValid")]
        public string Mobile { get; set; }

        [Display(Name = "Password")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
  


    }

    #region LoginUserResult

    public enum LoginClientResult
    {
        Success,
        UserNotFound,
        Error,
        NotActive
    }

    #endregion
}
