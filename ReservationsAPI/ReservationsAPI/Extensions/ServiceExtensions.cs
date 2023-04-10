using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace ReservationsAPI.Extensions;

public static class ServiceExtensions
{
    // CORS cross-origin resource sharing

    // AllowAnyOrigin -> WithOrigins("example.com")
    // AllowAnyMethod -> WithMethods("POST", "GET")
    // AllowAnyHeader -> WithHeaders("accept", "content-type")
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("X-Pagination"));
        });

    public static void ConfigureIISIntegration(this IServiceCollection services) =>
    services.Configure<IISOptions>(options =>
    {
    });

    
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
    services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    
}

