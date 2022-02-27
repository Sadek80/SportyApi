using Microsoft.EntityFrameworkCore;
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

        public async Task AddProductAsync(Product product)
        {
            await _dataContext.AddAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(BaseResourceParametersForSearchAndFilter parameters)
        {
            var products = _dataContext.Products as IQueryable<Product>;

            if (!string.IsNullOrWhiteSpace(parameters.SearchQuery))
            {
                var searchQuery = parameters.SearchQuery.Trim();

                products = products.Where(p => p.Name.Contains(searchQuery) ||
                                               p.Brand.Contains(searchQuery) ||
                                               p.Sport.Name.Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(parameters.FilterBy))
            {
                var filterBy = parameters.FilterBy.Trim();

                products = products.Where(p => p.Sport.Name == filterBy);
            }

            return await products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            if (productId == Guid.Empty)
                throw new ArgumentNullException(nameof(productId));

            return await _dataContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }
    }
}
