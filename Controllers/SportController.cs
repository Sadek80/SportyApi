using AutoMapper;
using SportyApi.Models.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportyApi.Helpers;
using SportyApi.Models.Core.Domain;
using Microsoft.AspNetCore.Identity;
using SportyApi.Models.Core.DTOs.Base_Dtos;

namespace SportyApi.Controllers
{
    [Route("api/sports")]
    [Authorize]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public SportController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSports()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sports = await _unitOfWork.SportRepository.GetAllSportsAsync();

            return Ok(_mapper.Map<List<SportBaseDto>>(sports));
        }

        [HttpPost]
        public async Task<IActionResult> AddUserInterests([FromBody] IEnumerable<Guid> SportsIds)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (SportsIds.Count() == 0)
                return BadRequest("Invalid sports!");

            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;

            var userInterest = await _unitOfWork.SportRepository.AddUserInterestsAsync(SportsIds, uid);

            if (userInterest != "Interests added successfully.")
                return BadRequest(userInterest);

            await _unitOfWork.Save();

            return Ok(SportsIds);
        }

    }
}
