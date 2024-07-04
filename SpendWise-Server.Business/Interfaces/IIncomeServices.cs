using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;
using SpendWise_Server.Models.DTOs.IncomesDtos;

namespace SpendWise_Server.Business.Interfaces
{
    public interface IIncomeServices
    {
        Task CreateIncome(CreateIncomeDto incomeData);
        Task DeleteIncome(int id);
        Task UpdateIncome(IncomesDto categoryDto, int id);
        Task<List<Incomes>> GetAllIncome();
        Task<List<Incomes>> GetSingleIncomeByUserId(int userId);
    }
}
