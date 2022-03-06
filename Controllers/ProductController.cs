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
            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;
            
            if (!ModelState.IsValid)
                return BadRequest();

            var products = await _unitOfWork.ProductRepository.GetAllProductsAsync(parameters, uid);

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            if (productId == Guid.Empty)
                return BadRequest("Invalid Product");

            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(productId);

            if (product is null)
                return NotFound("Product Not Found");

            return Ok(_mapper.Map<ProductFullDto>(product));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductForCreationDto product)
        {
            //throw new NotImplementedException();
            return Ok(product);
        }
    }
}
