using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Income_CategoryDtos;

namespace SpendWise_Server.Repos.Interfaces
{
    public interface IIncome_CategoriesRepository
    {
        Income_Categories GetIncomeCategoryById(int id);
        List<Income_Categories> GetIncomeCategories();
        void AddIncomeCategories(Income_CategoryDto categoryDto);
        void UpdateIncomeCategories(Income_CategoryDto categoryDto, int id);
        void DeleteIncomeCategories(int id);
    }
}
