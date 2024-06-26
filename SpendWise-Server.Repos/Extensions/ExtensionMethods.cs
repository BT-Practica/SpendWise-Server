using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpendWise_Server.Repos.DataLayer;

namespace SpendWise_Server.Repos;

public static class ExtensionMethods
{
    public static void RegisterRepo(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options => options.
        UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("SpendWise-Server.Repos")));
    }
}
