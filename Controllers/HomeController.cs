using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportyApi.Models;
using SportyApi.Models.Core;
using SportyApi.Models.Core.DTOs.HomeDtos;
using SportyApi.Models.Core.DTOs.ProductDtos;
using SportyApi.Models.Core.DTOs.TrainingProgramsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AppDataContext _dataContext;
        private readonly IMapper _mapper;

        public HomeController(AppDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetHomeData()
        {
            var programs = await _dataContext.TrainingPrograms.Take(5)
                .Include(t => t.Sport).Include(t => t.Level).ToListAsync();
            var products = await _dataContext.Products.Take(5).Include(t => t.Sport).ToListAsync();

            HomeDto homeDto = new HomeDto();

            homeDto.Products = _mapper.Map<IEnumerable<ProductDto>>(products);
            homeDto.TrainingPrograms = _mapper.Map<IEnumerable<TrainingProgramDto>>(programs);

            return Ok(homeDto);

        }
    }
}
