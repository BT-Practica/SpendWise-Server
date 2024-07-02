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


        public Task CreateIncome(IncomesDto incomeDto)
        {
            return _repo.CreateIncome(incomeDto);
        }

        public Task DeleteIncome(int id)
        {
            throw new NotImplementedException();
        }

        public List<Income> GetAllIncome()
        {
            throw new NotImplementedException();
        }

        public Income GetSingleIncomeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIncome(IncomesDto categoryDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
