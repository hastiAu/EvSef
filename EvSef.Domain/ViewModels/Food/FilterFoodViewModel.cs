using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Domain.ViewModels.Chef;

namespace EvSef.Domain.ViewModels.Food
{
    public class FilterFoodViewModel:BasePagination
    {
 

        [Display(Name = "Food Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FoodTitle { get; set; }

        [Display(Name = "Food Avatar")]
        public IFormFile FoodAvatar { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public int CreatedUser { get; set; }

        [Display(Name = "SelectedFoodCategory")]
        public List<int> SelectedFoodCategory { get; set; }
        public List<Entities.Food.Food> Foods { get; set; }
        public List<Entities.Food.FoodCategory> FoodCategories { get; set; }
 
        public FilterFoodState FilterFoodState { get; set; }
        public FilterFoodViewModel SetPaging(BasePagination basePaging)
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

        public FilterFoodViewModel SetUsers(List<Entities.Food.Food> foods)
        {
            Foods = foods;

            return this;
        }
    }

    public enum FilterFoodState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }
}
