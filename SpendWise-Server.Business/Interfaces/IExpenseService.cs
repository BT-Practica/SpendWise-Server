using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpendWise_Server.Models.DTOs.ExpensesDtos;
using SpendWise_Server.Models.Models;

namespace SpendWise_Server.Business.Interfaces;

public interface IExpenseService
{
    public Expenses GetExpenseById(int id);
    public IEnumerable<Expenses> GetExpensesByUserId(int userId);
    public void CreateExpense(CreateExpenseDTO expense);
    public void DeleteExpense(int id);
}