using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models.DTOs;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Business.Services
{
    public class User_CategoriesService : IUser_CategoriesService
    {
        private readonly IUser_CategoriesRepository _userCategoriesRepo;
        public User_CategoriesService(IUser_CategoriesRepository userCategoriesRepo){
            _userCategoriesRepo = userCategoriesRepo;
        }
        public async Task UpdateBudgetForExpenseCategory(User_CategoriesDto data)
        {
            if(data.UserId <= 0 || data.ExpenseCategoryId <= 0 ){
                throw new InvalidDataException("Invalid ID");
            }
            if(data.Budget < 0){
                throw new InvalidDataException("Budget can't be negative");
            }
            await _userCategoriesRepo.UpdateBudgetForExpenseCategory(data);
        }
    }
}