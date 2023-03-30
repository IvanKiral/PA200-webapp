using PA200_webapp.Repository;
using PA200_webapp.Services;

namespace PA200_webapp.Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }

    public static void ConfigureMapper(this IServiceCollection services)
    {
        services.AddSingleton(Mapper.GetMapperInstance());
    }
}