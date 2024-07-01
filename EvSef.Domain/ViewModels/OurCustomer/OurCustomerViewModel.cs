using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.OurCustomer
{
    public class OurCustomerViewModel
    {
        [Display(Name = "Customer Image")]
        public string? CustomerImage { get; set; }
    }
}
