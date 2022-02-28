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
        public Guid CreditCardId { get; set; }
        [Required]
        [MaxLength(25)]
        public string CreditCardNumber { get; set; }
        [Required]
        [MaxLength(25)]
        [RegularExpression(@"(0[1-9]|10|11|12)/20[0-9]{2}$", 
            ErrorMessage = "Expiration Date should be in MM/YYYY Format Like (04/2022)")]
        public string ExpirationDate { get; set; }
        [Required]
        [MaxLength(15)]
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Zipcode is not valid")]
        public string Zipcode { get; set; }
    }
}
