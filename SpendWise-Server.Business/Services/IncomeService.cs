using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Business.Services
{
    public class IncomeService : IIncomeServices
    {
        private readonly IIncomeRepository _repo;
        public IncomeService(IIncomeRepository _repo)
        {
            this._repo = _repo;
        }


        public async Task CreateIncome(IncomesDto incomeDto)
        {
            await _repo.CreateIncome(incomeDto);
        }

        public async Task DeleteIncome(int id)
        {
            await _repo.DeleteIncome(id);
        }

        public List<Incomes> GetAllIncome()
        {
            return _repo.GetIncomes();
        }

        public Incomes GetSingleIncomeByUserId(int userid)
        {
            return _repo.GetIncomeByUserId(userid);
        }

        public async Task UpdateIncome(IncomesDto categoryDto, int id)
        {
            await _repo.UpdateIncome(id, categoryDto);
        }
    }
}
