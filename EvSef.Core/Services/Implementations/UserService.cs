using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Core.Services.Interfaces;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.IRepository;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using EvSef.Core.Extensions;
using EvSef.Core.Generator;
using EvSef.Core.Security;
using EvSef.Domain.Entities.ContactInfo;
using EvSef.Domain.Entities.UserType;
using EvSef.Domain.ViewModels.Account;
using EvSef.Domain.ViewModels.ContactInfo;
using EvSef.Domain.ViewModels.Corporation;
using EvSef.Domain.ViewModels.ManagementPerson;
using EvSef.Core.Convertors;
using EvSef.Core.Sender;
using EvSef.Domain.ViewModels.Chef;


namespace EvSef.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        #region Constructor

        private readonly IUserRepository _userRepository;
        private readonly IChefRepository _chefRepository;
        private readonly IViewRenderService _viewRender;

        public UserService(IUserRepository userRepository, IChefRepository chefRepository, IViewRenderService viewRender)
        {
            _userRepository = userRepository;
            _chefRepository = chefRepository;
            _viewRender = viewRender;
        }

        #endregion

        #region Account


        #region Register

        public async Task<RegisterPersonResult> RegisterPerson(RegisterPersonViewModel registerPersonViewModel)
        {

            var mobileExists = await _userRepository.IsExistsMobileNumber(registerPersonViewModel.Mobile);
            if (mobileExists)
            {
                return RegisterPersonResult.PersonExists;
            }

            var existEmail = await _userRepository.IsExistEmail(registerPersonViewModel.Email);

            if (existEmail)
            {
                return RegisterPersonResult.EmailIsExists;
            }

            Person person = new Person()
            {
                FirstName = registerPersonViewModel.FirstName.SanitizeText(),
                LastName = registerPersonViewModel.LastName.SanitizeText(),
                Email = registerPersonViewModel.Email.SanitizeText(),
                Mobile = registerPersonViewModel.Mobile.SanitizeText(),
                Password = PasswordHellper.EncodePasswordMd5(registerPersonViewModel.Password).SanitizeText(),
                UserState = UserState.Active,
                RegisterDate = DateTime.Now,
                

            };

            await _userRepository.RegisterPerson(person);
            await _userRepository.SaveChanges();

            var personId = person.PersonId;

            if (personId == 0)
            {
                return RegisterPersonResult.NotFound;
            }

            Client client = new Client()
            {
                RelatedId = personId,
                RelatedType = RelatedType.Person,
                Email = person.Email,
                MobileNumber = person.Mobile,
                Password = person.Password,
                UserState = person.UserState,
                CreatedUser = personId


            };

            await _userRepository.InsertPersonInClient(client);
            await _userRepository.SaveChanges();

 

            await _userRepository.SaveChanges();

            return RegisterPersonResult.Success;

        }

        #endregion


        #region Login

        public async Task<LoginClientResult> LoginClient(LoginViewModel login)
        {
            string password = PasswordHellper.EncodePasswordMd5(login.Password);

            var client = await _userRepository.GetUserForLogin(login.Mobile, password);

            if (client != null)
            {
                if (client.UserState == UserState.Inactive)
                {
                    return LoginClientResult.NotActive;
                }

                if (client.UserState == UserState.Active)
                {
                    return LoginClientResult.Success;
                }

            }

            return LoginClientResult.UserNotFound;
        }

        public async Task<Client> GetClientByMobile(string mobileNumber)
        {
            return await _userRepository.GetClientByMobile(mobileNumber);
        }


        #endregion

        #endregion


        #region CorporationRequest

        public async Task<CorporationRequestResult> CreateCorporationRequest(
            CorporationRequestViewModel corporationRequestViewModel)
        {
            //var userId = Client.GetCurrentUserId();
            var corporationRequest =
                await _userRepository.IsExistCorporationRequestByMobile(corporationRequestViewModel.Mobile);
            if (corporationRequest == true)
            {
                return CorporationRequestResult.UserHasRequestWithThisNumber;
            }

            {
                Corporation corporation = new Corporation()
                {
                    FirstName = corporationRequestViewModel.FirstName,
                    LastName = corporationRequestViewModel.LastName,
                    Mobile = corporationRequestViewModel.Mobile,
                    Email = corporationRequestViewModel.Email,
                    Password = "12345",
                    CorporationName = corporationRequestViewModel.CorporationName,
                    StaffNumber = corporationRequestViewModel.StaffNumber,
                    CorporationRequestState = CorporationRequestState.UnderProgress,
                    RegisterDate = DateTime.Now,
                    IsDelete = false,
                    UserState = UserState.Inactive,
                    //CreatedUser = userId,
                };


                //var corporationId = corporation.CorporationId;
                //if (corporationId == 0)
                //{
                //    return CorporationRequestResult.Failed;
                //}


                await _userRepository.CreateCorporationRequest(corporation);
                await _userRepository.SaveChanges();
                return CorporationRequestResult.Successfully;
            }


        }

        public async Task<CorporationRequest> SetToIsCalledStatus(int corporationId)
        {
            Corporation corporation = await _userRepository.GetCorporationRequestById(corporationId);

            if (corporation == null)
            {
                return CorporationRequest.NotFound;
            }

            corporation.CorporationRequestState = CorporationRequestState.IsCalled;
            await _userRepository.SaveChanges();

            return CorporationRequest.Success;
        }

        public async Task<CorporationRequest> SetToNotCalledStatus(int corporationId)
        {
            Corporation corporation = await _userRepository.GetCorporationRequestById(corporationId);

            if (corporation == null)
            {
                return CorporationRequest.NotFound;
            }

            corporation.CorporationRequestState = CorporationRequestState.NotCalled;
            await _userRepository.SaveChanges();

            return CorporationRequest.Success;
        }

        #endregion

        #region Admin person

        public async Task<FilterPersonViewModel> FilterPersons(FilterPersonViewModel filter)
        {
            return await _userRepository.FilterPerson(filter);
        }

        public async Task<CreatePersonResult> CreatePersonByAdmin(CreatePersonViewModel createPersonViewModel)
        {
            if (createPersonViewModel.Email != null)
            {
                var existEmail = await _userRepository.IsExistEmail(createPersonViewModel.Email);

                if (existEmail)
                {
                    return CreatePersonResult.EmailIsExists;
                }
            }


            if (await _userRepository.IsExistsMobileNumber(createPersonViewModel.Mobile))
            {
                return CreatePersonResult.MobileNumberIsExists;
            }


            Person person = new Person()
            {
                FirstName = createPersonViewModel.FirstName.SanitizeText(),
                LastName = createPersonViewModel.LastName.SanitizeText(),
                Mobile = createPersonViewModel.Mobile.SanitizeText(),
                Password = PasswordHellper.EncodePasswordMd5(createPersonViewModel.Password).SanitizeText(),
                UserState = UserState.Active,
                RegisterDate = DateTime.Now,
                IsActive = true,
                IsDelete = false,
                Email = createPersonViewModel.Email


            };

            if (createPersonViewModel.Email != null)
            {
                person.Email = createPersonViewModel.Email.SanitizeText();
            }


            //Add Avatar
            if (createPersonViewModel.UserAvatar != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(createPersonViewModel.UserAvatar.FileName);
                createPersonViewModel.UserAvatar.AddImageToServer(imageName, FilePath.FilePath.UserAvatarServer, 100,
                    100, FilePath.FilePath.UserAvatarThumbServer);
                person.Avatar = imageName;
            }

            await _userRepository.CreatePersonByAdmin(person);
            await _userRepository.SaveChanges();

            var personId = person.PersonId;

            Client client = new Client()
            {
                RelatedId = personId,
                RelatedType = RelatedType.Person,
                Email = person.Email.SanitizeText(),
                MobileNumber = person.Mobile,
                Password = person.Password,
                UserState = person.UserState,
                CreatedUser = personId,


            };
            await _userRepository.InsertPersonInClient(client);


            var contactInfo = new ContactInfo()
            {
                ContactInfoAddress = createPersonViewModel.Address.SanitizeText(),
                ContactInfoZipCode = createPersonViewModel.ZipCode.SanitizeText(),
                RegisterDate = DateTime.Now,
                LocationId = (int)(createPersonViewModel.LocationId == 0 ? null : createPersonViewModel.LocationId),
                RelatedType = RelatedType.Person,
                RelatedId = personId,


            };

            await CreateContactInfoByAdmin(contactInfo);

            await _userRepository.SaveChanges();



            //if (createPersonViewModel.UserRoles != null)
            //{
            //    await createPersonViewModel(person.PersonId, createPersonViewModel.UserRoles);
            //    await _userRepository.SaveChanges();
            //}

            return CreatePersonResult.Success;

        }

        public async Task InsertPersonInClient(Client client)
        {
            await _userRepository.InsertPersonInClient(client);
            await _userRepository.SaveChanges();
        }


        public async Task CreateContactInfoByAdmin(ContactInfo contactInfo)
        {
            await _userRepository.CreateContactInfoByAdmin(contactInfo);

            await _userRepository.SaveChanges();

        }

        #endregion

        #region Admin Corporation
        public async Task<FilterCorporationRequestViewModel> FilterCorporationRequest(
            FilterCorporationRequestViewModel filter)
        {
            return await _userRepository.FilterCorporationRequest(filter);
        }

        public async Task<CorporationListViewModel> FilterCorporationList(
            CorporationListViewModel corporationListViewModel)
        {
            return await _userRepository.CorporationList(corporationListViewModel);
        }

        public async Task<CreateCorporationResult> CreateCorporationByAdmin(
            CreateCorporationViewModel createCorporationViewModel)
        {
            if (createCorporationViewModel.Email != null)
            {
                var existEmail = await _userRepository.IsExistCorporationEmail(createCorporationViewModel.Email);
                if (existEmail)
                {
                    return CreateCorporationResult.EmailIsExists;
                }
            }

            if (await _userRepository.IsExistsCorporationMobileNumber(createCorporationViewModel.Mobile))
            {
                return CreateCorporationResult.MobileNumberIsExists;
            }

            Corporation corporation = new Corporation()
            {
                FirstName = createCorporationViewModel.FirstName.SanitizeText(),
                LastName = createCorporationViewModel.LastName.SanitizeText(),
                CorporationName = createCorporationViewModel.CorporationName.SanitizeText(),
                StaffNumber = createCorporationViewModel.StaffNumber,
                Password = PasswordHellper.EncodePasswordMd5(createCorporationViewModel.Password.SanitizeText()),
                Mobile = createCorporationViewModel.Mobile,
                RegisterDate = DateTime.Now,
                IsDelete = false,
                UserState = UserState.Active,
                CorporationRequestState = CorporationRequestState.Confirmed,
                IsActive = true,
            };
            if (createCorporationViewModel.Email != null)
            {
                corporation.Email = createCorporationViewModel.Email;
            }

            if (createCorporationViewModel.CorporationAvatar != null)
            {
                string imageName = NameGenerator.GenerateUniqCode() +
                                   Path.GetExtension(createCorporationViewModel.CorporationAvatar.FileName);
                createCorporationViewModel.CorporationAvatar.AddImageToServer(imageName,
                    FilePath.FilePath.CorporationAvatarServer, 100,
                    100, FilePath.FilePath.CorporationAvatarThumbServer);
                corporation.CorporationAvatar = imageName;
            }


            await _userRepository.CreateCorporationByAdmin(corporation);
            await _userRepository.SaveChanges();

            var corporationId = corporation.CorporationId;

            Client client = new Client()
            {
                RelatedId = corporationId,
                RelatedType = RelatedType.Corporation,
                Email = corporation.Email.SanitizeText(),
                MobileNumber = corporation.Mobile,
                Password = corporation.Password,
                UserState = UserState.Active,
                CreatedUser = corporationId,

            };
            await _userRepository.InsertCorporationInClient(client);

            var corporationContactInfo = new ContactInfo()
            {
                ContactInfoAddress = createCorporationViewModel.Address.SanitizeText(),
                ContactInfoZipCode = createCorporationViewModel.ZipCode.SanitizeText(),
                RegisterDate = DateTime.Now,
                LocationId = (int)(createCorporationViewModel.LocationId == 0
                    ? null
                    : createCorporationViewModel.LocationId),
                RelatedType = RelatedType.Corporation,
                RelatedId = corporationId,
            };

            await CreateContactInfoByAdmin(corporationContactInfo);

            await _userRepository.SaveChanges();
            return CreateCorporationResult.Success;
        }


        public async Task InsertCorporationInClient(Client client)
        {
            await _userRepository.InsertCorporationInClient(client);
            await _userRepository.SaveChanges();
        }



        public async Task<RegisterCorporationResult> RegisterCorporationByAdmin(int corporationId)
        {
            Corporation result = await _userRepository.GetCorporationById(corporationId);
            if (result == null)
            {
                return RegisterCorporationResult.NotFound;
            }


            result.UserState = UserState.Active;

            result.CorporationRequestState = CorporationRequestState.Confirmed;
            result.IsActive = true;
            result.CorporationId = corporationId;

            result.Password = PasswordHellper.EncodePasswordMd5(result.Password.SanitizeText());

            _userRepository.UpdateCorporation(result);
            await _userRepository.SaveChanges();


            var sendPassword = new RegisterCorporationByAdminViewModel()
            {
                Password = result.Password,
                Mobile = result.Mobile
            };

            string body = _viewRender.RenderToStringAsync("CorporationEmail", sendPassword);
            SendEmail.Send(result.Email, "Your Password", body);


            var relatedId = result;

            Client client = new Client()
            {
                RelatedId = relatedId.CorporationId,
                RelatedType = RelatedType.Corporation,
                Email = result.Email,
                MobileNumber = result.Mobile,
                Password = result.Password,
                UserState = UserState.Active,
                CreatedUser = relatedId.CorporationId

            };


            if (await _userRepository.IsExistsClientMobileNumber(result.Mobile))
            {
                return RegisterCorporationResult.IsExistCorporationMobile;
            }
            await _userRepository.InsertCorporationInClient(client);
            await _userRepository.SaveChanges();

            return RegisterCorporationResult.Successful;

        }

        public async Task<Client> GetClientByEmail(string email)
        {
            return await _userRepository.GetClientByEmail(email);
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _userRepository.GetClientById(id);
        }

        #endregion

        #region Admin Chef
        public async Task<CreateNewChefResult> CreateNewChefByAdmin(CreateNewChefByAdminViewModel createNewChefByAdmin)
        {
            {
                if (createNewChefByAdmin.Email != null)
                {
                    var existEmail = await _chefRepository.IsExistChefByEmail(createNewChefByAdmin.Email);
                    if (existEmail)
                    {
                        return CreateNewChefResult.EmailIsExists;
                    }
                }

                if (await _chefRepository.IsExistChefMobileNumber(createNewChefByAdmin.MobileNumber))
                {
                    return CreateNewChefResult.MobileNumberIsExists;
                }

                Chef chef = new Chef()
                {
                    FirstName = createNewChefByAdmin.FirstName.SanitizeText(),
                    LastName = createNewChefByAdmin.LastName.SanitizeText(),
                    Password = PasswordHellper.EncodePasswordMd5(createNewChefByAdmin.Password.SanitizeText()),
                    MobileNumber = createNewChefByAdmin.MobileNumber,
                    MealsNumber = createNewChefByAdmin.MealsNumber.SanitizeText(),
                    RegisterDate = DateTime.Now,
                    IsDelete = false,
                    UserState = UserState.Active,
                    ChefRequestState = ChefRequestState.Confirmed,
                    IsActive = true,
                };
                if (createNewChefByAdmin.Email != null)
                {
                    chef.Email = createNewChefByAdmin.Email;
                }

                if (createNewChefByAdmin.ChefAvatarImage != null)
                {
                    string imageName = NameGenerator.GenerateUniqCode() +
                                       Path.GetExtension(createNewChefByAdmin.ChefAvatarImage.FileName);
                    createNewChefByAdmin.ChefAvatarImage.AddImageToServer(imageName,
                        FilePath.FilePath.ChefAvatarServer, 100,
                        100, FilePath.FilePath.ChefAvatarThumbServer);
                    chef.ChefAvatar = imageName;
                }


                await _chefRepository.CreateChefByAdmin(chef);
                await _userRepository.SaveChanges();

                var chefId = chef.ChefId;

                Client client = new Client()
                {
                    RelatedId = chefId,
                    RelatedType = RelatedType.Chef,
                    Email = chef.Email.SanitizeText(),
                    MobileNumber = chef.MobileNumber,
                    Password = chef.Password,
                    UserState = UserState.Active,
                    CreatedUser = chefId,

                };
                await _chefRepository.InsertChefInClient(client);

                var chefContactInfo = new ContactInfo()
                {
                    ContactInfoAddress = createNewChefByAdmin.Address.SanitizeText(),
                    ContactInfoZipCode = createNewChefByAdmin.ZipCode.SanitizeText(),
                    RegisterDate = DateTime.Now,
                    LocationId = (int)(createNewChefByAdmin.LocationId == 0
                        ? null
                        : createNewChefByAdmin.LocationId),
                    RelatedType = RelatedType.Corporation,
                    RelatedId = chefId,
                };

                await CreateContactInfoByAdmin(chefContactInfo);

                await _userRepository.SaveChanges();
                return CreateNewChefResult.Success;
            }

    

        }
     
        public async Task<FilterChefRequestListViewModel> FilterChefRequestList(
            FilterChefRequestListViewModel filterChefRequestListViewModel)
        {
            return await _chefRepository.FilterChefRequestList(filterChefRequestListViewModel);
        }

        public async Task<FilterChefListViewModel> FilterChefList(FilterChefListViewModel filterChefListViewModel)
        {
            return await _chefRepository.FilterChefList(filterChefListViewModel);
        }

        public async Task<ChefRequestResult> SetToIsCalledChefStatus(int chefId)
        {
            Chef chef = await _chefRepository.GetChefRequestById(chefId);

            if (chef == null)
            {
                return ChefRequestResult.NotFound;
            }

            chef.ChefRequestState = ChefRequestState.IsCalled;
            await _userRepository.SaveChanges();

            return ChefRequestResult.Success;
        }

        public async Task<ChefRequestResult> SetToNotIsCalledChefStatus(int chefId)
        {
            Chef chef = await _chefRepository.GetChefRequestById(chefId);

            if (chef == null)
            {
                return ChefRequestResult.NotFound;
            }

            chef.ChefRequestState = ChefRequestState.NotCalled;
            await _userRepository.SaveChanges();

            return ChefRequestResult.Success;
        }

        public async Task<RegisterChefResult> RegisterChefByAdmin(int chefId)
        {

            Chef result = await _chefRepository.GetChefRequestById(chefId);
            if (result == null)
            {
                return RegisterChefResult.NotFound;
            }


            result.UserState = UserState.Active;

            result.ChefRequestState = ChefRequestState.Confirmed;
            result.IsActive = true;
            result.ChefId = chefId;

            result.Password = PasswordHellper.EncodePasswordMd5(result.Password.SanitizeText());

            _chefRepository.UpdateChef(result);
            await _chefRepository.SaveChanges();


            var sendPassword = new RegisterChefByAdminViewModel()
            {
                Password = result.Password,
                Mobile = result.MobileNumber
            };

            string body = _viewRender.RenderToStringAsync("ChefEmail", sendPassword);
            SendEmail.Send(result.Email, "Your Password", body);


            var relatedId = result;

            Client client = new Client()
            {
                RelatedId = relatedId.ChefId,
                RelatedType = RelatedType.Chef,
                Email = result.Email,
                MobileNumber = result.MobileNumber,
                Password = result.Password,
                UserState = UserState.Active,
                CreatedUser = relatedId.ChefId

            };


            if (await _userRepository.IsExistsClientMobileNumber(result.MobileNumber))
            {
                return RegisterChefResult.IsExistCorporationMobile;
            }
            await _chefRepository.InsertChefInClient(client);
            await _chefRepository.SaveChanges();

            return RegisterChefResult.Successful;
        }
        #endregion

        #region CreateChefRequestInSite


        public async Task<ChefRequestInSiteResult> CreateChefRequestInSite(
            ChefRequestInSitViewModel chefRequestInSitViewModel)
        {
            if (await _chefRepository.IsExistChefMobileNumber(chefRequestInSitViewModel.MobileNumber))
            {
                return ChefRequestInSiteResult.UserHasRequestWithThisNumber;
            }

            if (chefRequestInSitViewModel.Email != null)
            {

                Chef chef = new Chef()
                {
                    FirstName = chefRequestInSitViewModel.FirstName,
                    LastName = chefRequestInSitViewModel.LastName,
                    MobileNumber = chefRequestInSitViewModel.MobileNumber,
                    MealsNumber = chefRequestInSitViewModel.MealsNumber,
                    RegisterDate = DateTime.Now,
                    UserState = UserState.Inactive,
                    ChefRequestState = ChefRequestState.UnderProgress,
                    Email = chefRequestInSitViewModel.Email,
                    Password = "12345"


                };

                await _chefRepository.CreateChefRequestInSite(chef);
                await _chefRepository.SaveChanges();
                return ChefRequestInSiteResult.Successfully;
            }
            return ChefRequestInSiteResult.Failed;
        }



        #endregion

        #region Our chef In Site

        public async Task<List<ChefViewModel>> GetAllChefForShowInSite()
        {
            return await _chefRepository.GetAllChefForShowInSite();
        }

        #endregion
    }

}
 