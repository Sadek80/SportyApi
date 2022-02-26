using Microsoft.EntityFrameworkCore;
using SportyApi.Models.Core.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    [Owned]
    public class OrderPaymentData : IHasCreditCard
    {
        [Required]
        public Address OrderAddress{ get; set; }
        [Required]
        [MaxLength(25)]
        public string CreditCardNumber { get; set; }
        [Required]
        [MaxLength(25)]
        public string ExpirationDate { get; set; }
        [Required]
        [MaxLength(15)]
        public string Zipcode { get; set; }
    }
}
