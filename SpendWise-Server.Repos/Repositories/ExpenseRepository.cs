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
        public void CreateExpense(CreateExpenseDTO expense)//DTO
        {
            Expenses newExpense = new Expenses()
            {
                Amount = expense.Amount,
                Description = expense.Description,
                UserId = expense.UserId,//where from userId come from???
                Expense_CategoryId = expense.Expense_CategoryId,
                CurrencyId = expense.CurrencyId
            };
            _context.Expenses.Add(newExpense);
            _context.SaveChanges();
        }
        public void DeleteExpense(int id)
        {
            var expense = _context.Expenses.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
        }

        public Expenses GetExpenseById(int id)
        {
            return _context.Expenses.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Expenses> GetExpensesByUserId(int userId)
        {
            return _context.Expenses.Where(e => e.UserId == userId).ToList();
        }
    }
}