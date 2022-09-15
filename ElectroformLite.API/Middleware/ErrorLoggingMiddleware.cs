using ElectroformLite.Application.Exceptions;
using MediatR;
using System.Net;

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
        catch (NotFoundHttpResponseException ex)
        {
            _logger.LogError("[ERROR]: {message}", ex.Response.ReasonPhrase);
            context.Response.StatusCode = (int)ex.Response.StatusCode;
            context.Response.Headers.Add("reason",ex.Response.ReasonPhrase);
        }
        catch (CantDeleteHttpResponseException ex)
        {
            _logger.LogError("[ERROR]: {message}", ex.Response.ReasonPhrase);
            context.Response.StatusCode = (int)ex.Response.StatusCode;
            context.Response.Headers.Add("reason", ex.Response.ReasonPhrase);
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
