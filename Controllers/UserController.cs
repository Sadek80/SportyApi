using AutoMapper;
using SportyApi.Models.Core;
using SportyApi.Models.Core.DTOs.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Controllers
{
    [Route("api/users")]
    [Authorize]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserProfileController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;

            var userForProfile = await _unitOfWork.UserRepository.GetUserProfileAsync(uid);

            if (!userForProfile.Success)
                return StatusCode(userForProfile.StatusCode, userForProfile.Message);

            return Ok(new 
            {
                id = uid,
                userForProfile.Name, 
                userForProfile.Email,
                userForProfile.Address, 
                userForProfile.CreditCards
            });
        }

        [HttpGet("payment-data")]
        public async Task<IActionResult> GetUserPaymentData()
        {
            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;

            var userForCartDto = await _unitOfWork.UserRepository.GetUserPaymentDataAsync(uid);

            if (!userForCartDto.Success)
                return StatusCode(userForCartDto.StatusCode, userForCartDto.Message);

            return Ok(new
            {
               userForCartDto.Address,
               userForCartDto.CreditCards
            });
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UserForUpdateDto userForUpdateDto)
        {
            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;

            var userForProfile = await _unitOfWork.UserRepository.UpdateUserProfileAsync(userForUpdateDto, uid);

            if (!userForProfile.Success)
                return StatusCode(userForProfile.StatusCode, userForProfile.Message);

           await _unitOfWork.Save();

            return Ok(new
            {
                id = uid,
                userForProfile.Name,
                userForProfile.Email,
                userForProfile.Address,
                userForProfile.CreditCards
            });
        }
    }
}
