using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    [Owned]
    public class Address
    {
        [MaxLength(50)]
        [Required]
        public string City { get; set; }
        [MaxLength(250)]
        [Required]
        public string Street { get; set; }
        [Required]
        public int BuildingNumber { get; set; }
    }
}
