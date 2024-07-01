using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Domain.ViewModels.Restaurant;

namespace EvSef.Domain.ViewModels.SocialMedia
{
    public class FilterSocialMediaListViewModel:BasePagination
    {

        [Display(Name = "Social Media Name")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string SocialMediaName { get; set; }
 

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }

        public SocialMediaState SocialMediaState { get; set; }
        public List<Entities.SocialMedia.SocialMedia> SocialMedia { get; set; }
        public FilterSocialMediaListViewModel SetPaging(BasePagination basePaging)
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

        public FilterSocialMediaListViewModel SetSocialMedia(List<Entities.SocialMedia.SocialMedia> socialMedia)
        {
            SocialMedia = socialMedia;

            return this;
        }

    }

    public enum SocialMediaState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }
}
