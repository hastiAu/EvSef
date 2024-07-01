using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.Account
{
    public enum UserState
    {
        [Display(Name = "Active")]
        Active,

        [Display(Name = "InActive")]
        Inactive,
    }
}
