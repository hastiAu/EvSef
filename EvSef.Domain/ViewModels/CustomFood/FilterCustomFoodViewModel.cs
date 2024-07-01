using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Domain.ViewModels.SocialMedia;

namespace EvSef.Domain.ViewModels.CustomFood
{
    public class FilterCustomFoodViewModel:BasePagination
    {
        [Display(Name = "Custom Food Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string CustomFoodTitle { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }

        public CustomFoodState CustomFoodState { get; set; }
        public List<Entities.CustomFood.CustomFood> CustomFood { get; set; }
        public FilterCustomFoodViewModel SetPaging(BasePagination basePaging)
        {
            PageId = basePaging.PageId;
            TakeEntity = basePaging.TakeEntity;
            SkipEntity = basePaging.SkipEntity;
            AllEntitiesCount = basePaging.AllEntitiesCount;
            AllPageCount = basePaging.AllPageCount;
            StartPage = basePaging.StartPage;
            EndPage = basePaging.EndPage;
            return this;
        }

        public FilterCustomFoodViewModel SetCustomFood(List<Entities.CustomFood.CustomFood> customFood)
        {
            CustomFood = customFood;

            return this;
        }

    }

    public enum CustomFoodState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }
}
