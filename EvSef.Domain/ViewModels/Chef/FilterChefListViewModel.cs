using EvSef.Domain.Entities.Account;
using EvSef.Domain.ViewModels.Corporation;
using EvSef.Domain.ViewModels.Pagination;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Chef
{
    public class FilterChefListViewModel: BasePagination
    {
        
        public int ChefId { get; set; }
        public int ChefFoodId { get; set; }

        [Display(Name = "Full Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string FullName { get; set; }

        

        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        public string Email { get; set; }

        [Display(Name = "Mobile Number")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string MobileNumber { get; set; }


        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }


        [Display(Name = "User State")]
        public UserState UserState { get; set; }

        [Display(Name = " Avatar")]
        public IFormFile ChefAvatarImage { get; set; }

        [Display(Name = "Chef Request State")]
        [Required(ErrorMessage = "{0} is required")]
        public ChefRequestState ChefRequestState { get; set; }

        public List<Entities.Account.Chef> Chef { get; set; }
        public FilterChefListViewModel SetPaging(BasePagination basePaging)
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

        public FilterChefListViewModel SetUsers(List<Entities.Account.Chef> chefs)
        {
            Chef = chefs;

            return this;
        }

    }

    public enum FilterChefState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }

    public enum ChefRequestResult
    {
        NotFound,
        Success
    }
}
