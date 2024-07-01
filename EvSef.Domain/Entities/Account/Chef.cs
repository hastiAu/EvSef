using EvSef.Domain.Entities.ContactInfo;
using EvSef.Domain.Entities.UserType;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Food;

namespace EvSef.Domain.Entities.Account
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }


        [Display(Name = "Chef First Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FirstName { get; set; }

        [Display(Name = "Chef Last Name ")]
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

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "User State")]
        public UserState UserState { get; set; }

        [Display(Name = " Avatar")]
        public string? ChefAvatar { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        [Display(Name = "Chef Request State")]
        [Required(ErrorMessage = "{0} is required")]
        public ChefRequestState ChefRequestState { get; set; }

        #region Relations
        public ICollection<ChefFood> ChefFood { get; set; }


        #endregion
    }


    public enum ChefRequestState
    {
        [Display(Name = "UnderProgress")]
        UnderProgress
        ,
        [Display(Name = "IsCalled")]
        IsCalled
        ,
        [Display(Name = "NotCalled")]
        NotCalled
        ,
        [Display(Name = "Confirmed")]
        Confirmed,

    }
}