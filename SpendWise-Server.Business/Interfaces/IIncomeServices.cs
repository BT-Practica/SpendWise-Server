using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;

namespace SpendWise_Server.Business.Interfaces
{
    public interface IIncomeServices
    {
        Task CreateIncome(IncomesDto categoryDto, int userId);
        Task DeleteIncome(int id);
        Task UpdateIncome(IncomesDto categoryDto, int id, int userId);
        Task<List<Incomes>> GetAllIncome();
        Task<List<Incomes>> GetSingleIncomeByUserId(int userId);
    }
}
