namespace ResultFlow.Application.Middleware
{
    using System.Net;
    using System.Text.Json;

    public class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
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
                _logger.LogError(ex, "Unhandled exception caught in middleware.");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            if (exception is ArgumentException)
                statusCode = HttpStatusCode.BadRequest;

            if (exception is UnauthorizedAccessException)
                statusCode = HttpStatusCode.Unauthorized;

            var responseObj = new
            {
                success = false,
                message = exception.Message,
                detail = exception.InnerException?.Message,
                exceptionType = exception.GetType().Name,
                statusCode = (int)statusCode,
                timestamp = DateTime.UtcNow
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(JsonSerializer.Serialize(responseObj));
        }
    }
}
