using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Application.Services;

namespace ReqSense.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IProjectService, ProjectService>();

        return services;
    }
}