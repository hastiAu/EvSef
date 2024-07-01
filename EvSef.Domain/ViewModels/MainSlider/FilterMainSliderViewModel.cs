using EvSef.Domain.ViewModels.JoinUs;
using EvSef.Domain.ViewModels.Pagination;
using Google.Api;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.MainSlider
{
    public class FilterMainSliderViewModel:BasePagination
    {
        [Display(Name = "Slider Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string SliderTitle { get; set; }


        [Display(Name = "Slider Image")]
        [MaxLength(200, ErrorMessage = "{0} Length must be less than {1} Character")]

        public string SliderImage { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }

        public MainSliderState MainSliderState { get; set; }
        public List<Entities.MainSlider.MainSlider> MainSlider { get; set; }
        public FilterMainSliderViewModel SetPaging(BasePagination basePaging)
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

        public FilterMainSliderViewModel SetMainSlider(List<Entities.MainSlider.MainSlider> mainSlider)
        {
            MainSlider = mainSlider;

            return this;
        }

    }

    public enum MainSliderState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }

}

