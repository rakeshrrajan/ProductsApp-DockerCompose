using System;

namespace ProductsApp.Api.Requests
{
    public class CreateProductRequest
    {
        public CreateProductRequest()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
