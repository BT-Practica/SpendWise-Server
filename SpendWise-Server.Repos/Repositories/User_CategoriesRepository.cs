using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpendWise_Server.Models.DTOs;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Repos.Repositories
{
    public class User_CategoriesRepository : IUser_CategoriesRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<User_CategoriesRepository> _logger;

        public User_CategoriesRepository(DataContext context, ILogger<User_CategoriesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task UpdateBudgetForExpenseCategory(User_CategoriesDto data)
        {
            var user_category = await _context.User_Categories
            .Include(u => u.Expense_Category)
            .FirstOrDefaultAsync(u => u.Expense_CategoryId == data.ExpenseCategoryId && u.UserId == data.UserId);
            if(user_category == null){
                throw new KeyNotFoundException($"User with id: {data.UserId} has no expense: {await _context.Expense_Categories.FirstOrDefaultAsync(u => u.Id == data.ExpenseCategoryId)}");
            }
            user_category.Budget = data.Budget;

            await _context.SaveChangesAsync();
        }
    }
}