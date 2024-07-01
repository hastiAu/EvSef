using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.UserType;

namespace EvSef.Domain.Entities.Wallet
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }
        public int ClientId { get; set; }

        [Display(Name = "TransactionType")]
        [Required]
        public TransactionType TransactionType { get; set; }

        [Display(Name = "Amount")]
        [Required]
        public int Amount { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Paid")]
        public bool Paid { get; set; }

        [Display(Name = "PaymentDate")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Payment Type")]
        [Required]
        public PaymentType PaymentType { get; set; }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; }



        #region Relations

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        #endregion
    }



    public enum TransactionType
    {
        Deposit, Withdraw
    }

    public enum PaymentType
    {
        [Display(Name = "Cash")]
        Cash,

        [Display(Name = "Deposit To Card")]
        DepositToCard
    }



}
