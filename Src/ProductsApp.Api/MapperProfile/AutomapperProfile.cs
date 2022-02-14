using AutoMapper;
using ProductsApp.Api.Requests;
using ProductsApp.Data.Entity;
using ProductsApp.Domain.Modal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApp.Api.MapperProfile
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductEntity, Product>();
            CreateMap<Product, ProductEntity>();
            CreateMap<CreateProductRequest, Product>();
        }
    }
}
