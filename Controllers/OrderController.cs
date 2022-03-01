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
using SportyApi.Models.Core.Domain;
using Microsoft.AspNetCore.Identity;

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
            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;

            var orders = await _unitOfWork.OrderRepository.GetUserOrdersHistoryAsync(uid);

            if (orders is null)
                return BadRequest("Invalid User");

            if (orders.Count == 0)
                return Ok("There's no orders yet");

            var ordersHistory = _mapper.Map<List<OrderHistoryDto>>(orders);

            for(int i = 0; i < ordersHistory.Count; i++)
            {
                ordersHistory[i].CreditCardNumber = orders[i].CreditCard.CreditCardNumber;
                ordersHistory[i].ProductsDetails = _mapper.Map<List<OrderItemDto>>(orders[i].OrderItems);
            }


            return Ok(_mapper.Map<List<OrderHistoryMinimizedDto>>(ordersHistory));
        }

        [HttpPost]
        public async Task<IActionResult> MakeAnOrder([FromBody] OrderForCreationDto orderForCreationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;

            var order = _mapper.Map<Order>(orderForCreationDto);
            order.OrderItems = _mapper.Map<List<OrderItem>>(orderForCreationDto.Products);
            order.CreditCard = _mapper.Map<OrderCreditCard>(orderForCreationDto.CreditCard);

            var orderHistoryDto = await _unitOfWork.OrderRepository.AddOrderAsync(order, uid);

            if (!orderHistoryDto.Success)
                return StatusCode(orderHistoryDto.StatusCode, orderHistoryDto.Message);

            if (await _unitOfWork.Save() < 1)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(new 
            {
                orderHistoryDto.CreditCardNumber, 
                orderHistoryDto.Address,
                orderHistoryDto.Date, orderHistoryDto.ProductsDetails, 
                orderHistoryDto.TotalPrice
            });
        }
    }
}
