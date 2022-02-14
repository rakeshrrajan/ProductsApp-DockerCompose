using AutoMapper;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProductsApp.Data.Entity;
using ProductsApp.Data.Extensions;
using ProductsApp.Domain.Modal;
using ProductsApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsApp.Data.Repository
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {      
        private const string COLLECTION = "Products";
        private IMapper _mapper;

        public ProductRepository(IConfiguration configuration, IMapper mapper) : base(configuration)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var productCollection = Database.GetCollection<ProductEntity>(COLLECTION);
            var products = await productCollection.Find<ProductEntity>(_ => true).ToListAsync();
            return products.ToDomain(_mapper);
        }

        public async Task SaveProductAsync(Product product)
        {
            var productEntity = product.ToEntity(_mapper);
            var productCollection = Database.GetCollection<ProductEntity>(COLLECTION);
            await productCollection.InsertOneAsync(productEntity);
        }
    }
}
