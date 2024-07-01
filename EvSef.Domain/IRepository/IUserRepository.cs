using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.Entities.ContactInfo;
using EvSef.Domain.Entities.UserType;
using EvSef.Domain.ViewModels.Chef;
using EvSef.Domain.ViewModels.Corporation;
using EvSef.Domain.ViewModels.ManagementPerson;


namespace EvSef.Domain.IRepository
{
    public interface IUserRepository : IAsyncDisposable
    {
        #region Account

        Task RegisterPerson(Person person);
        Task InsertPersonInClient(Client client);
        Task<bool> IsExistsMobileNumber(string mobileNumber);
        Task<bool> IsExistEmail(string email);
        Task<Client> GetUserForLogin(string mobileNumber, string password);
        Task<Client> GetClientByMobile(string mobileNumber);

        #endregion



        #region Person Admin

        Task<FilterPersonViewModel> FilterPerson(FilterPersonViewModel filter);
        Task CreatePersonByAdmin(Person person);
        Task CreateContactInfoByAdmin(ContactInfo contactInfo);


        #endregion


        #region Corporation In Site

        Task CreateCorporationRequest(Corporation corporation);
        Task<bool> IsExistCorporationRequestByMobile(string mobileNumber);
        Task<Corporation> GetCorporationRequestById(int corporationId);
        #endregion


        #region Corporation Admin

        Task<FilterCorporationRequestViewModel> FilterCorporationRequest(FilterCorporationRequestViewModel filter);
        Task<CorporationListViewModel> CorporationList(CorporationListViewModel filterCorporation);
        Task CreateCorporationByAdmin(Corporation corporation);
        void UpdateCorporation(Corporation corporation);
        Task<bool> IsExistsCorporationMobileNumber(string mobileNumber);
        Task<bool> IsExistsClientMobileNumber(string mobileNumber);
        Task<bool> IsExistCorporationEmail(string email);
        Task InsertCorporationInClient(Client client);
        Task<Corporation> GetCorporationById(int corporationId);
        //Task<RegisterCorporationByAdminViewModel?> GetCorporationInfoById(int corporationId);
        Task<Client> GetCorporationClient(int corporationId);
        Task<Client> GetClientByEmail(string email);
        Task<Client> GetClientById(int id);

        #endregion

        

        #region Save

        Task SaveChanges();

        #endregion

    }
}
