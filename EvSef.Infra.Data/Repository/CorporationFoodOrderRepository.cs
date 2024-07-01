using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.CorporationFoodOrder;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.CorporationFoodOrder;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class CorporationFoodOrderRepository:ICorporationFoodOrderRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public CorporationFoodOrderRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion

        #region FilterCorporationFoodOrderList


        public async Task<FilterCorporationFoodOrderViewModel> CorporationFoodOrderList(FilterCorporationFoodOrderViewModel filterCorporationFoodOrderViewModel)
        {
            var query = _context.CorporationFoodOrders.AsQueryable();

            #region Filter

            switch (filterCorporationFoodOrderViewModel.CorporationFoodOrderState)
            {
                case CorporationFoodOrderState.Active:
                {
                    query = query.Where(q => q.IsActive);
                    break;
                }

                case CorporationFoodOrderState.InActivate:
                {
                    query = query.Where(q => !q.IsActive);
                    break;
                }
                case CorporationFoodOrderState.All:
                {

                    break;
                }

            }

            if (!string.IsNullOrEmpty(filterCorporationFoodOrderViewModel.CorporationFoodOrderTitle))
            {
                query = query.Where(q => q.CorporationFoodOrderTitle.ToLower().Contains(filterCorporationFoodOrderViewModel.CorporationFoodOrderTitle.ToLower()));

            }


            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterCorporationFoodOrderViewModel.PageId, allEntitiesCount);
            var corporationFoodOrder = await query.OrderBy(o => o.IsDelete == false).Pagination(pager).ToListAsync();
            filterCorporationFoodOrderViewModel.SetUsers(corporationFoodOrder);
            return filterCorporationFoodOrderViewModel.SetPaging(pager);
        }

        #endregion

        #region CreateCorporationFoodOrder


        public async Task  CreateCorporationFoodOrderByAdmin(CorporationFoodOrder corporationFoodOrder)
        {
               await _context.CorporationFoodOrders.AddAsync(corporationFoodOrder);
        }

        public async Task<bool> CorporationFoodTitleIsExist(string corporationFoodOrderTitle)
        {
            return  await _context.CorporationFoodOrders.AnyAsync(x=>x.CorporationFoodOrderTitle== corporationFoodOrderTitle);
        }

        #endregion

        #region Corporation Food Order In Site
        public async Task<List<CorporationFoodOrderViewModel>> GetAllHowOrderCorporationFoodForShowInSite()
        {
            return await _context.CorporationFoodOrders
                .Where(c => c.IsActive && !c.IsDelete)
                .Select(c => new CorporationFoodOrderViewModel()
                    {
                        CorporationFoodOrderTitle = c.CorporationFoodOrderTitle,
                        CorporationFoodOrderDescription = c.CorporationFoodOrderDescription,
                        CorporationFoodOrderImage = c.CorporationFoodOrderImage,
                    }

                ).ToListAsync();
        }

        #endregion


        #region DisposeAsync
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }


        #endregion


        #region SaveChanges

   
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
