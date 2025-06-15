using Infrastructure.Persistence;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Dependency_Injection;

public static class Database
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<PostgresSettings>(config.GetSection("POSTGRES"));

        services.AddDbContext<SongDbContext>((sp, options) =>
        {
            var settings = sp.GetService<IOptions<PostgresSettings>>();

            if (settings is null)
            {
                throw new NullReferenceException("PostgresSettings is null");
            }
            
            options.UseNpgsql(settings.Value.TESTING_PASSWORD);
        });
        
        return services;
    }
}