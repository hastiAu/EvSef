using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.OurCustomer
{
    public class CreateOurCustomerViewModel
    {

        [Display(Name = "Our Customer Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string OurCustomerName { get; set; }

        [Display(Name = "Our Customer Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string OurCustomerDescription { get; set; }

        [Display(Name = "Customer Avatar")]
        public IFormFile CustomerAvatar { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }
    }


    public enum CreateOurCustomerResult
    {
        Success,
        NotFound,
        CustomerNameIsExist
    }
}
