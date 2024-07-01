using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.Entities.UserType;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.Chef;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class ChefRepository: IChefRepository

    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public ChefRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion

        #region DisposeAsync
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }


        #endregion

        #region Chef In Site
        public async Task<bool> IsExistChefByEmail(string chefEmail)
        {
            return await _context.Chefs.AnyAsync(x => x.Email == chefEmail && x.ChefRequestState == ChefRequestState.UnderProgress);
        }
        public async Task<bool> IsExistChefMobileNumber(string chefMobile)
        {
            return await _context.Chefs.AnyAsync(x => x.MobileNumber == chefMobile && x.ChefRequestState == ChefRequestState.UnderProgress);
        }
        public async Task CreateChefRequestInSite(Chef chef)
        {
            await _context.AddAsync(chef);
        }

        #endregion

        #region Chef In Admin

        public async Task CreateNewChefByAdmin(Chef chef)
        {
            await _context.AddAsync(chef);
        }


        public async Task CreateChefByAdmin(Chef chef)
        {
            await _context.AddAsync(chef);
        }


        public async Task InsertChefInClient(Client client)
        {
            await _context.AddAsync(client);
        }

        public async Task<Domain.ViewModels.Chef.FilterChefRequestListViewModel> FilterChefRequestList(FilterChefRequestListViewModel filterChef)
        {

            var query = _context.Chefs.AsQueryable();

            #region Filter

            switch (filterChef.ChefRequestState)
            {

                case ChefRequestState.UnderProgress:
                    query = query.Where(q => q.ChefRequestState == ChefRequestState.UnderProgress);
                    break;

                case ChefRequestState.IsCalled:
                {
                    query = query.Where(q => q.ChefRequestState == ChefRequestState.IsCalled);
                    break;
                }

                case ChefRequestState.NotCalled:
                    query = query.Where(q => q.ChefRequestState == ChefRequestState.NotCalled);
                    break;
            }


            if (!string.IsNullOrEmpty(filterChef.MobileNumber))
            {
                query = query.Where(q => q.MobileNumber.ToLower().Contains(filterChef.MobileNumber.ToLower()));

            }

            if (!string.IsNullOrEmpty(filterChef.FullName))
            {

                query = query.Where(q =>
                    q.FirstName.ToLower().Contains(filterChef.FullName.ToLower()) ||
                    q.LastName.ToLower().Contains(filterChef.FullName.ToLower()));
            }

            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterChef.PageId, allEntitiesCount);
            var chefs = await query.OrderBy(o => o.IsDelete).Pagination(pager).ToListAsync();
            filterChef.SetUsers(chefs);
            return filterChef.SetPaging(pager);
        }



        public async Task<FilterChefListViewModel> FilterChefList(FilterChefListViewModel filterChefListViewModel)
        {
            var query = _context.Chefs.AsQueryable();

            #region Filter

            switch (filterChefListViewModel.ChefRequestState)
            {
                case ChefRequestState.Confirmed:
                {
                    query = query.Where(q => q.ChefRequestState == ChefRequestState.Confirmed  );
                    break;
                }


            }

            if (!string.IsNullOrEmpty(filterChefListViewModel.MobileNumber))
            {
                query = query.Where(q => q.MobileNumber.ToLower().Contains(filterChefListViewModel.MobileNumber.ToLower()));

            }

            if (!string.IsNullOrEmpty(filterChefListViewModel.FullName))
            {

                query = query.Where(q =>
                    q.FirstName.ToLower().Contains(filterChefListViewModel.FullName.ToLower()) ||
                    q.LastName.ToLower().Contains(filterChefListViewModel.FullName.ToLower()));
            }

            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterChefListViewModel.PageId, allEntitiesCount);
            var chefs = await query.OrderBy(o => o.ChefRequestState == ChefRequestState.Confirmed && o.IsDelete == false && o.UserState == UserState.Active).Pagination(pager).ToListAsync();
            filterChefListViewModel.SetUsers(chefs);
            return filterChefListViewModel.SetPaging(pager);
        }


        public async Task<Chef> GetChefRequestById(int chefId)
        {
            return await _context.Chefs.SingleOrDefaultAsync(u => u.ChefId == chefId);
        }
        public void UpdateChef(Chef chef)
        {
            _context.Update(chef);
        }



        #endregion

        #region Chef In Site

        public async Task<List<ChefViewModel>> GetAllChefForShowInSite()
        {
            return await _context.Chefs
                .Where(c => c.IsActive && !c.IsDelete)
                .Select(c => new ChefViewModel()
                    {
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        ChefAvatar = c.ChefAvatar,
                    }

                ).Take(4)
                .ToListAsync();

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
