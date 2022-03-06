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
            product.ProductId = Guid.NewGuid();
            await _dataContext.AddAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(BaseResourceParametersForSearchAndFilter parameters,
            string userId)
        {
            var userInterests = await _dataContext.UsersInterests
                                                                .Where(ui => ui.UserId == userId)
                                                                .Select(u => u.SportId).ToListAsync();
            var products = _dataContext.Products.Include(p => p.Sport) as IQueryable<Product>;

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

            //var productList = await products.OrderBy(p => userInterests.IndexOf(p.SportId)).ToListAsync();

            List<Product> productList;

            if (userInterests.Count != 0)
            {
                productList = await products.OrderBy(p => p.SportId).ToListAsync();
                productList = productList.OrderByDescending(p => userInterests.IndexOf(p.SportId)).ToList();
            }
            else
            {
                productList = await products.ToListAsync();
            }

            return productList;
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            if (productId == Guid.Empty)
                throw new ArgumentNullException(nameof(productId));

            return await _dataContext.Products.Include(p => p.Sport).FirstOrDefaultAsync(p => p.ProductId == productId);
        }
    }
}
