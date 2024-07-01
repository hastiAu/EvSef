using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.AboutUs;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class AboutUsRepository : IAboutUsRepository
    {


        #region Constructor

        private readonly EvSefDbContext _context;

        public AboutUsRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Create AboutUs


        public async Task CreateAboutUsByAdmin(AboutUs aboutUs)
        {
            await _context.AboutUs.AddAsync(aboutUs);
        }

        public Task<bool> AboutUsTitleIsExist(string aboutUsTitle)
        {
            return _context.AboutUs.AnyAsync(a => a.AboutUsTitle == aboutUsTitle);
        }


        #endregion

        #region AboutUs List

        public async Task<FilterAboutUsListViewModel> FilterAboutUsList(FilterAboutUsListViewModel filterAboutUs)
        {
            var query = _context.AboutUs.AsQueryable();

            #region Filter

            switch (filterAboutUs.AboutUsState)
            {
                case AboutUsState.Active:
                    {
                        query = query.Where(q => q.IsActive);
                        break;
                    }

                case AboutUsState.InActivate:
                    {
                        query = query.Where(q => !q.IsActive);
                        break;
                    }
                case AboutUsState.All:
                    {

                        break;
                    }

            }

            if (!string.IsNullOrEmpty(filterAboutUs.AboutUsTitle))
            {
                query = query.Where(q => q.AboutUsTitle.ToLower().Contains(filterAboutUs.AboutUsTitle.ToLower()));

            }


            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterAboutUs.PageId, allEntitiesCount);
            var aboutUs = await query.Where(o => !o.IsDelete)
                .OrderByDescending(o => o.IsActive)
                .ThenBy(o => o.AboutUsTitle)
                .Pagination(pager)
                .ToListAsync();
            filterAboutUs.SetAboutUs(aboutUs);
            return filterAboutUs.SetPaging(pager);
        }



        #endregion

        #region AboutUs In Site

        public async Task<List<AboutUsViewModel>> GetAllAboutUsInSiteForShowInSite()
        {
            return await _context.AboutUs
                .Where(a => a.IsActive && !a.IsDelete)
                .Select(a => new AboutUsViewModel()
                {
                    AboutUsTitle = a.AboutUsTitle,
                    AboutUsDescription = a.AboutUsDescription,
                    AboutUsImage1 = a.AboutUsImage1,

                    AboutUsImage2 = a.AboutUsImage2,
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
