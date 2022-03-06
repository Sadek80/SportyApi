using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.ProductDtos;
using SportyApi.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(BaseResourceParametersForSearchAndFilter parameters, string userId);
        Task<Product> GetProductByIdAsync(Guid productId);
        Task AddProductAsync(Product product);
    }
}
