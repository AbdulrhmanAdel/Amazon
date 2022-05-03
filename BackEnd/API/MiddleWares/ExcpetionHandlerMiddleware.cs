namespace api.MiddleWares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(
        RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            var cong = context.RequestServices.GetRequiredService<IConfiguration>();
            await _next(context);

        }
        catch (Exception e)
        {
            var cong = context.RequestServices.GetRequiredService<IConfiguration>();
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(e.Message);
        }
    }
}