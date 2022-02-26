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
        public string City { get; set; }
        [MaxLength(200)]
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
    }
}
