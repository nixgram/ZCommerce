using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (FluentValidationException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        private static Task HandleExceptionAsync(HttpContext context, FluentValidationException exception)
        {
            // Log issues and handle exception response

            context.Response.ContentType = "application/json";

            /*if (exception.GetType() == typeof(ValidationException))
            {
                var code = HttpStatusCode.BadRequest;
                var result1 = JsonConvert.SerializeObject(((ValidationException) exception).Message);
                context.Response.StatusCode = (int) code;
                return context.Response.WriteAsync(result1);
            }*/

            if (exception.GetType() == typeof(FluentValidationException))
            {
                var code = HttpStatusCode.BadRequest;
                var descriptors = exception.ErrorDescriptors;
                var result2 = JsonConvert.SerializeObject(descriptors);
                context.Response.StatusCode = (int) code;
                return context.Response.WriteAsync(result2);
            }
            
            


            var result = JsonConvert.SerializeObject(new {isSuccess = false, reasonOfFailure = exception.Message});
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(result);
        }
    }
}