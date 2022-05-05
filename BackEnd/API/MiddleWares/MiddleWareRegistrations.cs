namespace api.MiddleWares;

public static class MiddleWareRegistrations
{
    public static void RegisterApplicationMiddleWares(this WebApplication app)
    {
        app.UseCors(options => options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionHandlerMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseStaticFiles();
        app.MapControllers();
        app.Run();
    }
}