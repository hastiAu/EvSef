using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.OurCustomer;
using EvSef.Domain.Entities.OurService;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.OurCustomer;
using EvSef.Domain.ViewModels.OurService;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EvSef.Infra.Data.Repository
{
    public class OurServiceRepository:IOurServiceRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public OurServiceRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion

        #region OurServiceList

        public async Task<FilterOurServiceViewModel> FilterOurServiceList(FilterOurServiceViewModel filterOurServiceViewModel)
        {
            var query = _context.OurServices.AsQueryable();

            #region Filter

            switch (filterOurServiceViewModel.OurServiceState)
            {
                case OurServiceState.Active:
                {
                    query = query.Where(q => q.IsActive);
                    break;
                }

                case OurServiceState.InActivate:
                {
                    query = query.Where(q => !q.IsActive);
                    break;
                }
                case OurServiceState.All:
                {

                    break;
                }

            }

            if (!string.IsNullOrEmpty(filterOurServiceViewModel.OurServiceTitle))
            {
                query = query.Where(q => q.OurServiceTitle.ToLower().Contains(filterOurServiceViewModel.OurServiceTitle.ToLower()));

            }


            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterOurServiceViewModel.PageId, allEntitiesCount);
            var ourService = await query.OrderBy(o => o.IsDelete == false).Pagination(pager).ToListAsync();
            filterOurServiceViewModel.SetUsers(ourService);
            return filterOurServiceViewModel.SetPaging(pager);
        }

   
        #endregion

        #region CreateOurSevice

        public async Task CreateOurServiceByAdmin(OurService ourService)
        {
            await _context.AddAsync(ourService);
        }

        public async Task<bool> OurServiceTitleIsExist(string ourServiceTitle)
        {
            return await _context.OurServices.AnyAsync(x => x.OurServiceTitle == ourServiceTitle);

        }



        #endregion

        #region OurService In Site

        public async Task<List<OurServiceViewModel>> GetAllOurServiceForShowInSite()
        {
            return await _context.OurServices
                .Where(o => o.IsActive && !o.IsDelete)
                .Select(o => new OurServiceViewModel()
                    {
                      OurServiceTitle = o.OurServiceTitle,
                      OurServiceDescription = o.OurServiceDescription,
                      OurServiceFontName = o.OurServiceFontName
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
