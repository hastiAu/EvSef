using EvSef.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Corporation
{
    public class RegisterCorporationByAdminViewModel
    {

        [Display(Name = "Mobile")]

        public string Mobile { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
        public int CorporationId { get; set; }

        [Display(Name = "User State")]
        public UserState UserState { get; set; }
 
        public CorporationRequestState CorporationRequestState { get; set; }
    }

    public enum RegisterCorporationResult
    {
        Successful,
        NotFound,
        IsExistCorporationMobile
    }
}
