using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.UserDtos
{
    public class ForgetPasswordDto : IValidatableDto
    {
        public string ResetToken { get; set; }
        public string TrancatedResetToken { get; set; }
        public string ResetPasswordUrl { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
    }
}
