using SportyApi.Models.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.OrderDto
{
    public class OrderHistoryMinimizedDto
    {
        public Address Address { get; set; }
        public string CreditCardNumber { get; set; }
        public double TotalPrice { get; set; }
        public string Date { get; set; }
        public List<OrderItemDto> ProductsDetails { get; set; }
    }
}
