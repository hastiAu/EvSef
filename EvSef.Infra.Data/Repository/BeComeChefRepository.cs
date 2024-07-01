using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.BeComeChef;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.BeComeChef;
using EvSef.Domain.ViewModels.JoinUs;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class BeComeChefRepository:IBeComeChefRepository 
    {


        #region Constructor

        private readonly EvSefDbContext _context;

        public BeComeChefRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion

        #region CreateBeComeChefByAdmin


        public async Task CreateBeComeChefByAdmin(BeComeChef beComeChef)
        {
            await _context.BeComeChefs.AddAsync(beComeChef);
        }

        public async Task<bool> BeComeChefIsExistByTitle(string beComeChefTitle)
        {
            return await _context.BeComeChefs.AnyAsync(u => u.BeComeChefTitle == beComeChefTitle);
        }



        #endregion

        #region BeComeChefList

        public  async Task<FilterBeComeChefViewModel> FilterBeComeChefList(FilterBeComeChefViewModel filterBeComeChefViewModel)
        {

            var query = _context.BeComeChefs.AsQueryable();

            #region Filter
            
            switch (filterBeComeChefViewModel.BeComeChefState)
            {
                case BeComeChefState.Active:
                {
                    query = query.Where(q => q.IsActive);
                    break;
                }

                case BeComeChefState.InActivate:
                {
                    query = query.Where(q => !q.IsActive);
                    break;
                }
                case BeComeChefState.All:
                {

                    break;
                }

            }

            if (!string.IsNullOrEmpty(filterBeComeChefViewModel.BeComeChefTitle))
            {
                query = query.Where(q => q.BeComeChefTitle.ToLower().Contains(filterBeComeChefViewModel.BeComeChefTitle.ToLower()));

            }


            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterBeComeChefViewModel.PageId, allEntitiesCount);
            var beComeChef = await query.OrderBy(o => o.IsDelete == false).Pagination(pager).ToListAsync();
            filterBeComeChefViewModel.SetUsers(beComeChef);
            return filterBeComeChefViewModel.SetPaging(pager);
        }



        #endregion

        #region BeComeChef(WhyUs) In Site

        public  async Task<List<BeComeChefViewModel>> GetAllBeComeChefForShowInSite()
        {
            return await _context.BeComeChefs
                .Where(c => c.IsActive && !c.IsDelete)
                .Select(c => new BeComeChefViewModel()
                    {
                        BeComeChefImage = c.BeComeChefImage,
                        BeComeChefTitle = c.BeComeChefTitle
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
