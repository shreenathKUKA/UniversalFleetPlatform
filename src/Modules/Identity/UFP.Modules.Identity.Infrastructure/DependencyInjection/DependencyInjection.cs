using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UFP.Modules.Identity.Infrastructure.Identity;
using UFP.Modules.Identity.Infrastructure.Persistence;

namespace UFP.Modules.Identity.Infrastructure.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =configuration.GetConnectionString("UfpDatabase") 
        ?? throw new InvalidOperationException("Connection String was nor found");

        services.AddDbContext<UFPIdentityDbContext>(options => options.UseNpgsql(connectionString ,npgsql => {
            npgsql.MigrationsHistoryTable(
            "__ef_migrations_history","identity");
            }));


        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequiredLength = 12;
            options.Password.RequireDigit = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.DefaultLockoutTimeSpan =
                        TimeSpan.FromMinutes(15);

                    options.SignIn.RequireConfirmedEmail = false;
        })
        .AddEntityFrameworkStores<UFPIdentityDbContext>()
        .AddDefaultTokenProviders();


        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "ufp.auth";

            options.Cookie.HttpOnly = true;

            options.Cookie.SameSite =
                SameSiteMode.Strict;

            options.SlidingExpiration = true;

            options.ExpireTimeSpan =
                TimeSpan.FromMinutes(30);

            options.Events.OnRedirectToLogin =
                context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };

            options.Events.OnRedirectToAccessDenied =
                context =>
                {
                    context.Response.StatusCode = 403;
                    return Task.CompletedTask;
                };
        });

        return services;
    }
}