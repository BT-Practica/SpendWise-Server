using SpendWise_Server.Models;

namespace SpendWise_Server.Business.Interfaces
{
    public interface IEconomyService
    {
        List<Economies> GetAllEconomies();
        Economies GetEconomy(string economyId);
        Task CreateEconomy(Economies economy);
        Task UpdateEcnomy(Economies economy, int id);
        Task DeleteEconomy(int id);
    }
}
