using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.ContactInfo
{
    public class ContactLocation
    {
        [Key]
        public  int LocationId { get; set; }
        public int?  ParentId { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string StateName { get; set; }
    


        #region Relations


        [ForeignKey(" ParentId")]
        public ContactLocation Parent { get; set; }
 
        #endregion
    }
}
