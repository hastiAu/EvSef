using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.Pagination;
using Google.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Instagram
{
    public class InstagramListViewModel:BasePagination
    {

        [Display(Name = "Instagram Image")]
        [Required(ErrorMessage = "{0} is required")]
        public string InstagramImage { get; set; }


        [Display(Name = "Instagram Url")]
        [Required(ErrorMessage = "{0} is required")]
        public string InstagramUrl { get; set; }

    
        public List<Entities.Instagram.Instagram> Instagram { get; set; }

        public InstagramListViewModel SetPaging(BasePagination basePaging)
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

        public InstagramListViewModel SetInstagram(List<Entities.Instagram.Instagram> instagram)
        {
            Instagram = instagram;

            return this;
        }


        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }
    }

 
}
