using EvSef.Domain.IRepository;
using EvSef.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.JoinUs;
using EvSef.Domain.ViewModels.JoinUs;
using EvSef.Domain.ViewModels.Pagination;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class JoinUsRepository: IJoinUsRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public JoinUsRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion

        #region CreateJoinUsByAdmin


        public  async Task CreateJoinUsByAdmin(JoinUs joinUs)
        {
            await _context.JoinUs.AddAsync(joinUs);
        }

        public async Task<bool> JoinUsIsExistByTitle(string joinUsTitle)
        {
            return await _context.JoinUs.AnyAsync(u => u.JoinUsTitle == joinUsTitle);
        }



        #endregion

        #region FilterJoinUsList

        public async Task<FilterJoinUsViewModel> FilterJoinUsList(FilterJoinUsViewModel filterJoinUsViewModel)
        {
            var query = _context.JoinUs.AsQueryable();

            #region Filter

            switch (filterJoinUsViewModel.JoinUsState)
            {
                case JoinUsState.Active:
                {
                    query = query.Where(q => q.IsActive);
                    break;
                }

                case JoinUsState.InActivate:
                {
                    query = query.Where(q => !q.IsActive);
                    break;
                }
                case JoinUsState.All:
                {

                    break;
                }

            }

            if (!string.IsNullOrEmpty(filterJoinUsViewModel.JoinUsTitle))
            {
                query = query.Where(q => q.JoinUsTitle.ToLower().Contains(filterJoinUsViewModel.JoinUsTitle.ToLower()));

            }


            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterJoinUsViewModel.PageId, allEntitiesCount);
            var joinUs = await query.OrderBy(o => o.IsDelete == false).Pagination(pager).ToListAsync();
            filterJoinUsViewModel.SetJoinUs(joinUs);
            return filterJoinUsViewModel.SetPaging(pager);
        }

        #endregion


        #region JoinUs In Site

        public  async Task<List<JoinUsViewModel>> GetAllJoinUsForShowInSite()
        {
            return await _context.JoinUs
                .Where(j => j.IsActive && !j.IsDelete)
                .Select(j => new JoinUsViewModel()
                    {
                      JoinUsDescription = j.JoinUsDescription,
                      JoinUsTitle = j.JoinUsTitle,
                      JoinUsImage = j.JoinUsImage,

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
