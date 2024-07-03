using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models.DTOs;
using SpendWise_Server.Models.Models;
using SpendWise_Server.Repos.Interfaces;
using SpendWise_Server.Repos.Repositories;

namespace SpendWise_Server.Business.Services
{
    public class Expense_CategoriesService : IExpense_CategoriesService
    {
        private readonly IExpense_CategoriesRepository _expense_CategortRepository;
        private readonly IUserRepository _userRepository;
        public Expense_CategoriesService(IExpense_CategoriesRepository expense_CategortRepository, IUserRepository userRepository)
        {
            _expense_CategortRepository = expense_CategortRepository;
            _userRepository = userRepository;
        }

        public async Task AddExpenseCategory(Expense_CategoryDto newExpenseCategory)
        {
            if(await _expense_CategortRepository.FindExpenseCategoryByNameAndUserId(newExpenseCategory)){
                throw new InvalidDataException("Expense category already exists");
            }
            await _expense_CategortRepository.AddExpenseCategory(newExpenseCategory);
        }

        public async Task DeleteExpenseCategory(DeleteExpense_CategoryDto deleteExpenseCategory)
        {
            if(await _userRepository.getUserById(deleteExpenseCategory.UserId) == null){
                throw new InvalidDataException("UserId does not exist.");
            }
            await _expense_CategortRepository.DeleteExpenseCategory(deleteExpenseCategory);
        }

        public async Task<List<Expense_Categories>> getExpenseCategoriesByUserId(int userId)
        {
            if(userId <= 0 || await _userRepository.getUserById(userId) == null ){
                throw new InvalidDataException("Invalid UserId");
            }
            return await _expense_CategortRepository.getExpenseCategoriesByUserId(userId);
        }
    }
}