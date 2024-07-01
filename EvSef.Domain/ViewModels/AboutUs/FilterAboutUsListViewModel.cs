using EvSef.Domain.Entities.BeComeChef;
using EvSef.Domain.ViewModels.BeComeChef;
using EvSef.Domain.ViewModels.Pagination;
using Google.Api;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.AboutUs
{
    public class FilterAboutUsListViewModel:BasePagination
    {
        [Display(Name = "AboutUs Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string AboutUsTitle { get; set; }

        [Display(Name = "AboutUs Photo 1")]
        [Required(ErrorMessage = "{0} is required")]
        public IFormFile AboutUsPhoto1 { get; set; }

        public AboutUsState AboutUsState { get; set; }
        public List<Entities.AboutUs.AboutUs> AboutUs { get; set; }

        public FilterAboutUsListViewModel SetPaging(BasePagination basePaging)
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

        public FilterAboutUsListViewModel SetAboutUs(List<Entities.AboutUs.AboutUs> aboutUs)
        {
            AboutUs = aboutUs;

            return this;
        }


        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }
    }

    public enum AboutUsState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }
}
