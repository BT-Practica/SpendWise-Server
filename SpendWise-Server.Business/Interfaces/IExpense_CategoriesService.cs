using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpendWise_Server.Models.DTOs;
using SpendWise_Server.Models.Models;

namespace SpendWise_Server.Business.Interfaces;

public interface IExpense_CategoriesService
{
    public Task<List<Expense_Categories>> getExpenseCategoriesByUserId(int userId);
    public Task AddExpenseCategory(Expense_CategoryDto newExpenseCategory);
    public Task DeleteExpenseCategory(DeleteExpense_CategoryDto deleteExpenseCategory);
    
}