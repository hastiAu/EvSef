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

namespace EvSef.Domain.Entities.Account
{
    public class Corporation
    {
        [Key]
        public int CorporationId { get; set; }
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

        [Display(Name = "Password")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }


        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }


        [Display(Name = "User State")]
        public UserState UserState { get; set; }

        [Display(Name = "Corporation Request State")]
        [Required(ErrorMessage = "{0} is required")]
        public CorporationRequestState CorporationRequestState { get; set;}

        [Display(Name = " Avatar")]
        public string? CorporationAvatar { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }
        public int CreatedUser { get; set; }



        #region Relation
 

        #endregion
    }


    public enum CorporationRequestState
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