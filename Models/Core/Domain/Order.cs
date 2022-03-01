using SportyApi.Models.Core.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }   
        [Required]
        public string UserId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        [Required]
        public Address Address{ get; set; }
        [Required]
        public OrderCreditCard CreditCard{ get; set; }
    }
}
