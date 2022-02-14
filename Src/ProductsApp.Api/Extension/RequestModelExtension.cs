using AutoMapper;
using ProductsApp.Api.Requests;
using ProductsApp.Data.Entity;
using ProductsApp.Domain.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApp.Api.Extension
{
    public static class RequestModelExtension
    {
        public static Product ToDomain(this CreateProductRequest product, IMapper mapper)
        {
            return mapper.Map<Product>(product);
        }
    }
}
