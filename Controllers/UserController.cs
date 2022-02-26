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
            //throw new NotImplementedException();
            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;
            return Ok(new { uid });
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UserForUpdateDto userForUpdateDto)
        {
            //throw new NotImplementedException();
            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;
            return Ok(new { id = uid, userForUpdateDto });
        }
    }
}
