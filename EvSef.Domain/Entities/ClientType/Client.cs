using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Account;

namespace EvSef.Domain.Entities.UserType
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public int RelatedId { get; set; }
        public RelatedType RelatedType { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; set; }

        [Display(Name = "MobileNumber")]
        [Required(ErrorMessage = "{0} is required")]
        public string MobileNumber { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }
 

        [Display(Name = "User State")]
        public UserState UserState{ get; set; }

        public int CreatedUser { get; set; }


        #region Relations
       
        public Order.Order Order { get; set; }
        public ICollection<Wallet.Wallet> Wallets { get; set; }


        #endregion


    }


}

public enum RelatedType
    {
        Person=0,
        Corporation=1,
        Chef=2,
    }

 

