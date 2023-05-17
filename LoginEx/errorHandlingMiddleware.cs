using LoginEx;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LoginEx
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class errorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        ILogger<errorHandlingMiddleware> _logger;

        public errorHandlingMiddleware(RequestDelegate next, ILogger<errorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                _logger.LogError($"server error :{e.Message}, {e.StackTrace}");
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("some server error occured, we are sorry");
            }
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class errorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseerrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<errorHandlingMiddleware>();
        }
    }
}
