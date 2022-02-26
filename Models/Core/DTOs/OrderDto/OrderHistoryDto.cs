using SportyApi.Models.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.OrderDto
{
    public class OrderHistoryDto
    {
        public Address Address{ get; set; }
        public string CreditCardNumberMinimized { get; set; }
        public double TotalPrice { get; set; }
        public DateTimeOffset Date { get; set; }
        public List<OrderItemDto> ProductsDetails { get; set; }
    }
}
