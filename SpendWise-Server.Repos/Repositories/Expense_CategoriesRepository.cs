using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpendWise_Server.Models.DTOs;
using SpendWise_Server.Models.Models;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Repos.Repositories;

public class Expense_CategoriesRepository : IExpense_CategoriesRepository
{
    private readonly DataContext _context;
    public Expense_CategoriesRepository(DataContext context)
    {
        _context = context;
    }
    public async Task AddExpenseCategory(Expense_CategoryDto newExpenseCategory)
    {
        var userToAdd = _context.Users.FirstOrDefault(u => u.Id == newExpenseCategory.UserId);
        var ExpenseToAdd = new Expense_Categories{
            Name = newExpenseCategory.Name
        };
        var user_Category = await _context.User_Categories.AddAsync(new User_Categories{
            Budget = 0,
            User = userToAdd,//userId can not be null, as user is already loged in
            Expense_Category = ExpenseToAdd   
        });
        _context.SaveChanges();

    }

    public async Task DeleteExpenseCategory(DeleteExpense_CategoryDto data)
    {
        var dataToDelete = await _context.User_Categories
        .Include(u => u.Expense_Category)
        .FirstOrDefaultAsync(u => u.UserId == data.UserId && u.Expense_CategoryId == data.ExpenseCategoryid );

        _context.User_Categories.Remove(dataToDelete);

        _context.SaveChanges();
    }

    public async Task<List<Expense_Categories>> getExpenseCategoriesByUserId(int userId)
    {
        var CategoriesList = await _context.User_Categories
        .Where(u => u.UserId == userId || u.UserId == 0).Select( u => u.Expense_Category).ToListAsync();

        return CategoriesList;
    }
    public async Task<bool> FindExpenseCategoryByNameAndUserId(Expense_CategoryDto data){
        var categoryToFind = await _context.User_Categories
        .Include(u => u.Expense_Category)
        .Where(u => u.UserId == data.UserId && u.Expense_Category.Name == data.Name)
        .AnyAsync()
        ;
        return categoryToFind;
    }
}