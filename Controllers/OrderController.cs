using AutoMapper;
using SportyApi.Models.Core;
using SportyApi.Models.Core.DTOs.OrderDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Controllers
{
    [Route("api/orders")]
    [Authorize]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetUserOrdersHistory()
        {
            //throw new NotImplementedException();
            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;
            return Ok(new { uid });
        }

        [HttpPost]
        public async Task<IActionResult> MakeAnOrder([FromBody] OrderForCreationDto orderForCreationDto)
        {
            //throw new NotImplementedException();
            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;
            return Ok(new { id = uid, orderForCreationDto });

        }
    }
}
