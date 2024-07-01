using EvSef.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.CustomFood;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.CustomFood;
using EvSef.Domain.Entities.JoinUs;
using EvSef.Domain.ViewModels.Pagination;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class CustomFoodRepository:ICustomFoodRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public CustomFoodRepository(EvSefDbContext context)
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

        #region Create Custom Food

        public async Task CreateCustomFoodByAdmin(CustomFood customFood)
        {
            await _context.CustomFoods.AddAsync(customFood);
        }

        public  async Task<bool> CustomFoodTitleIsExist(string customFoodTitle)
        {
            return await _context.CustomFoods.AnyAsync(u => u.CustomFoodTitle == customFoodTitle);
        }


        #endregion

        #region Filter Custom Food

        public async Task<FilterCustomFoodViewModel> FilterCustomFoodList(FilterCustomFoodViewModel filterCustomFoodViewModel)
        {
            var query = _context.CustomFoods.AsQueryable();

            #region Filter

            switch (filterCustomFoodViewModel.CustomFoodState)
            {
                case CustomFoodState.Active:
                {
                    query = query.Where(q => q.IsActive);
                    break;
                }

                case CustomFoodState.InActivate:
                {
                    query = query.Where(q => !q.IsActive);
                    break;
                }
                case CustomFoodState.All:
                {

                    break;
                }

            }

            if (!string.IsNullOrEmpty(filterCustomFoodViewModel.CustomFoodTitle))
            {
                query = query.Where(q => q.CustomFoodTitle.ToLower().Contains(filterCustomFoodViewModel.CustomFoodTitle.ToLower()));

            }


            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterCustomFoodViewModel.PageId, allEntitiesCount);
            var customFood = await query.OrderBy(o => o.IsDelete == false).Pagination(pager).ToListAsync();
            filterCustomFoodViewModel.SetCustomFood(customFood);
            return filterCustomFoodViewModel.SetPaging(pager);
        }



        #endregion

        #region CustomFood In Site

        public  async Task<List<CustomFoodViewModel>> GetAllCustomFoodForShowInSite()
        {
           return await _context.CustomFoods
                .Where(l => l.IsActive && !l.IsDelete)
                .Select(l => new CustomFoodViewModel()
                    {
                     CustomFoodTitle = l.CustomFoodTitle,
                     CustomFoodDescription = l.CustomFoodDescription,
                     CustomFoodImage = l.CustomFoodImage
                     
                    }

                ).ToListAsync();
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
