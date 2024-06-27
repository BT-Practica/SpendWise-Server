using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.EconomyDtos;

namespace SpendWise_Server.Repos.Interfaces;

public interface IEconomyRepository
{
    Economies GetEconomy();
    void AddEconomy(EconomyDto economies);
    void UpdateEconomy();
    void DeleteEconomy();
}