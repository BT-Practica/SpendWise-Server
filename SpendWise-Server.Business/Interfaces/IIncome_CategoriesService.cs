using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Income_CategoryDtos;

namespace SpendWise_Server.Business.Interfaces
{
    public interface IIncome_CategoriesService
    {
        void AddIncomeCategories(IncomeDto categoryDto);
        void DeleteIncomeCategories(int id);
        void UpdateIncomeCategories(IncomeDto categoryDto, int id);
        List<Income> GetAllIncomeCategories();
        Income GetSingleIncomeCategoryById(int id);
    }
}
