using AutoMapper;

namespace Common.Application.Mapper;

public static class Mapping
{
    public static TTarget Map<TSource, TTarget>(IMapper mapper, TSource value)
        where TSource : class
        where TTarget : class
    {
        return mapper.Map<TTarget>(value);
    }
}