using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpendWise_Server.Models;

namespace SpendWise_Server.Business.Interfaces;

public interface ICurrencyService
{
    Task<Currencies> GetCurrency(int id);
    Task<ICollection<Currencies>> GetCurrencies();
}