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

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public void CreateExpense(CreateExpenseDTO expense)
        {
            if (expense == null)
            {
                throw new NullReferenceException("Expense is null");
            }
            _expenseRepository.CreateExpense(expense);
        }

        public void DeleteExpense(int id)
        {
            if (id <= 0 || _expenseRepository.GetExpenseById(id) == null)
            {
                throw new InvalidDataException("Invalid ID");
            }
            _expenseRepository.DeleteExpense(id);
        }

        public Expenses GetExpenseById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Invalid ID");
            }
            Expenses expense = _expenseRepository.GetExpenseById(id);
            if (expense == null)
            {
                throw new KeyNotFoundException("Expense not found");
            }
            return expense;
        }

        public IEnumerable<Expenses> GetExpensesByUserId(int userId)
        {
            if (userId <= 0)
            {
                throw new InvalidDataException("Invalid ID");
            }
            return _expenseRepository.GetExpensesByUserId(userId);

        }
    }
}