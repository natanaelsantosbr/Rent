namespace Rent.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication Configurar(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();           

            return app;
        }
    }
}
