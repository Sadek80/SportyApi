using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.Base_Dtos
{
    public class UserBaseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public string? RefreshToken { get; set; }
    }
}
