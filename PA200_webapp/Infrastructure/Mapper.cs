using AutoMapper;

namespace PA200_webapp.Infrastructure;

public static class Mapper
{
    public static IMapper GetMapperInstance() => MapperCreator
        .CreateConfiguration()
        .CreateMapper();
}