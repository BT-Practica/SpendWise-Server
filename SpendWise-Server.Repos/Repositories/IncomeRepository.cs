using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;
using SpendWise_Server.Models.DTOs.IncomesDtos;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Repos.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<IncomeRepository> _logger;

        public IncomeRepository(DataContext context, ILogger<IncomeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateIncome(CreateIncomeDto incomeData)
        {
            _logger.LogInformation($"Attempting to create income for user {incomeData.UserId}");

            var income = _context.Incomes
            .Include(i => i.Income_Category)
            .FirstOrDefault(u => u.Income_Category.Name == incomeData.Income_CategoryName && u.UserId == incomeData.UserId);
            if(income == null){
                throw new KeyNotFoundException("User does not have this Income Category");
            }

            income.Amount = incomeData.Amount;
            income.Description = incomeData.Description;
            income.RegistrationDate = DateTime.Now;
            income.Reccurence = incomeData.Reccurence;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteIncome(int id)
        {
            _logger.LogInformation($"Attempting to delete income {id}");

            var income = await _context.Incomes.FirstOrDefaultAsync(u => u.Id == id);
            if(income == null){
                throw new KeyNotFoundException($"Income with id: {id} is null");
            }

            income.Amount = 0;
            income.Description = "";
            income.RegistrationDate = null;
            income.Reccurence = false;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Incomes>> GetIncomes()
        {
            _logger.LogInformation("Fetching all incomes");
            return await _context.Incomes.ToListAsync();
        }

        public async Task<List<Incomes>> GetIncomeByUserId(int userid)// to verify if amount is 0
        {
            _logger.LogInformation($"Fetching incomes for user {userid}");

            var incomes = await _context.Incomes.Where(i => i.UserId == userid && i.Amount != 0).ToListAsync();
            if (incomes == null || incomes.Count == 0)
            {
                _logger.LogWarning("No incomes found for user {UserId}", userid);
                throw new KeyNotFoundException("The user doesn't have any incomes");
            }

            return incomes;
        }

        public async Task UpdateIncome(int id, IncomesDto incomesDto)
        {
            _logger.LogInformation($"Attempting to update income with id {id}.");

            var income = await _context.Incomes.FirstOrDefaultAsync(i => i.Id == id);
            if (income == null)
            {
                _logger.LogWarning($"Income with id {id} not found");
                throw new KeyNotFoundException("Income not found");
            }
            income.RegistrationDate = DateTime.Now;
            income.Description = incomesDto.Description;
            income.Reccurence = incomesDto.Reccurence;
            income.Amount = incomesDto.Amount;

            await _context.SaveChangesAsync();
        }
    }
}
