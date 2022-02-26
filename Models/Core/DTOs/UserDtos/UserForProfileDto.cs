using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.UserDtos
{
    public class UserForProfileDto : IValidatableDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address{ get; set; }
        public List<CreditCardDto> CreditCards { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
    }
}
