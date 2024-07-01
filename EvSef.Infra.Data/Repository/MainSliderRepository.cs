using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.AboutUs;
using EvSef.Domain.Entities.MainSlider;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.AboutUs;
using EvSef.Domain.ViewModels.JoinUs;
using EvSef.Domain.ViewModels.MainSlider;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class MainSliderRepository : IMainSliderRepository
    {

        #region Constructor

        private readonly EvSefDbContext _context;

        public MainSliderRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion


        #region Create Main Slider

        public async Task CreateMainSlidersByAdmin(MainSlider mainSlider)
        {
            await _context.MainSliders.AddAsync(mainSlider);
        }

        public Task<bool> MainSliderTitleIsExist(string mainSliderTitle)
        {
            return _context.MainSliders.AnyAsync(a => a.SliderTitle == mainSliderTitle);

        }

        #endregion

        #region MainSlider List

        public async Task<FilterMainSliderViewModel> FilterMainSliderList(FilterMainSliderViewModel filterMainSlider)
        {
            var query = _context.MainSliders.AsQueryable();

            #region Filter

            switch (filterMainSlider.MainSliderState)
            {
                case MainSliderState.Active:
                {
                    query = query.Where(q => q.IsActive);
                    break;
                }

                case MainSliderState.InActivate:
                {
                    query = query.Where(q => !q.IsActive);
                    break;
                }
                case MainSliderState.All:
                {

                    break;
                }

            }
 

            if (!string.IsNullOrEmpty(filterMainSlider.SliderTitle))
            {
                query = query.Where(q => q.SliderTitle.ToLower().Contains(filterMainSlider.SliderTitle.ToLower()));

            }

            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterMainSlider.PageId, allEntitiesCount);
            var slider = await query.Where(o => !o.IsDelete)
                .OrderByDescending(o => o.IsActive)
                .ThenBy(o => o.SliderTitle)
                .Pagination(pager)
                .ToListAsync();
            filterMainSlider.SetMainSlider(slider);
            return filterMainSlider.SetPaging(pager);
        }



        #endregion

        #region Main Slider In Site


        public async Task<List<MainSliderViewModel>> GetAllMainSliderForShowInSite()
        {
            var result= await _context.MainSliders
                .Where(l => l.IsActive && !l.IsDelete)
                .Select(l => new MainSliderViewModel()
                    {
                        SliderImage = l.SliderImage,
                        SliderTitle = l.SliderTitle,
                        SliderDescription = l.SliderDescription
                    }

                ).ToListAsync();
            return result;
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
