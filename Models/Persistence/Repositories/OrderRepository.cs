using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.OrderDto;
using SportyApi.Models.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDataContext _dataContext;

        public OrderRepository(AppDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task AddOrderAsync(Order order, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetUserOrdersHistoryAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
