using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.Food
{
    public class FoodSelectedCategory
    {
        [Key]
        public int FoodSelectedCategoryId { get; set; }

        [Required]
        public int FoodId { get; set; }

        [Required]
        public int FoodCategoryId { get; set; }

        [Display(Name = "Register Date")]
        public DateTime RegisterDate { get; set; }
        public int? CreatedUser { get; set; }


        #region Relations

        [ForeignKey("FoodId")]
        public Food Food { get; set; }

        [ForeignKey("FoodCategoryId")]
        public FoodCategory FoodCategory { get; set; }
        #endregion
    }

}
