using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models.DTOs.ExpensesDtos;
using SpendWise_Server.Models.Models;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Business.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUserRepository _userRepository;

        public ExpenseService(IExpenseRepository expenseRepository, IUserRepository userRepository)
        {
            _expenseRepository = expenseRepository;
            _userRepository = userRepository;
        }

        public async Task<Expenses> CreateExpense(CreateExpenseDTO expense)
        {
            if (expense == null)
            {
                throw new NullReferenceException("Expense is null");
            }
            return await _expenseRepository.CreateExpense(expense);
        }

        public async Task DeleteExpense(RemoveExpenseDTO data)
        {
            if (data.ExpenseId <= 0 || data.UserId <= 0 || await _expenseRepository.GetExpenseById(data.ExpenseId) == null || await _userRepository.getUserById(data.UserId) == null)
            {
                throw new InvalidDataException("Invalid ID");
            }
            await _expenseRepository.DeleteExpense(data);
        }

        public async Task<Expenses> GetExpenseById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Invalid ID");
            }
            Expenses expense = await _expenseRepository.GetExpenseById(id);
            if (expense == null)
            {
                throw new KeyNotFoundException("Expense not found");
            }
            return expense;
        }

        public async Task<IEnumerable<DisplayExpensesResponse>> GetExpensesByUserId(int userId)
        {
            if (userId <= 0)
            {
                throw new InvalidDataException("Invalid ID");
            }
            return await _expenseRepository.GetExpensesByUserId(userId);

        }
    }
}