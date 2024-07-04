using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models.DTOs;

namespace SpendWise_Server.Controllers
{
    public class User_CategoriesController : ControllerBase
    {
        private readonly IUser_CategoriesService _userCategoriesService;
        public User_CategoriesController(IUser_CategoriesService userCategoriesService){
            _userCategoriesService = userCategoriesService;
        }
        [HttpPut("UpdateCategoryBudget")]
        public async Task<IActionResult> updateCategoryBudget(User_CategoriesDto data){
            try{
                await _userCategoriesService.UpdateBudgetForExpenseCategory(data);
                return Ok();
            }catch(KeyNotFoundException e){
                Log.Error(e.Message);
                return NotFound(new {e.Message});
            }catch(InvalidDataException e){
                Log.Error(e.Message);
                return BadRequest(new {e.Message});
            }
        }
    }
}