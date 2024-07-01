using EvSef.Domain.ViewModels.Chef;
using EvSef.Domain.ViewModels.Pagination;
using Google.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.FoodCategory
{
    public class FilterFoodCategoryViewModel : BasePagination
    {
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

        public FoodCategoryState FoodCategoryState { get; set; }

        public List<Entities.Food.FoodCategory> FoodCategories { get; set; }
        public FilterFoodCategoryViewModel SetPaging(BasePagination basePaging)
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

        public FilterFoodCategoryViewModel SetFoodCat(List<Entities.Food.FoodCategory> foodCategories)
        {
            FoodCategories = foodCategories;

            return this;
        }
    }

    public enum FoodCategoryState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }

    public enum FoodCategoryListResult
    {
        NotFound,
        Success
    }
}

