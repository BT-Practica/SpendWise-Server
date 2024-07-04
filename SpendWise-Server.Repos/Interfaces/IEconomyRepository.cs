using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.EconomyDtos;

namespace SpendWise_Server.Repos.Interfaces;

public interface IEconomyRepository
{
    List<Economies> GetAllEconomies();
    Economies GetEconomy(int id);
    Task<Economies> GetEconomyByUserId(int userId);
    Task AddEconomy(EconomyDto economies);
    Task UpdateEconomy(EconomyDto economyDto, int id);
    Task DeleteEconomy(int id);
}