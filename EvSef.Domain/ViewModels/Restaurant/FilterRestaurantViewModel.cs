using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Restaurant;
using EvSef.Domain.ViewModels.Pagination;

namespace EvSef.Domain.ViewModels.Restaurant
{
    public class FilterRestaurantViewModel:BasePagination
    {

        [Display(Name = "Restaurant Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string RestaurantName { get; set; }

        [Display(Name = "Restaurant Url")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        [Url]
        public string RestaurantUrl { get; set; }


        [Display(Name = "Order")]
        public int Order { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        public RestaurantState RestaurantState { get; set; }
        public List<Entities.Restaurant.Restaurant> Restaurants { get; set; }
        public FilterRestaurantViewModel SetPaging(BasePagination basePaging)
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

        public FilterRestaurantViewModel SetUsers(List<Entities.Restaurant.Restaurant> restaurants)
        {
            Restaurants = restaurants;

            return this;
        }

    }

    public enum RestaurantState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }
}
 