using AutoMapper;
using SportyApi.Models.Core;
using SportyApi.Models.Core.DTOs.Base_Dtos;
using SportyApi.Models.Core.DTOs.UserDtos;
using SportyApi.ResourceParameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace SportyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public AuthController(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync([FromBody] UserForSignUpDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userDto = await _unitOfWork.AuthRepository.SignUpAsync(user);

            if (!userDto.Success)
                return StatusCode(userDto.StatusCode, userDto.Message);

            return Ok(_mapper.Map<UserDtoMinimized>(userDto));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogInAsync([FromBody] UserForLogInDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userDto = await _unitOfWork.AuthRepository.LogInAsync(user);

            if (!userDto.Success)
                return StatusCode(userDto.StatusCode, userDto.Message);

            return Ok(_mapper.Map<UserDtoMinimized>(userDto));
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto refreshToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userDto = await _unitOfWork.AuthRepository.RefreshTokenAsync(refreshToken.Token);

            if (!userDto.Success)
                return StatusCode(userDto.StatusCode, userDto.Message);

            return Ok(_mapper.Map<UserDtoMinimized>(userDto));
        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPasswordAsync(string email)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrEmpty(email))
                return BadRequest("Email is Required");

            var forgetPasswordDto = await _unitOfWork.AuthRepository.ForgetPasswordAsync(email);

            if (!forgetPasswordDto.Success)
                return StatusCode(forgetPasswordDto.StatusCode, forgetPasswordDto.Message);

            var url = Url.Link("ResetPassword", new { Token = forgetPasswordDto.ResetToken, Email = email });

            SetResetTokenInMemoryCache(url, forgetPasswordDto.TrancatedResetToken);

            return Ok(forgetPasswordDto.Message);
        }

        [HttpPost("CheckResetToken")]
        public async Task<IActionResult> CheckResetToken([FromBody] TokenDto token)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid request");

            string url;
            _memoryCache.TryGetValue(token.Token, out url);

            if (url is null)
                return StatusCode(StatusCodes.Status403Forbidden, "Invalid Token");

            var resetLink = new LinkDto(url,
               "ResetPasswordLink", "POST");

            return Ok(new { resetLink });

        }

        [HttpPost("ResetPassword", Name = "ResetPassword")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordDto passwordDto,
            [FromQuery] ResetPasswordResourceParameters parameter)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid request");

            var userDto = await _unitOfWork.AuthRepository.ResetPasswordAsync(passwordDto, parameter);

            if (!userDto.Success)
                return StatusCode(userDto.StatusCode, userDto.Message);

            return Ok(_mapper.Map<UserDtoMinimized>(userDto));
        }

        private void SetResetTokenInMemoryCache(string resetLink, string tokenTruncated)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                     .SetSlidingExpiration(TimeSpan.FromMinutes(10));
            _memoryCache.Set(tokenTruncated, resetLink, cacheEntryOptions);
        }
    }
}
