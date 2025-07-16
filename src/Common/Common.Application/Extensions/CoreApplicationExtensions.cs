using System.Reflection;
using Common.Application.Commands;
using Common.Application.Events;
using Common.Application.Queries;
using Common.Domain.Core.Events;
using Common.Domain.Core.Validations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Application.Extensions;

public static class CoreApplicationExtensions
{
    public static IServiceCollection AddCoreApplication(
    this IServiceCollection services,
    params Type[] types)
    {
        var assemblies = types.Select(type => type.GetTypeInfo().Assembly);

        foreach (var assembly in assemblies)
            services.AddMediatR(s => s.RegisterServicesFromAssembly(assembly));

        services.AddScoped<ICommandBus, CommandBus>();
        services.AddScoped<IQueryBus, QueryBus>();
        services.AddScoped<IEventBus, EventBus>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}