using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpendWise_Server.Models;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Repos.Repositories;

public class CurrencyRepository : ICurrencyRepository
{
    private readonly DataContext _dataContext;
    private readonly ILogger<CurrencyRepository> _logger;
    public CurrencyRepository(DataContext dataContext, ILogger<CurrencyRepository> logger)
    {
        _dataContext = dataContext;
        _logger = logger;
    }
    public async Task<Currencies> GetCurrency(int currencyId)
    {
        var currency = await _dataContext.Currencies.FirstOrDefaultAsync(c => c.Id == currencyId);
        if (currency == null)
            throw new KeyNotFoundException("Currency does not exist.");
            _logger.LogError("Repository: Currency does not exit!");
            
        return currency;
    }

    public async Task<ICollection<Currencies>> GetCurrencies(){
        ICollection<Currencies> currencies = await _dataContext.Currencies.ToListAsync();
        if (currencies.Count == 0)
            _logger.LogError("Repository: No available currencies");

        return currencies;
    }
}