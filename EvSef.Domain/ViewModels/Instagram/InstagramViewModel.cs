using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Instagram
{
    public class InstagramViewModel
    {

        [Display(Name = "Instagram Image")]
        [Required(ErrorMessage = "{0} is required")]
        public string InstagramImage { get; set; }


    }
}
