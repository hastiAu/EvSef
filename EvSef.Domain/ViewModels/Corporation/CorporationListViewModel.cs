using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.ViewModels.Pagination;
using Microsoft.AspNetCore.Http;

namespace EvSef.Domain.ViewModels.Corporation
{
    public class CorporationListViewModel : BasePagination
    {

    
        [Display(Name = "Corporation Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string CorporationName { get; set; }


        [Display(Name = "Phone Number")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string Mobile { get; set; }


        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }


        [Display(Name = "User State")]
        public UserState UserState { get; set; }

        public CorporationRequestState CorporationRequestState { get; set; }


        [Display(Name = " CorporationAvatar")]
        public IFormFile CorporationAvatar { get; set; }


        [Display(Name = "Active")]
        public int IsActive { get; set; }

        public FilterCorporationState FilterCorporationState { get; set; }
       
        public int CreatedUser { get; set; }
        public List<Entities.Account.Corporation> Corporation { get; set; }

        public CorporationListViewModel SetPaging(BasePagination basePaging)
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

        public CorporationListViewModel SetUsers(List<Entities.Account.Corporation> corporations)
        {
            Corporation = corporations;

            return this;
        }

    }

    public enum FilterCorporationState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }

    public enum CorporationRequest
    {
        NotFound,
        Success
    }
}