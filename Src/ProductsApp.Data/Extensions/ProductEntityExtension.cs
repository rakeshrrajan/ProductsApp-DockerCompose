using AutoMapper;
using ProductsApp.Data.Entity;
using ProductsApp.Domain.Modal;
using System.Collections.Generic;

namespace ProductsApp.Data.Extensions
{
    public static class ProductEntityExtension
    {
        public static IEnumerable<Product> ToDomain(this IEnumerable<ProductEntity> products, IMapper mapper)
        {
            return mapper.Map<IEnumerable<Product>>(products);
        }
    }
}
