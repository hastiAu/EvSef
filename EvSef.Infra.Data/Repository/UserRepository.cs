using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.Entities.ContactInfo;
using EvSef.Domain.Entities.UserType;
using EvSef.Domain.IRepository;
using EvSef.Domain.ViewModels.Chef;
using EvSef.Domain.ViewModels.Corporation;
using EvSef.Domain.ViewModels.ManagementPerson;
using EvSef.Domain.ViewModels.Pagination;
using EvSef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EvSef.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public UserRepository(EvSefDbContext context)
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


        #region SiteAccount

        public async Task RegisterPerson(Person person)
        {
            await _context.AddAsync(person);
        }

        public async Task InsertPersonInClient(Client client)
        {
            await _context.AddAsync(client);
        }

        public async Task<bool> IsExistsMobileNumber(string mobileNumber)
        {
            return await _context.Persons.AnyAsync(u => u.Mobile == mobileNumber);

        }

        public async Task<bool> IsExistEmail(string email)
        {
            return await _context.Persons.AnyAsync(u => u.Email == email);
        }

        public async Task<Client> GetUserForLogin(string mobileNumber, string password)
        {
            var re= await _context.Clients.SingleOrDefaultAsync(u => u.MobileNumber == mobileNumber && u.Password == password);
            return re;
        }

        public async Task<Client> GetClientByMobile(string mobileNumber)
        {
            return await _context.Clients.SingleOrDefaultAsync(u => u.MobileNumber == mobileNumber);
        }

        public async Task CreateCorporationRequest(Corporation corporation)
        {
            await _context.AddAsync(corporation);
        }

        public async Task<bool> IsExistCorporationRequestByMobile(string mobileNumber)
        {
            var request = await _context.Corporations.AnyAsync(m => m.Mobile == mobileNumber && m.CorporationRequestState == CorporationRequestState.UnderProgress);
            return request;
        }

        public async Task<Corporation> GetCorporationRequestById(int corporationId)
        {
            return await _context.Corporations.SingleOrDefaultAsync(u => u.CorporationId == corporationId);
        }

        #endregion

        #region Admin


        public async Task<FilterPersonViewModel> FilterPerson(FilterPersonViewModel filter)
        {
            var query = _context.Persons.AsQueryable();

            #region Filter

            switch (filter.FilterUserState)
            {
                case FilterUserState.All:
                    break;

                case FilterUserState.Active:
                    {
                        query = query.Where(q => q.UserState == UserState.Active);
                        break;
                    }

                case FilterUserState.InActivate:
                    query = query.Where(q => q.UserState == UserState.Inactive);
                    break;
            }


            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(q => q.Mobile.ToLower().Contains(filter.Mobile.ToLower()));

            }

            if (!string.IsNullOrEmpty(filter.FullName))
            {
                query = query.Where(q =>
                    q.FirstName.ToLower().Contains(filter.FullName.ToLower()) ||
                    q.LastName.ToLower().Contains(filter.FullName.ToLower()));

            }

            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filter.PageId, allEntitiesCount);
            var persons = await query.Where(o => !o.IsDelete)
                .OrderByDescending(o => o.UserState == UserState.Active)
                .ThenBy(o=>o.FirstName + o.LastName)
                .Pagination(pager).ToListAsync();
            filter.SetUsers(persons);
            return filter.SetPaging(pager);
        }

        public async Task CreatePersonByAdmin(Person person)
        {
            await _context.AddAsync(person);
        }

        public async Task CreateContactInfoByAdmin(ContactInfo contactInfo)
        {
            await _context.AddAsync(contactInfo);
        }


        public async Task<FilterCorporationRequestViewModel> FilterCorporationRequest(FilterCorporationRequestViewModel filter)
        {
            var query = _context.Corporations.AsQueryable();

            #region Filter

            switch (filter.CorporationRequestState)
            {
               
                case CorporationRequestState.UnderProgress:
                    query = query.Where(q => q.CorporationRequestState == CorporationRequestState.UnderProgress);
                    break;

                case CorporationRequestState.IsCalled:
                    {
                        query = query.Where(q => q.CorporationRequestState == CorporationRequestState.IsCalled);
                        break;
                    }

                case CorporationRequestState.NotCalled:
                    query = query.Where(q => q.CorporationRequestState == CorporationRequestState.NotCalled);
                    break;
            }


            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(q => q.Mobile.ToLower().Contains(filter.Mobile.ToLower()));

            }

            if (!string.IsNullOrEmpty(filter.CorporationName))
            {
                query = query.Where(q =>
                    q.FirstName.ToLower().Contains(filter.CorporationName.ToLower()));

            }

            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filter.PageId, allEntitiesCount);
            var corporations = await query.Where(o => !o.IsDelete)
                .OrderByDescending(o=>o.UserState==UserState.Active)
                .ThenBy(o=>o.CorporationName)
                .Pagination(pager).ToListAsync();

            filter.SetUsers(corporations);
            return filter.SetPaging(pager);
        }

     

        public async Task<CorporationListViewModel> CorporationList(CorporationListViewModel filterCorporation)
        {
            var query = _context.Corporations.AsQueryable();

            #region Filter

            switch (filterCorporation.CorporationRequestState)
            {
                case CorporationRequestState.Confirmed:
                    {
                        query = query.Where(q => q.CorporationRequestState == CorporationRequestState.Confirmed);
                        break;
                    }
            }

            if (!string.IsNullOrEmpty(filterCorporation.Mobile))
            {
                query = query.Where(q => q.Mobile.ToLower().Contains(filterCorporation.Mobile.ToLower()));

            }

            if (!string.IsNullOrEmpty(filterCorporation.CorporationName))
            {
                query = query.Where(q =>
                    q.CorporationName.ToLower().Contains(filterCorporation.CorporationName.ToLower()));

            }

            #endregion

            int allEntitiesCount = await query.CountAsync();

            var pager = Pagination.BuildPagination(filterCorporation.PageId, allEntitiesCount);
            var corporations = await query.Where(o => o.CorporationRequestState==CorporationRequestState.Confirmed && o.IsDelete==false&& o.UserState == UserState.Active).Pagination(pager).ToListAsync();
            filterCorporation.SetUsers(corporations);
            return filterCorporation.SetPaging(pager);
        }

        public async Task CreateCorporationByAdmin(Corporation corporation)
        {
            await _context.AddAsync(corporation);
        }

        public  void UpdateCorporation(Corporation corporation)
        {
             _context.Update(corporation);
        }

        public async Task<bool> IsExistsCorporationMobileNumber(string mobileNumber)
        {
            return await _context.Corporations.AnyAsync(u => u.Mobile == mobileNumber);
        }

        public  async Task<bool> IsExistsClientMobileNumber(string mobileNumber)
        {
            return await _context.Clients.AnyAsync(u => u.MobileNumber == mobileNumber);
        }

        public async Task<bool> IsExistCorporationEmail(string email)
        {
            return await _context.Corporations.AnyAsync(u => u.Email == email);
        }

        public async Task InsertCorporationInClient(Client client)
        {
            await _context.AddAsync(client);
        }

        public async Task<Corporation> GetCorporationById(int corporationId)
        {
            return await _context.Corporations.SingleOrDefaultAsync(u => u.CorporationId == corporationId);
        }

 

        public async Task<Client> GetCorporationClient(int corporationId)
        {
            return await _context.Clients.SingleOrDefaultAsync(u => u.ClientId == corporationId);
        }

        public async Task<Client> GetClientByEmail(string email)
        {
            return await _context.Clients.SingleOrDefaultAsync(u => u.Email == email);
        }

        public  async Task<Client> GetClientById(int id)
        {
            return await _context.Clients.SingleOrDefaultAsync(u => u.ClientId == id);
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
