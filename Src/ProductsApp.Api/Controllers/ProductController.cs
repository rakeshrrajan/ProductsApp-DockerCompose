using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsApp.Api.Extension;
using ProductsApp.Api.Requests;
using ProductsApp.Domain.Modal;
using ProductsApp.Domain.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProductsApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _services;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService services, IMapper mapper, ILogger<ProductController> logger)
        {
           _services = services ?? throw new ArgumentNullException(nameof(services));
           _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("SaveProducts")]
        public async Task<IActionResult> SaveProducts(CreateProductRequest productRequest)
        {         
            var product = productRequest.ToDomain(_mapper);
            await _services.SaveProductAsync(product);
            return Ok("Product created");
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {           
            var products = await _services.GetProductsAsync();
            return Ok(products);
        }
    }
}
