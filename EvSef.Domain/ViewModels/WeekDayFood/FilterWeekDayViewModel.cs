using EvSef.Domain.Entities.Food;
using EvSef.Domain.Entities.Restaurant;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Domain.ViewModels.Restaurant;
using Google.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.WeekDayFood
{
    public class FilterWeekDayViewModel:BasePagination
    {

         public int ChefFoodId { get; set; }
        public int FoodId { get; set; }
        [Display(Name = "WeekDay Name")]
        public WeekDayName? WeekDayName { get; set; }

        public WeekDayState WeekDayState { get; set; }
        public bool IsActive { get; set; }

        [Display(Name = "Food Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FoodTitle { get; set; }
        public  List<Entities.Food.Food>  Food { get; set; }
         public List<WeekdayChefFoodViewModel> WeekDayFood { get; set; }

        public FilterWeekDayViewModel SetPaging(BasePagination basePaging)
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

        public FilterWeekDayViewModel SetWeekDay(List<WeekdayChefFoodViewModel> weekDayFoods)
        {
            WeekDayFood = weekDayFoods;

            return this;
        }
 
    }

    public enum WeekDayState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }
}
