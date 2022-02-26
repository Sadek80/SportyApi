using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string DescriptionMinimized { get; set; }
        [Range(1.0, double.MaxValue)]
        public double Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [ForeignKey("SportId")]
        public Sport Sport { get; set; }
        public Guid SportId { get; set; }
    }
}
