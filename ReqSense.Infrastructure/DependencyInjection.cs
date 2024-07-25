using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Domain.Entities.Identity;
using ReqSense.Domain.Options;
using ReqSense.Infrastructure.Data;
using ReqSense.Infrastructure.Data.Interceptors;
using ReqSense.Infrastructure.Gemini;
using ReqSense.Infrastructure.Gemini.Interfaces;
using ReqSense.Infrastructure.HttpHandlers;
using ReqSense.Infrastructure.Identity;

namespace ReqSense.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (connectionString.IsNullOrEmpty())
        {
            throw new Exception("DB connection string is required.");
        }

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString);
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<ApplicationDbContextInitializer>();

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        services.Configure<IdentityOptions>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 5;
        });

        services.AddScoped<IIdentityService, IdentityService>();

        services.AddScoped<IGenerativeAiService, GeminiAiService>();
        services.Configure<GeminiOptions>(configuration.GetSection("Gemini"));
        services.AddTransient<GeminiHttpHandler>();
        services.AddHttpClient<IGeminiClient, GeminiClient>((sp, httpClient) =>
        {
            var geminiOptions = sp.GetRequiredService<IOptions<GeminiOptions>>().Value;
            httpClient.BaseAddress = new Uri(geminiOptions.Url);
        }).AddHttpMessageHandler<GeminiHttpHandler>();

        return services;
    }
}