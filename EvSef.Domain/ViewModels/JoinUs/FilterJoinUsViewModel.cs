using EvSef.Domain.ViewModels.OurCustomer;
using EvSef.Domain.ViewModels.Pagination;
using Google.Api;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.JoinUs
{
    public class FilterJoinUsViewModel:BasePagination
    {
        [Display(Name = "JoinUs Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string JoinUsTitle { get; set; }

        [Display(Name = "JoinUs Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string JoinUsDescription { get; set; }

        [Display(Name = "JoinUs Avatar")]
        public IFormFile JoinUsAvatar { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        public JoinUsState JoinUsState { get; set; }
        public List<Entities.JoinUs.JoinUs> JoinUs { get; set; }
        public FilterJoinUsViewModel SetPaging(BasePagination basePaging)
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

        public FilterJoinUsViewModel SetJoinUs(List<Entities.JoinUs.JoinUs> joinUs)
        {
            JoinUs = joinUs;

            return this;
        }

    }

    public enum JoinUsState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }

}
 
