using AutoMapper;
using SportyApi.Models.Core;
using SportyApi.Models.Core.DTOs.ProductDtos;
using SportyApi.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Controllers
{
    [Route("api/products")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] BaseResourceParametersForSearchAndFilter parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var products = await _unitOfWork.ProductRepository.GetAllProductsAsync(parameters);

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            //throw new NotImplementedException();
            return Ok(productId);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductForCreationDto product)
        {
            //throw new NotImplementedException();
            return Ok(product);
        }
    }
}
