using EvSef.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.OurCustomer;
using EvSef.Domain.IRepository;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.ViewModels.OurCustomer;
using EvSef.Domain.ViewModels.Pagination;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class OurCustomerRepository: IOurCustomerRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public OurCustomerRepository(EvSefDbContext context)
        {
            _context = context; 
        }

        #endregion

        #region MyRegion

        public async Task CreateOurCustomerByAdmin(OurCustomer ourCustomer)
        {
            await _context.AddAsync(ourCustomer);
        }

        public async Task<bool> IsExistOurCustomerName(string ourCustomerName)
        {
            return await _context.OurCustomers.AnyAsync(x => x.OurCustomerName== ourCustomerName);

        }

   
        public async Task<FilterOurCustomerViewModel> FilterOurCustomerList(FilterOurCustomerViewModel filterOurCustomerViewModel)
        {
            var query = _context.OurCustomers.AsQueryable();

            #region Filter

            switch (filterOurCustomerViewModel.OurCustomerState)
            {
                case OurCustomerState.Active:
                {
                    query = query.Where(q => q.IsActive);
                    break;
                }

                case OurCustomerState.InActivate:
                {
                    query = query.Where(q => !q.IsActive);
                    break;
                }
                case OurCustomerState.All:
                {
                 
                    break;
                }

            }

            if (!string.IsNullOrEmpty(filterOurCustomerViewModel.OurCustomerName))
            {
                query = query.Where(q => q.OurCustomerName.ToLower().Contains(filterOurCustomerViewModel.OurCustomerName.ToLower()));

            }
 

            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterOurCustomerViewModel.PageId, allEntitiesCount);
            var ourCustomer = await query.OrderBy(o =>   o.IsDelete == false ).Pagination(pager).ToListAsync();
            filterOurCustomerViewModel.SetUsers(ourCustomer);
            return filterOurCustomerViewModel.SetPaging(pager);
        }


        #endregion

        #region OurCustomer In Site

        public  async Task<List<OurCustomerViewModel>> GetAllOurCustomerForShowInSite()
        {
            var result = await _context.OurCustomers
                .Where(l => l.IsActive && !l.IsDelete)
                .Select(l => new OurCustomerViewModel()
                    {
                        CustomerImage = l.CustomerImage,
                    }

                ).ToListAsync();
            return result;
        }


        #endregion

        #region SaveChanges


        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion

        #region DisposeAsync
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }


        #endregion

    }
}
