using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.OrderDto
{
    public class OrderHistoryDto : IValidatableDto
    {
        public Address Address { get; set; }
        public string CreditCardNumber { get; set; }
        public double TotalPrice { get; set; }
        public string Date { get; set; }
        public List<OrderItemDto> ProductsDetails { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
    }
}
