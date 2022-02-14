using AutoMapper;
using ProductsApp.Data.Entity;
using ProductsApp.Domain.Modal;

namespace ProductsApp.Data.Extensions
{
    public static class ProductExtension
    {
        public static ProductEntity ToEntity(this Product product, IMapper mapper)
        {
            return mapper.Map<ProductEntity>(product);
        }
    }
}
