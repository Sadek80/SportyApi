using AutoMapper;
using SportyApi.Helpers;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.Base_Dtos;
using SportyApi.Models.Core.DTOs.UserDtos;
using SportyApi.Models.Core.Repositories;
using SportyApi.ResourceParameters;
using SportyApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SportyApi.Models.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly JWT _jwt;

        public AuthRepository(UserManager<ApplicationUser> userManager, 
                                    IOptions<JWT> jwtOptions, IMailService mailService, 
                                    IMapper mapper)
        {
            _userManager = userManager;
            _mailService = mailService;
            _mapper = mapper;
            _jwt = jwtOptions.Value;
        }

        public async Task<UserDto> SignUpAsync(UserForSignUpDto userForSignUp)
        {
            if (await _userManager.FindByEmailAsync(userForSignUp.Email) is not null)
                return new UserDto { Message = "User is already registered", StatusCode = StatusCodes.Status409Conflict};

            var user = _mapper.Map<ApplicationUser>(userForSignUp);
            user.Id = Guid.NewGuid().ToString();
            user.UserName = userForSignUp.Email;

            var refreshToken = GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            var result = await _userManager.CreateAsync(user, userForSignUp.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description}";
                }

                return new UserDto { Message = errors, StatusCode = StatusCodes.Status422UnprocessableEntity };
            }

            await _userManager.AddToRoleAsync(user, "User");

            var jwtSecurityToken = await CreateJwtToken(user);

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Success = true;
            userDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            userDto.RefreshToken = refreshToken.Token;
            userDto.RefreshTokenExpiration = refreshToken.ExpiresOn;

            return userDto;
        }

        public async Task<UserDto> LogInAsync(UserForLogInDto userForLogIn)
        {
            var userDto = new UserDto();

            var user = await _userManager.FindByEmailAsync(userForLogIn.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, userForLogIn.Password))
            {
                userDto.Message = "Email or Password is Incorrect";
                userDto.StatusCode = StatusCodes.Status400BadRequest;
                return userDto;
            }

            var jwtSecurityToken = await CreateJwtToken(user);

            userDto = _mapper.Map<UserDto>(user);

            userDto.Success = true;
            userDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            var refreshToken = user.RefreshToken;
            
            if (refreshToken != null && refreshToken.IsActive)
            {
                userDto.RefreshToken = refreshToken.Token;
                userDto.RefreshTokenExpiration = refreshToken.ExpiresOn;
            }
            else
            {
                refreshToken = GenerateRefreshToken();

                userDto.RefreshToken = refreshToken.Token;
                userDto.RefreshTokenExpiration = refreshToken.ExpiresOn;

                user.RefreshToken = refreshToken;
                await _userManager.UpdateAsync(user);
            }

            return userDto;
        }

        public async Task<UserDto> RefreshTokenAsync(string token)
        {
            var userDto = new UserDto();

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshToken.Token == token);

            if(user == null)
            {
                userDto.Success = false;
                userDto.Message = "Invalid Token";
                userDto.StatusCode = StatusCodes.Status404NotFound;
                return userDto;
            }

            var refreshToken = user.RefreshToken;


            if (!refreshToken.IsActive)
            {
                userDto.Success = false;
                userDto.Message = "Invalid Token";
                userDto.StatusCode = StatusCodes.Status403Forbidden;
                return userDto;
            }

            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            var jwtSecurityToken = await CreateJwtToken(user);

            userDto = _mapper.Map<UserDto>(user);

            userDto.Success = true;
            userDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            userDto.RefreshToken = newRefreshToken.Token;
            userDto.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

            return userDto;
        }


        public async Task<ForgetPasswordDto> ForgetPasswordAsync(string email)
        {
            var forgetPasswordDto = new ForgetPasswordDto();

            var user = await _userManager.FindByEmailAsync(email);

            if(user == null)
            {
                forgetPasswordDto.Success = false;
                forgetPasswordDto.Message = "Invalid User Email";
                forgetPasswordDto.StatusCode = StatusCodes.Status400BadRequest;
                return forgetPasswordDto;
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);
            var tokenTruncated = validToken.Substring(validToken.Length - 6, 6);

            var sendTokenToEmail = await _mailService.SendEmailAsync(email, "Sporty Reset Passord", tokenTruncated);

            if (!sendTokenToEmail)
            {
                forgetPasswordDto.Success = false;
                forgetPasswordDto.Message = "Unexpected Error, please try again with valid inputs";
                forgetPasswordDto.StatusCode = StatusCodes.Status422UnprocessableEntity;
                return forgetPasswordDto;
            }

            forgetPasswordDto.Success = true;
            forgetPasswordDto.ResetToken = validToken;
            forgetPasswordDto.TrancatedResetToken = tokenTruncated;
            forgetPasswordDto.Message = "Reset password Token has been sent to your email successfully!";

            return forgetPasswordDto;
        }

        public async Task<UserDto> ResetPasswordAsync(ResetPasswordDto resetPasswordDto,
                                        ResetPasswordResourceParameters parameters)
        {
            var user = await _userManager.FindByEmailAsync(parameters.Email);
            if (user == null)
                return new UserDto
                {
                    Success = false,
                    Message = "No user associated with email",
                    StatusCode = StatusCodes.Status404NotFound
                };

            if (resetPasswordDto.NewPassword != resetPasswordDto.ConfirmPassword)
                return new UserDto
                {
                    Success = false,
                    Message = "Password doesn't match its confirmation",
                    StatusCode = StatusCodes.Status400BadRequest
                };

            var decodedToken = WebEncoders.Base64UrlDecode(parameters.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, resetPasswordDto.NewPassword);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description}";
                }

                return new UserDto
                {
                    Message = "Something went wrong, " + errors,
                    Success = false,
                    StatusCode = StatusCodes.Status422UnprocessableEntity
                };
            }

            var jwtSecurityToken = await CreateJwtToken(user);

            var userDto = _mapper.Map<UserDto>(user);

            userDto.Success = true;
            userDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            var refreshToken = user.RefreshToken;

            if (refreshToken != null && refreshToken.IsActive)
            {
                userDto.RefreshToken = refreshToken.Token;
                userDto.RefreshTokenExpiration = refreshToken.ExpiresOn;
            }
            else
            {
                refreshToken = GenerateRefreshToken();

                userDto.RefreshToken = refreshToken.Token;
                userDto.RefreshTokenExpiration = refreshToken.ExpiresOn;

                user.RefreshToken = refreshToken;
                await _userManager.UpdateAsync(user);
            }

            return userDto;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(90),
                CreatedOn = DateTime.UtcNow
            };
        }
    }
}
