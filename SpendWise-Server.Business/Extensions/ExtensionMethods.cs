using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Business.Services;
using SpendWise_Server.Repos;
using SpendWise_Server.Repos.Interfaces;
using SpendWise_Server.Repos.Repositories;

namespace SpendWise_Server.Business;

public static class BusinessRegistrations
{
    public static void RegisterDependecies(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterRepo(configuration);
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IIncome_CategoriesService, Income_CategoriesService>();
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<IIncomeServices, IncomeService>();
        services.AddLogging();
    }

}
