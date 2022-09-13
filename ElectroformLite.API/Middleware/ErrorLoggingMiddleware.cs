namespace ElectroformLite.API.Middleware;

public class ErrorLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ErrorLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<ErrorLoggingMiddleware>();
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error: {message}", ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation(
            "{method} {url} returned: {statusCode}",
            context.Request?.Method,
            context.Request?.Path.Value,
            context.Response?.StatusCode);
        }
    }

}
