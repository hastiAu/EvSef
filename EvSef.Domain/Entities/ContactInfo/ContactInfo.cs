using EvSef.Domain.Entities.Account;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.ContactInfo
{
    public class ContactInfo
    {
        [Key]
        public int ContactInfoId { get; set; }
        public int LocationId { get; set; }
        public int RelatedId { get; set; }
        public RelatedType RelatedType { get; set; }


        [Display(Name = "ContactInfo Address")]
        [Required(ErrorMessage = "{0} is required")]
        public string ContactInfoAddress { get; set; }

        [Display(Name = "ContactInfo ZipCode")]
        [Required(ErrorMessage = "{0} is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]

        public string ContactInfoZipCode { get; set; }

        [Display(Name = "RegisterDate")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }



        #region Relations
    
 

        #endregion
    }
}