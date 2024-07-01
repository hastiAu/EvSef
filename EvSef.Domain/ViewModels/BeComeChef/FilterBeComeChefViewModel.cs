using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.ViewModels.JoinUs;
using EvSef.Domain.ViewModels.Pagination;
using Microsoft.AspNetCore.Http;

namespace EvSef.Domain.ViewModels.BeComeChef
{
    public class FilterBeComeChefViewModel:BasePagination
    {
        [Display(Name = "BeCome Chef Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string BeComeChefTitle { get; set; }


        [Display(Name = "BeCome Chef Avatar")]
        public IFormFile BeComeChefAvatar { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }


        public BeComeChefState BeComeChefState { get; set; }
        public List<Entities.BeComeChef.BeComeChef> BeComeChefs { get; set; }
        public FilterBeComeChefViewModel SetPaging(BasePagination basePaging)
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

        public FilterBeComeChefViewModel SetUsers(List<Entities.BeComeChef.BeComeChef> beComeChefs)
        {
            BeComeChefs = beComeChefs;

            return this;
        }

    }

    public enum BeComeChefState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }
}
 