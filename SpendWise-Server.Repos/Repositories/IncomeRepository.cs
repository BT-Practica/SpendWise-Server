using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;
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

        public async Task CreateIncome(IncomesDto incomesDto, int userid)
        {
            _logger.LogInformation("Attempting to create income for user {UserId}", userid);

            var checkIfUserIdExists = await _context.Users.AnyAsync(i => i.Id == userid);
            if (!checkIfUserIdExists)
            {
                _logger.LogWarning("User {UserId} does not exist", userid);
                throw new Exception("The user doesn't exist");
            }

            var income = new Incomes()
            {
                Description = incomesDto.Description,
                Reccurence = incomesDto.Reccurence,
                UserId = userid,
                Income_CategoryId = incomesDto.Income_CategoryId,
                RegistrationDate = DateTime.Now
            };

            await _context.Incomes.AddAsync(income);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                _logger.LogInformation("Income created successfully for user {UserId}", userid);
            }
            else
            {
                _logger.LogError("Failed to save income for user {UserId}", userid);
                throw new Exception("Failed to create income");
            }
        }

        public async Task DeleteIncome(int id)
        {
            _logger.LogInformation("Attempting to delete income with id {IncomeId}", id);

            var income = await _context.Incomes.FirstOrDefaultAsync(i => i.Id == id);
            if (income == null)
            {
                _logger.LogWarning("Income with id {IncomeId} not found", id);
                throw new Exception("Income not found");
            }

            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Income with id {IncomeId} deleted successfully", id);
        }

        public async Task<List<Incomes>> GetIncomes()
        {
            _logger.LogInformation("Fetching all incomes");
            return await _context.Incomes.ToListAsync();
        }

        public async Task<List<Incomes>> GetIncomeByUserId(int userid)
        {
            _logger.LogInformation("Fetching incomes for user {UserId}", userid);

            var incomes = await _context.Incomes.Where(i => i.UserId == userid).ToListAsync();
            if (incomes == null || incomes.Count == 0)
            {
                _logger.LogWarning("No incomes found for user {UserId}", userid);
                throw new Exception("The user doesn't have any incomes");
            }

            return incomes;
        }

        public async Task UpdateIncome(int id, IncomesDto incomesDto, int userid)
        {
            _logger.LogInformation("Attempting to update income with id {IncomeId} for user {UserId}", id, userid);

            var income = await _context.Incomes.FirstOrDefaultAsync(i => i.Id == id);
            if (income == null)
            {
                _logger.LogWarning("Income with id {IncomeId} not found", id);
                throw new Exception("Income not found");
            }

            var checkIfUserIdExists = await _context.Users.AnyAsync(i => i.Id == userid);
            if (!checkIfUserIdExists)
            {
                _logger.LogWarning("User {UserId} does not exist", userid);
                throw new Exception("The user doesn't exist");
            }

            income.Description = incomesDto.Description;
            income.Reccurence = incomesDto.Reccurence;
            income.UserId = userid;
            income.Income_CategoryId = incomesDto.Income_CategoryId;

            _context.Incomes.Update(income);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Income with id {IncomeId} updated successfully", id);
        }
    }
}
