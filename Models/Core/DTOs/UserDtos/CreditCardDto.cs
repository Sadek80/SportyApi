using SportyApi.Models.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.UserDtos
{
    public class CreditCardDto : IHasCreditCard
    {
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
