using System.Net;
using Newtonsoft.Json;

namespace EventManagementApi
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError($"Exception details: {ex.Message}");
                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message
                };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }

}
