using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.FoodCategory
{
    public class FoodCategoryViewModel
    {
        public int FoodCategoryId { get; set; }
        public int? FoodCategoryParentId { get; set; }

        [Display(Name = "Food Category Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FoodCategoryTitle { get; set; }
 
    }

    public enum FoodCategoryResult
    {
        Success,
        NotFound,
        FoodCategoryIsExist
    }
}
