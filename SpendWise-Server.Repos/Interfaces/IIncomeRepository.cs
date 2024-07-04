using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;
using SpendWise_Server.Models.DTOs.IncomesDtos;

namespace SpendWise_Server.Repos.Interfaces
{
    public interface IIncomeRepository
    {
        Task<List<Incomes>> GetIncomes();
        Task<List<Incomes>> GetIncomeByUserId(int userid);
        Task CreateIncome(CreateIncomeDto incomeData);
        Task UpdateIncome(int id, IncomesDto incomesDto);
        Task DeleteIncome(int id);
    }
}
