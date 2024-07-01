using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Domain.ViewModels.OurCustomer;

namespace EvSef.Domain.ViewModels.CorporationFoodOrder
{
    public class FilterCorporationFoodOrderViewModel:BasePagination
    {

        [Display(Name = "Corporation Food OrderTitle")]
        [MaxLength(100, ErrorMessage = "{0} Length must be less than {1} Character")]
        [Required(ErrorMessage = "{0} is required")]
        public string CorporationFoodOrderTitle { get; set; }
        [Display(Name = "Corporation Food Order Image")]
        public IFormFile CorporationFoodOrderAvatar { get; set; }

        public int CreatedUser { get; set; }

        public CorporationFoodOrderState CorporationFoodOrderState { get; set; }
        public List<Entities.CorporationFoodOrder.CorporationFoodOrder> CorporationFoodOrders { get; set; }
        public FilterCorporationFoodOrderViewModel SetPaging(BasePagination basePaging)
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

        public FilterCorporationFoodOrderViewModel SetUsers(List<Entities.CorporationFoodOrder.CorporationFoodOrder> corporationFoodOrders)
        {
            CorporationFoodOrders = corporationFoodOrders;

            return this;
        }
    }

    public enum  CorporationFoodOrderState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "InActivate")]
        InActivate,
    }

}

