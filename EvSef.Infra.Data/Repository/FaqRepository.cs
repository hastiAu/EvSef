using EvSef.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.IRepository;

namespace EvSef.Infra.Data.Repository
{
    public class FaqRepository:IFaqRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public FaqRepository(EvSefDbContext context)
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

        #region SaveChanges

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}

