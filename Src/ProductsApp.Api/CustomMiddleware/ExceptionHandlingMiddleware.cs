using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProductsApp.Api.Responses;
using ProductsApp.Domain.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProductsApp.Api.CustomMiddleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(new ErrorModel 
                {
                    StatusCode  = (int) HttpStatusCode.InternalServerError,
                    Message = ex.Message
                }.ToString());                
            }
        }
    }
}
