using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.OrderDto
{
    public class OrderItemForCreationDto : OrderItemBaseDto
    {
        [Required]
        public override Guid ProductId { get => base.ProductId; set => base.ProductId = value; }
        [Required]
        [Range(1, int.MaxValue)]
        public override int Amount { get => base.Amount; set => base.Amount = value; }
        [Required]
        [Range(1.0, double.MaxValue)]
        public override double TotalItemPrice { get => base.TotalItemPrice; set => base.TotalItemPrice = value; }
    }
}
