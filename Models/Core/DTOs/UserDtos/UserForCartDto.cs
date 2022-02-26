using SportyApi.Models.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.UserDtos
{
    public class UserForCartDto
    {
        public Address Address{ get; set; }
        public CreditCardDto CreditCard { get; set; }
    }
}
