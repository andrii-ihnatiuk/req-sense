namespace ReqSense.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureCors(
        this IServiceCollection services,
        string policyName,
        IConfigurationManager configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(policyName, policyBuilder =>
            {
                var origins = configuration.GetRequiredSection("CorsOptions:Origins").Get<string[]>();
                policyBuilder.WithOrigins(origins!)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    public static void ConfigureCookies(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.IsEssential = true;
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            options.Cookie.Name = "ReqSense.Identity";
            options.SlidingExpiration = true;
            options.Events.OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.CompletedTask;
            };
        });
    }
}