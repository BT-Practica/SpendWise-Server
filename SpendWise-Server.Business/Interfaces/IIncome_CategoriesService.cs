using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Income_CategoryDtos;

namespace SpendWise_Server.Business.Interfaces
{
    public interface IIncome_CategoriesService
    {
        void AddIncomeCategories(Income_CategoryDto categoryDto);
        void DeleteIncomeCategories(int id);
        void UpdateIncomeCategories(Income_CategoryDto categoryDto, int id);
        List<Income> GetAllIncomeCategories();
        Income GetSingleIncomeCategoryById(int id);
    }
}
