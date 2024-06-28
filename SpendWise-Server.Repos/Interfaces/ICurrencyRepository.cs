using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpendWise_Server.Models;

namespace SpendWise_Server.Repos.Interfaces;

public interface ICurrencyRepository
{
    Task<Currencies> GetCurrency(int currencyId);
    Task<ICollection<Currencies>> GetCurrencies();
}