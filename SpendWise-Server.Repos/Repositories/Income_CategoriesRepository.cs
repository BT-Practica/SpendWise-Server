using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Income_CategoryDtos;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Repos.Repositories
{
    public class Income_CategoriesRepository : IIncome_CategoriesRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<Income_CategoriesRepository> _logger;
        public Income_CategoriesRepository(DataContext context, ILogger<Income_CategoriesRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        
        public List<Income_Categories> GetIncomeCategories()
        {
            List<Income_Categories> categories = _context.Income_Categories
            .AsNoTracking().ToList();
            return categories;

        }

        public Income_Categories GetIncomeCategoryById(int id)
        {
            Income_Categories? incomeCat = _context.Income_Categories.AsNoTracking().FirstOrDefault(i => i.Id == id);
            if (incomeCat != null)
            {
                _logger.LogError("The income category dosent exist");
            }

            return incomeCat;
        }

        public void UpdateIncomeCategories(Income_CategoryDto categoryDto, int id)
        {
            var incomeCat = _context.Income_Categories.FirstOrDefault(i => i.Id == id);
            if (incomeCat != null)
            {
                _logger.LogError("The income category dosent exist");
            }
            incomeCat.Name = categoryDto.Name;

            _context.Income_Categories.Update(incomeCat);
            _context.SaveChanges();
        }
    }
}
