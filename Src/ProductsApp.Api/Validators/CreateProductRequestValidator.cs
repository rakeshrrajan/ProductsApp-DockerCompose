using FluentValidation;
using ProductsApp.Api.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProductsApp.Api.Validators
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(request => request).NotNull();
            RuleFor(request => request.ProductName).NotEmpty();
            RuleFor(request => request.Price).Must(x => x > 0);
        }
    }
}
