using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    public class OrderItem
    {
        [Key, Column(Order = 0)]
        public Guid OrderId { get; set; }
        [Key, Column(Order = 1)]
        public Guid ProductId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Required]
        [Range(1.0, double.MaxValue)]
        public double TotalItemPrice { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }       
    }
}
