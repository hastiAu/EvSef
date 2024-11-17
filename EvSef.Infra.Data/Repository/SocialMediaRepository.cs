using EvSef.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.AboutUs;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.SocialMedia;
using Microsoft.EntityFrameworkCore;
using EvSef.Domain.Entities.SocialMedia;
using EvSef.Domain.ViewModels.Pagination;
 

namespace EvSef.Infra.Data.Repository
{
    public class SocialMediaRepository : ISocialMediaRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public SocialMediaRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion


        #region  Create Social Media

        public async Task CreateSocialMediaByAdmin(SocialMedia socialMedia)
        {
            await _context.SocialMedia.AddAsync(socialMedia);
        }

        public  Task<bool> SocialMediaNameIsExist(string socialMediaName)
        {

            return _context.SocialMedia.AnyAsync(a => a.SocialMediaName == socialMediaName);
        }


        #endregion

        #region  SocialMedia List


        public  async Task<FilterSocialMediaListViewModel> FilterSocialMediaList(FilterSocialMediaListViewModel filterSocialMediaListViewModel)
        {

            var query = _context.SocialMedia.AsQueryable();

            #region Filter

            switch (filterSocialMediaListViewModel.SocialMediaState)
            {
                case SocialMediaState.Active:
                {
                    query = query.Where(q => q.IsActive);
                    break;
                }

                case SocialMediaState.InActivate:
                {
                    query = query.Where(q => !q.IsActive);
                    break;
                }
                case SocialMediaState.All:
                {

                    break;
                }

            }

            if (!string.IsNullOrEmpty(filterSocialMediaListViewModel.SocialMediaName))
            {
                query = query.Where(q => q.SocialMediaName.ToLower().Contains(filterSocialMediaListViewModel.SocialMediaName.ToLower()));

            }


            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterSocialMediaListViewModel.PageId, allEntitiesCount);
            var socialMedia = await query.Where(o => !o.IsDelete)
                .OrderByDescending(o => o.IsActive)
                .ThenBy(o => o.SocialMediaName)
                .Pagination(pager)
                .ToListAsync();
            filterSocialMediaListViewModel.SetSocialMedia(socialMedia);
            return filterSocialMediaListViewModel.SetPaging(pager);
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
