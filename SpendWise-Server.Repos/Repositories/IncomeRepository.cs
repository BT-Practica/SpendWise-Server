using Microsoft.EntityFrameworkCore;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Repos.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly DataContext _context;
        public IncomeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateIncome(IncomesDto incomesDto)
        {
            Incomes income = new Incomes()
            {
                Description = incomesDto.Description,
                Reccurence = incomesDto.Reccurence,
                UserId = incomesDto.UserId,
                Income_CategoryId = incomesDto.Income_CategoryId,
                RegistrationDate = DateTime.Now
            };
            await _context.AddAsync(income);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIncome(int id)
        {
            var income = await _context.Incomes.FirstOrDefaultAsync(i => i.Id == id);
            _context.Incomes.Remove(income);
            _context.SaveChanges();
        }

        public List<Incomes> GetIncomes()
        {
            var incomes = _context.Incomes.AsNoTracking().ToList();
            return incomes;
        }

        public Incomes GetIncomeByUserId(int userid)
        {
            var income = _context.Incomes.FirstOrDefault(i => i.UserId == userid);
            return income;
        }

        public async Task UpdateIncome(int id, IncomesDto incomesDto)
        {
            var income = await _context.Incomes.FirstOrDefaultAsync(i => i.Id == id);

            income.Description = incomesDto.Description;
            income.Reccurence = incomesDto.Reccurence;
            income.UserId = incomesDto.UserId;
            income.Income_CategoryId = incomesDto.Income_CategoryId;
            /*            income.RegistrationDate = DateTime.Now;*/

            await _context.AddAsync(income);
            await _context.SaveChangesAsync();
        }
    }
}
