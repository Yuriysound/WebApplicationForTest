using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApplicationForTest.Middleware
{
    public class ExceptionHandler
    {
        private RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (ex)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    result = notFoundException.Message;
                    break;
            }

            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(result);
        }
    }
}
