﻿using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;
using SpendWise_Server.Models.DTOs.IncomesDtos;

namespace SpendWise_Server.Repos.Interfaces
{
    public interface IIncomeRepository
    {
        Task<List<Incomes>> GetIncomes();
        //get incomes by user id must be added
        Task<List<Incomes>> GetIncomeByUserId(int userid);
        Task CreateIncome(CreateIncomeDto incomeData);
        Task UpdateIncome(int id, IncomesDto incomesDto, int userid);
        Task DeleteIncome(int id);
    }
}
