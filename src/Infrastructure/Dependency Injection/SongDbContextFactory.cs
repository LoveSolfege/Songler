using DotNetEnv;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Dependency_Injection;

public class SongDbContextFactory : IDesignTimeDbContextFactory<SongDbContext>
{
    public SongDbContext CreateDbContext(string[] args)
    {
        Env.Load(Path.Combine(Directory.GetCurrentDirectory(), "../../.env"));
        
        string? connectionString = Environment.GetEnvironmentVariable("POSTGRES__TESTING_PASSWORD");
    
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("database password is not found");
        }
        
        var optionsBuilder = new DbContextOptionsBuilder<SongDbContext>();
        optionsBuilder.UseNpgsql(connectionString, b => b.MigrationsAssembly("Infrastructure"));

        return new SongDbContext(optionsBuilder.Options);
    }
}