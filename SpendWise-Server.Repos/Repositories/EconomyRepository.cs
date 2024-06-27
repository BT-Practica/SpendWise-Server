using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.EconomyDtos;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Repos.Repositories;

public class EconomyRepository : IEconomyRepository
{
    public readonly DataContext _dataContext;
    public EconomyRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public void AddEconomy(EconomyDto economiesDto)
    {
        Economies economy = new Economies
        {
            Amount = economiesDto.Amount,
            RegistrationDate = DateTime.Now
        };
        _dataContext.Add(economy);
        _dataContext.SaveChanges();
    }

    public void DeleteEconomy()
    {
        throw new NotImplementedException();
    }

    public Economies GetEconomy()
    {
        throw new NotImplementedException();
    }

    public void UpdateEconomy()
    {
        throw new NotImplementedException();
    }
}