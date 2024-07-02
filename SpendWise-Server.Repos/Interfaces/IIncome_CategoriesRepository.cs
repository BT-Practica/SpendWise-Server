using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Income_CategoryDtos;

namespace SpendWise_Server.Repos.Interfaces
{
    public interface IIncome_CategoriesRepository
    {
        Income GetIncomeCategoryById(int id);
        List<Income> GetIncomeCategories();
        void AddIncomeCategories(IncomeDto categoryDto);
        void UpdateIncomeCategories(IncomeDto categoryDto, int id);
        void DeleteIncomeCategories(int id);
    }
}
