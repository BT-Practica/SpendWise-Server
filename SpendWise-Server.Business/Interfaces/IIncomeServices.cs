using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;

namespace SpendWise_Server.Business.Interfaces
{
    public interface IIncomeServices
    {
        Task CreateIncome(IncomesDto categoryDto);
        Task DeleteIncome(int id);
        Task UpdateIncome(IncomesDto categoryDto, int id);
        List<Incomes> GetAllIncome();
        Incomes GetSingleIncomeByUserId(int userId);
    }
}
