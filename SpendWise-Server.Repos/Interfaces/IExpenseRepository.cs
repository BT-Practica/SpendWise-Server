using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using SpendWise_Server.Models.DTOs.ExpensesDtos;
using SpendWise_Server.Models.Models;

namespace SpendWise_Server.Repos.Interfaces;

public interface IExpenseRepository
{
    public Expenses GetExpenseById(int id);
    public IEnumerable<Expenses> GetExpensesByUserId(int userId);
    public void CreateExpense(CreateExpenseDTO expense);
    public void DeleteExpense(int id);
}