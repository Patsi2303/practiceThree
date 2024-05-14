using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace PracticeTwo.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            try 
            {
                return _next(httpContext);
            }
            catch(Exception ex)
            {
                return ProcessError(httpContext, ex);
            }
        }

        private Task ProcessError(HttpContext context,Exception ex) 
        {
            string errorBodyJSON = $"{{\r\n Message = ${ex.Message},\r\n }}";

            return context.Response.WriteAsync(errorBodyJSON);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
