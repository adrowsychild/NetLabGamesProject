using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Net.Lab.CoreWebAPI.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<LogMiddleware> _logger;

        public LogMiddleware(ILogger<LogMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                // there can be some logic
                await _next(httpContext);
                // there can be some logic
            }
            catch (Exception ex)
            {
                _logger.LogError("some error occured", ex);
                throw new Exception("Some error occured");
            }
        }
    }
}
