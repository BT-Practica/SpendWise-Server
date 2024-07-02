using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;

namespace SpendWise_Server.Repos.Interfaces
{
    public interface IIncomeRepository
    {
        List<Incomes> GetIncomes();
        //get incomes by user id must be added
        Incomes GetIncomeByUserId(int userId);
        Task CreateIncome(IncomesDto incomesDto);
        Task UpdateIncome(int id, IncomesDto incomesDto);
        Task DeleteIncome(int id);
    }
}
