using Microsoft.Extensions.Logging;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Income_CategoryDtos;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Business.Services
{
    public class Income_CategoriesService : IIncome_CategoriesService
    {
        private readonly IIncome_CategoriesRepository _repo;
        private readonly ILogger<Income_CategoriesService> _logger;
        public Income_CategoriesService(IIncome_CategoriesRepository repo, ILogger<Income_CategoriesService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public List<Income_Categories> GetAllIncomeCategories()
        {
            _logger.LogInformation("You just fetched all income categories");
            return _repo.GetIncomeCategories();
        }

        public Income_Categories GetSingleIncomeCategoryById(int id)
        {
            _logger.LogInformation("You just fetch an income category");
            return _repo.GetIncomeCategoryById(id);
        }

        public void UpdateIncomeCategories(Income_CategoryDto categoryDto, int id)
        {
            _logger.LogInformation("You just fetch an income category");
            _repo.UpdateIncomeCategories(categoryDto, id);
        }
    }
}
