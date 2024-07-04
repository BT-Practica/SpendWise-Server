using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Income_CategoryDtos;

namespace SpendWise_Server.Business.Interfaces
{
    public interface IIncome_CategoriesService
    {
        void UpdateIncomeCategories(Income_CategoryDto categoryDto, int id);
        List<Income_Categories> GetAllIncomeCategories();
        Income_Categories GetSingleIncomeCategoryById(int id);
    }
}
