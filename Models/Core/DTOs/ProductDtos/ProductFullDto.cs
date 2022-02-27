using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.ProductDtos
{
    public class ProductFullDto : ProductBaseDto, IValidatableDto
    {
        public Guid ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string SportName { get; set; }
        public bool IsOutOfStock { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
    }
}
