using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpendWise_Server.Repos;

namespace SpendWise_Server.Business;

public static class BusinessRegistrations
{
    public static void RegisterDependecies(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterRepo(configuration);
    }
}
