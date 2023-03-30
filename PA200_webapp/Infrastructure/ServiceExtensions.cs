using PA200_webapp.Repository;

namespace PA200_webapp.Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
    }
}