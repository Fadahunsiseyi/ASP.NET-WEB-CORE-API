using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

public class ExceptionMiddleware
{
    private RequestDelegate Next { get; }
    public ExceptionMiddleware(RequestDelegate next)
    {
        Next = next;
    }
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await Next(httpContext);
        }
        catch (InvalidNameException ex)
        {
            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = 400;
            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status400BadRequest,
                Detail = string.Empty,
                Instance = string.Empty,
                Title = "Name is Invalid",
                Type = " Error"
            };
            var problemDetailsJson = JsonSerializer.Serialize(problemDetails);
            await httpContext.Response.WriteAsync(problemDetailsJson);
        }
        catch (Exception ex)
        {
            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = 500;
            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Detail = ex.Message,
                Instance = string.Empty,
                Title = "Internal Server Error",
                Type = " Error"
            };
            var problemDetailsJson = JsonSerializer.Serialize(problemDetails);
            await httpContext.Response.WriteAsync(problemDetailsJson);
        }
    }
}