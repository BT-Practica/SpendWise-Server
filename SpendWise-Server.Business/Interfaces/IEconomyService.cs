using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.EconomyDtos;

namespace SpendWise_Server.Business.Interfaces
{
    public interface IEconomyService
    {
        List<Economies> GetAllEconomies();
        Economies GetEconomy(int economyId);
        Task CreateEconomy(EconomyDto economy);
        Task UpdateEcnomy(EconomyDto economy, int id);
        Task DeleteEconomy(int id);
    }
}
