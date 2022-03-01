using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.OrderDto
{
    public class OrderItemDto : OrderItemBaseDto
    {
        public string Name { get; set; }
    }
}
