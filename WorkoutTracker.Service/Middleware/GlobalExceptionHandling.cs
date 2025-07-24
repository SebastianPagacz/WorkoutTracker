using WorkoutTracker.Domain.Exceptions;

namespace WorkoutTracker.Service.Middleware;

public class GlobalExceptionHandling
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandling> _logger;
    public GlobalExceptionHandling(RequestDelegate next, ILogger<GlobalExceptionHandling> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ItemNotFoundException ex)
        {
            _logger.LogWarning(ex, ex.Message);
            context.Response.StatusCode = 404;
            await context.Response.WriteAsJsonAsync(new { message = ex.Message });
        }
        catch (ItemAlreadyExisitsException ex)
        {
            _logger.LogWarning(ex, ex.Message);
            context.Response.StatusCode = 409;
            await context.Response.WriteAsJsonAsync(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, ex.Message);
            context.Response.StatusCode = 404;
            await context.Response.WriteAsJsonAsync(new { message = ex.Message });
        }
    }
}
