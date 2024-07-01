using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.ContactInfo
{
    public class ContactLocationViewModel
    {

        public int LocationId { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string StateName { get; set; }
    }
}
