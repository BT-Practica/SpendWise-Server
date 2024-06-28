using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Business.Services;

public class CurrenciesService : ICurrencyService
{
    private readonly ILogger _logger;
    private readonly ICurrencyRepository _currencyRepository;
    public CurrenciesService(ICurrencyRepository currencyRepository, ILogger logger)
    {
        _currencyRepository = currencyRepository;
        _logger = logger;
    }
    public async Task<Currencies> GetCurrency(int id)
    {
        if (id<0){
            _logger.LogError("Business: Invalid id");
            throw new ArgumentException("Invalid id");
        }
        var currency = await _currencyRepository.GetCurrency(id);
        return currency;
    }
    public async Task<ICollection<Currencies>> GetCurrencies()
    {
        var listOfCurrencies = await _currencyRepository.GetCurrencies();
        if (listOfCurrencies.IsNullOrEmpty()){
            _logger.LogError("Business: Currency list is empty!");
            throw new NullReferenceException("List is empty");
        }
        return listOfCurrencies;
    }

}