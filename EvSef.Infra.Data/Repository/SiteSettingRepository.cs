using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.SiteSetting;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.SiteSetting;
using EvSef.Infra.Data.Context;
using EvSef.Infra.Data.Migrations;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class SiteSettingRepository : ISiteSettingRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public SiteSettingRepository(EvSefDbContext context)
        {
            _context = context;
        }


        #endregion



        #region SiteSetting
        public async Task<SiteSettingViewModel?> GetSitSettingForEdit()
        {
            var siteSetting= await _context.SiteSettings
                .Select(s => new SiteSettingViewModel()

                {
                    SiteSettingId = s.SiteSettingId,
                    SiteName = s.SiteName,
                    SiteUrl = s.SiteUrl,
                    OurServiceTitle = s.OurServiceTitle,
                    BeChefDescription = s.BeChefDescription,
                    BeChefImage = s.BeChefImage,
                    BeChefTitle = s.BeChefTitle,
                    CorporationFoodDescription = s.CorporationFoodDescription,
                    CorporationFoodTitle = s.CorporationFoodTitle,
                    CorporationFormTitle1 = s.CorporationFormTitle1,
                    CorporationFormTitle2 = s.CorporationFormTitle2,
                    FoodMenuTitle = s.FoodMenuTitle,
                    HowOrderCorporationFoodTitle = s.HowOrderCorporationFoodTitle,
                    JoinChefTitle = s.JoinChefTitle,
                    SiteLogo = s.SiteLogo,
                    OurChefTitle = s.OurChefTitle,
                    ReasonChefTitle = s.ReasonChefTitle,
                    SiteCopyRight = s.SiteCopyRight,
                    SiteCustomerPhone = s.SiteCustomerPhone,
                    SiteEmail = s.SiteEmail,
                    SitePhone = s.SitePhone,
                    SliderPhoto = s.SliderPhoto,
                    SloganTitle = s.SloganTitle,
                    SiteAboutUs = s.SiteAboutUs,
                    InstagramUrl = s.InstagramUrl, 
                    Tax = s.Tax,
                }

                ).FirstOrDefaultAsync();
            return siteSetting;
        }

        public void UpdateSiteSetting(SiteSetting siteSetting)
        {
            _context.SiteSettings.Update(siteSetting);
        }

        public async Task<SiteSetting> GetSiteSettingById(int id)
        {
            return await _context.SiteSettings.SingleOrDefaultAsync(s => s.SiteSettingId == id);
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
