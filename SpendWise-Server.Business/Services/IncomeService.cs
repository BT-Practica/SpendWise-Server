using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;
using SpendWise_Server.Models.DTOs.IncomesDtos;
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


        public async Task CreateIncome(CreateIncomeDto incomeData)
        {
            if(incomeData.Amount == 0){
                throw new InvalidDataException("Amount must not be null");
            }
            if(incomeData == null){
                throw new NullReferenceException("JSON data is null");
            }
            await _repo.CreateIncome(incomeData);
        }

        public async Task DeleteIncome(int id)
        {
            if(id <= 0 ){
                throw new InvalidDataException("Invalid ID");
            }
            await _repo.DeleteIncome(id);
        }

        public async Task<List<Incomes>> GetAllIncome()
        {
            return await _repo.GetIncomes();
        }

        public async Task<List<Incomes>> GetSingleIncomeByUserId(int userid)
        {
            return await _repo.GetIncomeByUserId(userid);
        }

        public async Task UpdateIncome(IncomesDto incomeData, int id)
        {
            if(id <= 0){
                throw new InvalidDataException("Invalid ID");
            }

            if (incomeData == null)
            {
                throw new InvalidDataException("JSON data is null");
            }
            await _repo.UpdateIncome(id, incomeData);
        }
    }
}
