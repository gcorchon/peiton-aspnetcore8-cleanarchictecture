using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Peiton.Core.Exceptions;

namespace Peiton.Api;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

        logger.LogError(exception,
                        "Se ha producido un error al procesar la petición en el servidor { MachineName }. TraceId: { TraceId }",
                        Environment.MachineName,
                        traceId);

        var data = MapException(exception);
        await Results.Problem(
            title: data.Title,
            statusCode: data.StatusCode,
            extensions: new Dictionary<string, object?> {
                { "traceId", traceId }
            }
        ).ExecuteAsync(httpContext);

        return true;
    }

    private static (int StatusCode, string Title) MapException(Exception exception)
    {
        return exception switch
        {
            NotFoundException => (StatusCodes.Status404NotFound, exception.Message),
            ArgumentException => (StatusCodes.Status400BadRequest, exception.Message),
            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error")
        };
    }
}
