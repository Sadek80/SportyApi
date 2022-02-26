using SportyApi.Models.Core.DTOs.Base_Dtos;
using SportyApi.Models.Core.DTOs.UserDtos;
using SportyApi.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Repositories
{
    public interface IAuthRepository
    {
        Task<UserDto> SignUpAsync(UserForSignUpDto userForSignUp);
        Task<UserDto> LogInAsync(UserForLogInDto userForLogIn);
        Task<UserDto> RefreshTokenAsync(string token);
        Task<ForgetPasswordDto> ForgetPasswordAsync(string email);
        Task<UserDto> ResetPasswordAsync(ResetPasswordDto resetPasswordDto, ResetPasswordResourceParameters parameters);
    }
}
