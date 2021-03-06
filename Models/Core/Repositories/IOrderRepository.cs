using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetUserOrdersHistoryAsync(string userId);
        Task<OrderHistoryDto> AddOrderAsync(Order order, string userId);
    }
}
