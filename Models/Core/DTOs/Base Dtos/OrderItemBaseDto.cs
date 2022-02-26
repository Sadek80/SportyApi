using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.Base_Dtos
{
    public class OrderItemBaseDto
    {
        public virtual Guid ProductId { get; set; }
        public virtual int Amount { get; set; }
        public virtual double TotalItemPrice { get; set; }
    }
}
