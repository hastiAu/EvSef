using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.Food
{
    public  class Food
    {
        [Key]
        public int FoodId { get; set; }

        [Display(Name = "Food Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FoodTitle { get; set; }

        [Display(Name = "Food Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string FoodDescription { get; set; }

        [Display(Name = "Food Image")]
        public string? ImageFood { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }

        public float ChefFoodLimitCount { get; set; }

        #region Relations


        public ICollection<FoodSelectedCategory> FoodSelectedCategories { get; set;}

         public ICollection<ChefFood> ChefFood { get; set; }
    

        #endregion
    }

}
