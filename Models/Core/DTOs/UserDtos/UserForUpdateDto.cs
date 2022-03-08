using SportyApi.Models.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.UserDtos
{
    public class UserForUpdateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Address Address{ get; set; }
        public List<CreditCardDto> CreditCard { get; set; }
    }
}
