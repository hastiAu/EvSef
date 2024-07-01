using EvSef.Domain.ViewModels.Chef;
using EvSef.Domain.ViewModels.Pagination;
using Google.Api;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.OurCustomer
{
    public class FilterOurCustomerViewModel:BasePagination
    {

        [Display(Name = "Our Customer Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string OurCustomerName { get; set; }

        [Display(Name = "Our Customer Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string OurCustomerDescription { get; set; }

        [Display(Name = "Customer Image")]
        public string? CustomerImage { get; set; }

        [Display(Name = "Customer Avatar")]
        public IFormFile CustomerAvatar { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }
        
        public int CreatedUser { get; set; }
        public OurCustomerState OurCustomerState { get; set; }

        public List<Entities.OurCustomer.OurCustomer> OurCustomer { get; set; }
        public FilterOurCustomerViewModel SetPaging(BasePagination basePaging)
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

        public FilterOurCustomerViewModel SetUsers(List<Entities.OurCustomer.OurCustomer> ourCustomers)
        {
            OurCustomer = ourCustomers;

            return this;
        }

    }

    public enum OurCustomerState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }

    public enum OurCustomerResult
    {
        NotFound,
        Success
    }
}
 