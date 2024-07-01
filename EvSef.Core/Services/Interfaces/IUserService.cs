using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.Entities.ContactInfo;
using EvSef.Domain.Entities.UserType;
using EvSef.Domain.ViewModels.Account;
using EvSef.Domain.ViewModels.Chef;
using EvSef.Domain.ViewModels.ContactInfo;
using EvSef.Domain.ViewModels.Corporation;
using EvSef.Domain.ViewModels.ManagementPerson;
 
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EvSef.Core.Services.Interfaces
{
    public interface IUserService
    {

        #region Account

        Task<RegisterPersonResult> RegisterPerson(RegisterPersonViewModel registerPersonViewModel);
        Task InsertPersonInClient(Client client);
        Task<LoginClientResult> LoginClient(LoginViewModel login);
        Task<Client> GetClientByMobile(string mobileNumber);
        #endregion

        #region Corporation In Site

        Task<CorporationRequestResult> CreateCorporationRequest (CorporationRequestViewModel corporationRequestViewModel);

        Task<CorporationRequest> SetToIsCalledStatus(int corporationId);
        Task<CorporationRequest> SetToNotCalledStatus(int corporationId);

        #endregion

        #region  Person Admin

        Task<FilterPersonViewModel> FilterPersons(FilterPersonViewModel filter);
        Task<CreatePersonResult> CreatePersonByAdmin(CreatePersonViewModel createPersonViewModel);
        Task CreateContactInfoByAdmin(ContactInfo contactInfo);

        #endregion

        #region  Corporation Admin
        Task<FilterCorporationRequestViewModel> FilterCorporationRequest(FilterCorporationRequestViewModel filter);
        Task<CorporationListViewModel> FilterCorporationList(CorporationListViewModel filterCorporationList);
        Task<CreateCorporationResult>CreateCorporationByAdmin(CreateCorporationViewModel createCorporationViewModel);
        Task InsertCorporationInClient(Client client);
        Task<RegisterCorporationResult> RegisterCorporationByAdmin(int corporationId);
        Task<Client> GetClientByEmail(string email);
        Task<Client> GetClientById(int id);

        #endregion

        #region Chef Admin

        Task<CreateNewChefResult> CreateNewChefByAdmin(CreateNewChefByAdminViewModel createNewChefByAdmin);
        Task<FilterChefRequestListViewModel> FilterChefRequestList(FilterChefRequestListViewModel  filterChefRequestListViewModel);
        Task<FilterChefListViewModel>FilterChefList(FilterChefListViewModel filterChefListViewModel);
        Task<ChefRequestResult> SetToIsCalledChefStatus(int chefId);
        Task<ChefRequestResult> SetToNotIsCalledChefStatus(int chefId);
        Task<RegisterChefResult> RegisterChefByAdmin(int chefId);

        #endregion

        #region Chef Request In Site

        Task<ChefRequestInSiteResult> CreateChefRequestInSite(ChefRequestInSitViewModel chefRequestInSitViewModel);

        #endregion

        #region Chef In Site

        Task<List<ChefViewModel>> GetAllChefForShowInSite();

        #endregion
    }
}
