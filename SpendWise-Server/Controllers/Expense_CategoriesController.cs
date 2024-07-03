using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models.DTOs;

namespace SpendWise_Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Expense_CategoriesController : ControllerBase
{
    private readonly IExpense_CategoriesService _expense_CategoriesService;
    public Expense_CategoriesController(IExpense_CategoriesService expense_CategoriesService){
        _expense_CategoriesService = expense_CategoriesService;
    }

    [HttpGet("GetExpenses")]
    public async Task<IActionResult> GetExpense_CategoryByUserId(int userId){
        return Ok(await _expense_CategoriesService.getExpenseCategoriesByUserId(userId));
    }
    [HttpPost("AddExpense_Category")]
    public async Task<IActionResult> AddExpenseCategoryToUser(Expense_CategoryDto expensecategory){
        try{
            await _expense_CategoriesService.AddExpenseCategory(expensecategory);
            return Ok();
        }catch(InvalidDataException e){
            return BadRequest( new {e.Message});
        }
    }
    [HttpDelete("DeleteExpense_Category")]
    public async Task<IActionResult> DeleteExpenseCategory(DeleteExpense_CategoryDto deleteExpenseCategoryDto){
        try{
            await _expense_CategoriesService.DeleteExpenseCategory(deleteExpenseCategoryDto);
            return Ok();
        }catch(InvalidDataException e){
            return BadRequest(new {e.Message});
        }
    }
    
}