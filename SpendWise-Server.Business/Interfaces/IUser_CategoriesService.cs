using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpendWise_Server.Models.DTOs;

namespace SpendWise_Server.Business.Interfaces
{
    public interface IUser_CategoriesService
    {
        public Task UpdateBudgetForExpenseCategory(User_CategoriesDto data);
    }
}