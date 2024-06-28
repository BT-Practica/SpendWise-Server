using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;
using SpendWise_Server.Repos.Repositories;

namespace SpendWise_Server.Repos;

public static class ExtensionMethods
{

    public static void RegisterRepo(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options => options.
        UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("SpendWise-Server.Repos")));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<DataContext>();
        services.AddScoped<IIncome_CategoriesRepository, Income_CategoriesRepository>();
    }

}
