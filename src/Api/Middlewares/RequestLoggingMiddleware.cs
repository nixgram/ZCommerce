using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Api.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                _logger.LogInformation(
                    "Request {Method} {Url} => {StatusCode} by : {UserId} at {Time}",
                    context.Request.Method,
                    context.Request.Path.Value,
                    context.Response.StatusCode, context.User.FindFirst(ClaimTypes.Email)?.Value ?? "Anonymous",
                    DateTime.Now.ToString("F"));
            }
        }
    }
}