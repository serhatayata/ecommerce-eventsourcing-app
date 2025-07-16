using Common.Api.Filters;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Scalar.AspNetCore;

namespace Common.Api.Extensions;

public static class CoreApiExtensions
{
    public static IServiceCollection AddCoreApi(
    this IServiceCollection services,
    params Type[] types)
    {
        var assemblies = types.Select(type => type.GetTypeInfo().Assembly);

        services.AddOptions();

        services.AddOpenApi();

        services
            .AddMvc(opt => { opt.Filters.Add<ExceptionFilter>(); })
            .AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblies(assemblies); });

        services.AddHealthChecks();

        services.AddControllers();

        return services;
    }

    public static WebApplication UseCore(
    this WebApplication app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/health");
        });

        return app;
    }
}