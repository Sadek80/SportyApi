using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.OrderDto;
using SportyApi.Models.Core.Repositories;
using SportyApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDataContext _dataContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ICreditCardValidationService _cardValidationService;

        public OrderRepository(AppDataContext dataContext, UserManager<ApplicationUser> userManager,
                                                                        IMapper mapper,
                                                                        ICreditCardValidationService cardValidationService)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _mapper = mapper;
            _cardValidationService = cardValidationService;
        }

        public async Task<OrderHistoryDto> AddOrderAsync(Order order, string userId)
        {
            var orderHistoryDto = new OrderHistoryDto();

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                orderHistoryDto.Success = false;
                orderHistoryDto.Message = "Invalid User";
                orderHistoryDto.StatusCode = StatusCodes.Status404NotFound;
                return orderHistoryDto;
            }

            order.Date = DateTimeOffset.UtcNow;
            order.OrderId = Guid.NewGuid();
            order.UserId = userId;

            if(!_cardValidationService.IsCreditCardInfoValid(order.CreditCard.CreditCardNumber,
                                                                                 order.CreditCard.ExpirationDate))
            {
                orderHistoryDto.Success = false;
                orderHistoryDto.Message = "Invalid Payment";
                orderHistoryDto.StatusCode = StatusCodes.Status400BadRequest;
                return orderHistoryDto;
            }

            double totalPrice = 0;

            foreach (var item in order.OrderItems)
            {
                var product = await _dataContext.Products.FirstOrDefaultAsync(p => p.ProductId == item.ProductId);

                if(product is null)
                {
                    orderHistoryDto.Success = false;
                    orderHistoryDto.Message = "Invalid Products";
                    orderHistoryDto.StatusCode = StatusCodes.Status404NotFound;
                    return orderHistoryDto;
                }

                if(product.Quantity - item.Amount < 0)
                {
                    orderHistoryDto.Success = false;
                    orderHistoryDto.Message = $"{product.Name} is not available in this amount. " +
                                                                                     $"We have {product.Quantity} left";
                    orderHistoryDto.StatusCode = StatusCodes.Status422UnprocessableEntity;
                    return orderHistoryDto;
                }

                if(product.Price * item.Amount != item.TotalItemPrice)
                {
                    orderHistoryDto.Success = false;
                    orderHistoryDto.Message = $"Unhandled price";
                    orderHistoryDto.StatusCode = StatusCodes.Status422UnprocessableEntity;
                    return orderHistoryDto;
                }

                totalPrice += item.TotalItemPrice;
                product.Quantity -= item.Amount;
                item.OrderId = order.OrderId;
            }

            if(order.TotalPrice != totalPrice + 10)
            {
                orderHistoryDto.Success = false;
                orderHistoryDto.Message = $"Unhandled price";
                orderHistoryDto.StatusCode = StatusCodes.Status422UnprocessableEntity;
                return orderHistoryDto;
            }

            await _dataContext.Orders.AddAsync(order);

            orderHistoryDto = _mapper.Map<OrderHistoryDto>(order);
            orderHistoryDto.ProductsDetails = _mapper.Map<List<OrderItemDto>>(order.OrderItems);
            orderHistoryDto.CreditCardNumber = order.CreditCard.CreditCardNumber;
            orderHistoryDto.Success = true;

            return orderHistoryDto;
        }

        public async Task<List<Order>> GetUserOrdersHistoryAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return null;

            var orders = await _dataContext.Orders.Where(o => o.UserId == userId).ToListAsync();

            foreach (var order in orders)
            {
                order.OrderItems = await _dataContext.OrderItems.Where(o => o.OrderId == order.OrderId)
                                                                .Include(o => o.Product).ToListAsync();
            }

            return orders;
        }
    }
}
