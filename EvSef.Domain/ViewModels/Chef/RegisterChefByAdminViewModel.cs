using EvSef.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Chef
{
    public class RegisterChefByAdminViewModel
    {

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        [Display(Name = "Email")] public string Email { get; set; }

        [Display(Name = "Password")] public string Password { get; set; }
        public int ChefId { get; set; }

        [Display(Name = "User State")] public UserState UserState { get; set; }

        public ChefRequestState ChefRequestState { get; set; }
    }

    public enum RegisterChefResult
    {
        Successful,
        NotFound,
        IsExistCorporationMobile
    }
}