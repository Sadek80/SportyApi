using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.OrderDto
{
    public class OrderForCreationDto
    {
        public Address Address{ get; set; }
        public CreditCardDto CreditCard { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public List<OrderItemForCreationDto> Products { get; set; }
    }
}
