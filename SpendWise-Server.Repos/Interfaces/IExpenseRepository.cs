using SpendWise_Server.Models.DTOs.ExpensesDtos;
using SpendWise_Server.Models.Models;

namespace SpendWise_Server.Repos.Interfaces;

public interface IExpenseRepository
{
    public Task<Expenses> GetExpenseById(int id);
    public Task<IEnumerable<Expenses>> GetExpensesByUserId(int userId);
    public Task CreateExpense(CreateExpenseDTO expense);
    public Task DeleteExpense(RemoveExpenseDTO data);
}