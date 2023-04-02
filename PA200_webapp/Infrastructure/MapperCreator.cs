using AutoMapper;
using PA200_webapp.Infrastructure.Profiles;

namespace PA200_webapp.Infrastructure;

public static class MapperCreator
{
    public static MapperConfiguration CreateConfiguration() =>
        new(mc =>
        {
            mc.AddProfile<UserProfile>();
            mc.AddProfile<AdminProfile>();
            mc.AddProfile<SchoolProfile>();
            mc.AddProfile<PostProfile>();
            mc.AddProfile<ClassProfile>();
        });
}