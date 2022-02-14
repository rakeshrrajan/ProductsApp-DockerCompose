using ProductsApp.Domain.Modal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task SaveProductAsync(Product product);
    }
}
