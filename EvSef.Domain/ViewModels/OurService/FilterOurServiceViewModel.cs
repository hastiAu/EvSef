using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.ViewModels.BeComeChef;
using EvSef.Domain.ViewModels.Pagination;

namespace EvSef.Domain.ViewModels.OurService
{
    public class FilterOurServiceViewModel:BasePagination
    {


        [Display(Name = "Our Service Title")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string OurServiceTitle { get; set; }

        [Display(Name = "Our Service Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string OurServiceDescription { get; set; }

        [Display(Name = "OurService FontName")]
        public string OurServiceFontName { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        public OurServiceState OurServiceState { get; set; }
        public List<Entities.OurService.OurService> OurServices { get; set; }
        public FilterOurServiceViewModel SetPaging(BasePagination basePaging)
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

        public FilterOurServiceViewModel SetUsers(List<Entities.OurService.OurService> ourService)
        {
            OurServices = ourService;

            return this;
        }

    }

    public enum OurServiceState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }
}
