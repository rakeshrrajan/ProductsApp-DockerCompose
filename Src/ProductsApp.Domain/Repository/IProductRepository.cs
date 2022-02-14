using ProductsApp.Domain.Modal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task SaveProductAsync(Product product);
    }
}
