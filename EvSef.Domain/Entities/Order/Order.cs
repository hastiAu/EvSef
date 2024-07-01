using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.Entities.UserType;
using EvSef.Domain.Entities.Wallet;

namespace EvSef.Domain.Entities.Order
{
    public class Order
    {
        [Key]
        public int OrderId  { get; set; }
        public int ClientId  { get; set; }

        [Display(Name = "Order Number")]
        public int OrderNumber  { get; set; }

        public int ContactInfoId  { get; set; }

        [Display(Name = "Order Total TaxAmount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderTotalTaxAmount  { get; set; }

        [Display(Name = "Total Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalAmount  { get; set; }

        [Display(Name = "Order Type")]
        public OrderType OrderType  { get; set; }

        [Display(Name = "Payment Type")]
        public PaymentType PaymentType { get; set; }

        [Display(Name = "OrderTotal Discount Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderTotalDiscountAmount  { get; set; }

        [Display(Name = "Order Description")]
        public string  OrderDescription  { get; set; }


        [Display(Name = "Delivery Date")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Delivery Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public TimeSpan DeliveryTime { get; set; }

        [Display(Name = "Register Date")]
        public DateTime RegisterDate { get; set; }

        public int CreatedUser { get; set; }


        #region Releation

         public Client Client { get; set; }

        [ForeignKey("ContactInfoId")]
        public ContactInfo.ContactInfo ContactInfo { get; set; }

        public ICollection<OrderDetails.OrderDetails> OrderDetails { get; set; }

        #endregion

    }

    public enum OrderType
    {
        Order,
        PreOrder
    }
}
 
