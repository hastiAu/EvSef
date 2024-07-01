using EvSef.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.ContactInfo;
using EvSef.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class SiteRepository : ISiteRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public SiteRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion

        #region State & District

     
        public async Task<List<ContactLocation>> GetStates()
        {
            var state = await _context.ContactLocations.Where(l => l.ParentId == null)
                .Select(l => new ContactLocation()
                {
                    StateName = l.StateName,
                    LocationId = l.LocationId,
                }
                ).ToListAsync();
            return state;
        }

        public async Task<List<ContactLocation>> GetDistricts(int locationId)
        {
            var district = await _context.ContactLocations.Where(d => d.ParentId == locationId)
                .Select(d => new ContactLocation()
                {
                    StateName = d.StateName,
                    LocationId = d.LocationId,
                }
                ).ToListAsync();
            return district;
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
