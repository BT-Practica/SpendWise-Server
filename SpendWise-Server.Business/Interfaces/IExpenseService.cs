using SpendWise_Server.Models.DTOs.ExpensesDtos;
using SpendWise_Server.Models.Models;

namespace SpendWise_Server.Business.Interfaces;

public interface IExpenseService
{
    public Task<Expenses> GetExpenseById(int id);
    public Task<IEnumerable<DisplayExpensesResponse>> GetExpensesByUserId(int userId);
    public Task CreateExpense(CreateExpenseDTO expense);
    public Task DeleteExpense(RemoveExpenseDTO data);
}