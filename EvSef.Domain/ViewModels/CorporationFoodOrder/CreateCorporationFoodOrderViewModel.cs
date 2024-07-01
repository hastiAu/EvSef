using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EvSef.Domain.ViewModels.CorporationFoodOrder
{
    public class CreateCorporationFoodOrderViewModel
    {


        [Display(Name = "Corporation Food OrderTitle")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string CorporationFoodOrderTitle { get; set; }

        [Display(Name = "Corporation Food Order Description Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string CorporationFoodOrderDescription { get; set; }

        [Display(Name = "Corporation Food Order Image")]
        public IFormFile CorporationFoodOrderAvatar { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }
    }

    public enum CreateCorporationFoodOrderResult
    {
        Success,
        NotFound,
        CorporationFoodOrderIsExist
    }
}
