namespace Fina.Api.ApiExtensions;

public static class AppExtension
{
    public static void ConfigureDevEnvironment(this WebApplication app)
    {
        // Habilita o swagger apenas no modo desenvolvimento
        app.UseSwagger();
        app.UseSwaggerUI();
        // app.MapSwagger().RequireAuthorization();
    }
}
