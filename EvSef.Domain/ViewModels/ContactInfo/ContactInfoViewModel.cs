using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.ContactInfo
{
    public class ContactInfoViewModel
    {
        public int LocationId { get; set; }
        public int RelatedId { get; set; }
        public RelatedType RelatedType { get; set; }


        [Display(Name = "ContactInfo Address")]
        [Required(ErrorMessage = "{0} is required")]
        public string ContactInfoAddress { get; set; }

        [Display(Name = "ContactInfo ZipCode")]
        [Required(ErrorMessage = "{0} is required")]
        public string ContactInfoZipCode { get; set; }
    }

    public enum ContactInfoType
    {
        Success,
        NotFound,
         
      
    }
}
