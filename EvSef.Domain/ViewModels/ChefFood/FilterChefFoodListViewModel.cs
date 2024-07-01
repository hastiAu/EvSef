using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.FoodPrice;
using EvSef.Domain.ViewModels.BeComeChef;
using EvSef.Domain.ViewModels.Food;
using EvSef.Domain.ViewModels.Pagination;

namespace EvSef.Domain.ViewModels.ChefFood
{
    public class FilterChefFoodListViewModel:BasePagination
    {

        public int ChefId { get; set; }
        
        [Display(Name = "Food Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FoodTitle { get; set; }
 

        public ChefFoodState ChefFoodState { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        public List<FilterChefFoodListViewModel> ChefFoods { get; set; }
        public List<Entities.Food.Food> Foods { get; set; }
        public ICollection<ChefFoodPrice> ChefFoodPrice { get; set; }
        public FilterChefFoodListViewModel SetPaging(BasePagination basePaging)
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

        public FilterChefFoodListViewModel SetChefFood(List<FilterChefFoodListViewModel> chefFoods)
        {
            ChefFoods = chefFoods;

            return this;
        }

    }

    public enum ChefFoodState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }
}
