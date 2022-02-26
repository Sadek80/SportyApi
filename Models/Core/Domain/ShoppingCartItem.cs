using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    public class ShoppingCartItem
    {
        [Key]
        public Guid ShoppingCartItemId { get; set; }
        public Guid ShoppingCartId { get; set; }
        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart { get; set; }
        public double TotalItemPrice { get; set; }
        public int Amount { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
