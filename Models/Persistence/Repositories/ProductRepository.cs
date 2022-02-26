using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.ProductDtos;
using SportyApi.Models.Core.Repositories;
using SportyApi.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDataContext _dataContext;

        public ProductRepository(AppDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<bool> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProducts(BaseResourceParametersForSearchAndFilter parameters)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
