using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpendWise_Server.Models.DTOs.ExpensesDtos;
using SpendWise_Server.Models.Models;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Repos.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DataContext _context;
        public ExpenseRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Expenses> CreateExpense(CreateExpenseDTO expense)//DTO
        {
            Expenses newExpense = new Expenses()
            {
                Amount = expense.Amount,
                Description = expense.Description,
                UserId = expense.UserId,//where from userId come from???
                Expense_CategoryId = expense.Expense_CategoryId,
                CurrencyId = expense.CurrencyId
            };
            await _context.Expenses.AddAsync(newExpense);
            _context.SaveChanges();
            return newExpense;
        }
        public async Task DeleteExpense(RemoveExpenseDTO data)
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == data.ExpenseId);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Expenses> GetExpenseById(int id)
        {
            return await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<DisplayExpensesResponse>> GetExpensesByUserId(int userId)
        {
            return await _context.Expenses.Include(e => e.Expense_Category)
            .Where(e => e.UserId == userId)
            .Select(e => new DisplayExpensesResponse{
                Id = e.Id,
                Amount = e.Amount,
                Description = e.Description,
                Category = e.Expense_Category.Name
            })  
            .ToListAsync();
        }

    }
}