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

namespace SportyApi.Controllers
{
    [Route("api/sports")]
    [Authorize]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SportController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSports()
        {
            //throw new NotImplementedException();
            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;
            var path = HttpContext.Request.GetRootPath();
            
            return Ok(new { uid, path });
        }

        [HttpPost]
        public async Task<IActionResult> AddUserInterests([FromBody] IEnumerable<Guid> SportsIds)
        {
            //throw new NotImplementedException();
            if (SportsIds.Count() == 0)
                return BadRequest("Invalid sports");

            return Ok(SportsIds.FirstOrDefault());
        }

    }
}
