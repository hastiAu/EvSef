using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.Pagination;
using Google.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.CorporationFood
{
    public class FilterCorporationFoodOrder : BasePagination
    {
        public int CorporationId { get; set; }
        public bool IsDelete { get; set; }

        [Display(Name = "Corporation Order From Date")]
        public DateTime CorporationOrderFromDate { get; set; }

        [Display(Name = "Corporation Order To Date")]
        public DateTime CorporationOrderToDate { get; set; }
        //public List<FilterCorporationFoodOrder> CorporationFood { get; set; }
        public List<Entities.Food.CorporationFood> CorporationFoods { get; set; }
        

        public FilterCorporationFoodOrder SetPaging(BasePagination basePaging)
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

        public FilterCorporationFoodOrder SetCorporationFoods(List<Entities.Food.CorporationFood> corporationFoods)
        {
            CorporationFoods = corporationFoods;
            return this;
        }
    }
    }