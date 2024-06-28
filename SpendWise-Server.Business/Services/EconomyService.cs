using Microsoft.Extensions.Logging;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Business.Services
{
    public class EconomyService : IEconomyService
    {
        private readonly IEconomyRepository _repo;
        private readonly ILogger _logger;
        public EconomyService(IEconomyRepository repo, ILogger logger)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task CreateEconomy(Economies economy)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEconomy(int id)
        {
            throw new NotImplementedException();
        }

        public List<Economies> GetAllEconomies()
        {
            throw new NotImplementedException();
        }

        public Economies GetEconomy(string economyId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEcnomy(Economies economy, int id)
        {
            throw new NotImplementedException();
        }
    }
}
