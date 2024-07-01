using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.ViewModels.Pagination;
using Microsoft.AspNetCore.Http;

namespace EvSef.Domain.ViewModels.ManagementPerson
{
    public class FilterPersonViewModel : BasePagination
    {

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string FullName { get; set; }

        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "{0} is required")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = " Avatar")]
        [Required(ErrorMessage = "{0} is required")]
        public string? Avatar { get; set; }
        public IFormFile UserAvatar { get; set; }

       
        public UserState UserState { get; set; }

        [Display(Name = "User Filter")]
        public FilterUserState FilterUserState { get; set; }
        public List<Entities.Account.Person> Persons { get; set; }

        public FilterPersonViewModel SetPaging(BasePagination basePaging)
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

        public FilterPersonViewModel SetUsers(List<Entities.Account.Person> persons)
        {
            Persons = persons;

            return this;
        }






    }

    public enum FilterUserState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }
}
