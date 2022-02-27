using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.Base_Dtos
{
    public class ProductBaseDto
    {
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
    }
}
