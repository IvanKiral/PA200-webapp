namespace PA200_webapp.Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    
}