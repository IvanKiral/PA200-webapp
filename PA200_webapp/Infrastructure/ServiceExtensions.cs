
using PA200_webapp.Services;
using AdminService = PA200_webapp.Services.MongoDB.AdminService;
using ClassService = PA200_webapp.Services.MongoDB.ClassService;
using IUserRepository = PA200_webapp.Repository.MongoDB.Interfaces.IUserRepository;
using PostService = PA200_webapp.Services.MongoDB.PostService;
using SchoolService = PA200_webapp.Services.MongoDB.SchoolService;
using SubjectService = PA200_webapp.Services.MongoDB.SubjectService;
using UserRepository = PA200_webapp.Repository.MongoDB.UserRepository;
using UserService = PA200_webapp.Services.MongoDB.UserService;

namespace PA200_webapp.Infrastructure;

public static class ServiceExtensions
{
    // public static void ConfigureUnitOfWork(this IServiceCollection services)
    // {
    //     services.AddScoped<IUnitOfWork, UnitOfWork>();
    // }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<ISchoolService, SchoolService>();
        services.AddScoped<IClassService, ClassService>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<IPostService, PostService>();
    }
    
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }

    public static void ConfigureMapper(this IServiceCollection services)
    {
        services.AddSingleton(Mapper.GetMapperInstance());
    }
}