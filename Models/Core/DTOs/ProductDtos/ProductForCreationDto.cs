using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.ProductDtos
{
    public class ProductForCreationDto : ProductBaseDto
    {
        [Required]
        public override string Name { get => base.Name; set => base.Name = value; }
        [Required]
        [Range(1.0, double.MaxValue)]
        public override double Price { get => base.Price; set => base.Price = value; }
        [Required]
        public string SportName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string DescriptionMinimized { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }
    }
}
