using EvSef.Domain.ViewModels.FoodCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.Food
{
    public class FoodCategory
    {
        

        [Key]
        public int FoodCategoryId { get; set; }
        public int? FoodCategoryParentId { get; set; }

        [Display(Name = "Food Category Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FoodCategoryTitle { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }

        #region Relations

      
        public ICollection<FoodSelectedCategory> FoodSelectedCategories { get; set; }
     


        #endregion
    }
}
