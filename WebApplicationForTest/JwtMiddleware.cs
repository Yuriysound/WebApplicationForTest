using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationForTest
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AuthService _authService;

        public JwtMiddleware(RequestDelegate next, AuthService authService)
        {
            _next = next;
            _authService = authService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                var customerId = _authService.ValidateJwtToken(token);

                if (customerId != -1)
                {
                    context.Items["CustomerId"] = customerId;
                }
            }

            await _next(context);
        }
    }
}
