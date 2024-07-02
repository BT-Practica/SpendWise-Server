using SpendWise_Server.Models;

namespace SpendWise_Server.Business.Interfaces;

public interface ICurrencyService
{
    Task<Currencies> GetCurrency(int id);
    Task<ICollection<Currencies>> GetCurrencies();
}