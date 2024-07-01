using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.AboutUs;
using EvSef.Domain.Entities.Instagram;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.Instagram;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class InstagramRepository:IInstagramRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public InstagramRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Create Instgram Post

        public async Task CreateInstagramByAdmin(Instagram instagram)
        {
            await _context.Instagram.AddAsync(instagram);
        }

        public  Task<bool> InstagramUrlIsExist(string instagramUrl)
        {
            return _context.Instagram.AnyAsync(a => a.InstagramUrl == instagramUrl);
        }

        #endregion


        #region Instagram List


        public  async Task<InstagramListViewModel> InstagramPostList(InstagramListViewModel instagramListViewModel)
        {
            var query = _context.Instagram.AsQueryable();

  

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(instagramListViewModel.PageId, allEntitiesCount);
            var instagramPost = await query.Where(o => !o.IsDelete)
                .OrderByDescending(o => o.IsActive)
                .ThenBy(o => o.InstagramUrl)
                .Pagination(pager)
                .ToListAsync();
            instagramListViewModel.SetInstagram(instagramPost);
            return instagramListViewModel.SetPaging(pager);
        }



        #endregion

        #region MyRegion

        public async Task<List<InstagramViewModel>> GetAllInstagramPostForShowInSite()
        {
            var re=  await _context.Instagram
                .Where(i => i.IsActive && !i.IsDelete)
                .Select(i => new InstagramViewModel()
                    {
                        InstagramImage = i.InstagramImage,
                    }

                ).ToListAsync();
            return re;
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
