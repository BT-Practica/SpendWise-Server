using Microsoft.Extensions.Logging;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.EconomyDtos;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Business.Services
{
    public class EconomyService : IEconomyService
    {
        private readonly IEconomyRepository _economyRepository;
        public EconomyService(IEconomyRepository repo)
        {
            _economyRepository = repo;
        }

        public async Task CreateEconomy(EconomyDto economy)
        {
            if (economy == null) {
                throw new NullReferenceException("Economy is null");
            }
            await _economyRepository.AddEconomy(economy);
        }

        public async Task DeleteEconomy(int id)
        {
            if(id <= 0 || (_economyRepository.GetEconomy(id) == null))
            {
                throw new InvalidDataException("Invalid ID");
            }

            await _economyRepository.DeleteEconomy(id);
        }

        public List<Economies> GetAllEconomies()
        {
            List<Economies> economies = _economyRepository.GetAllEconomies();

            return economies;  
        }

        public Economies GetEconomy(int economyId)
        {
            if(economyId <= 0 || (_economyRepository.GetEconomy(economyId) == null)) {
                throw new InvalidDataException("Invalid ID");
            }

            Economies economy = _economyRepository.GetEconomy(economyId);
            
            return economy;
        }

        public async Task UpdateEcnomy(EconomyDto economy, int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Invalid ID");
            }
            if (economy == null)
            {
                throw new NullReferenceException("Economy is null");
            }

            await _economyRepository.UpdateEconomy(economy, id);
        }

    }
}
