using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.ProductDtos
{
    public class ProductDto : ProductBaseDto
    {
        public Guid ProductId { get; set; }
        public string DescriptionMinimized { get; set; }
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public string SportName{ get; set; }
    }   
}
