using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsApp.Data.Repository;
using ProductsApp.Domain.Repository;
using ProductsApp.Domain.Services;

namespace ProductsApp.Infrastructure.Ioc
{
    public static class DIConfiguration
    {
        public static void AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>(); 
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
