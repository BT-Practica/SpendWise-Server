using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models.DTOs.ExpensesDtos;
using SpendWise_Server.Models.Models;

namespace SpendWise_Server.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _expenseService;

    public ExpensesController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [HttpGet("GetExpense")]
    public async Task<IActionResult> GetExpense([FromQuery] int expenseId)
    {
        try
        {
            Expenses expense = await _expenseService.GetExpenseById(expenseId);
            return Ok(expense);
        }
        catch (InvalidDataException e)
        {
            Log.Error($"Eroare in ExpensesController.GetExpenseById: {e.Message}");
            return BadRequest();
        }
        catch (KeyNotFoundException e)
        {
            Log.Error($"Eroare in ExpensesController.GetExpenseById: {e.Message}");
            return NotFound("Expense Not Found");
        }
    }
    [HttpGet("GetExpenseByUserId")]
    public async Task<ActionResult<IEnumerable<DisplayExpensesResponse>>> GetExpensesByUserId(int userId)
    {
        try
        {
            var expenses = await _expenseService.GetExpensesByUserId(userId);
            return Ok(expenses);
        }
        catch (InvalidDataException e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPost("AddExpense")]
    public async Task<IActionResult> AddExpense(CreateExpenseDTO expense)
    {
        try
        {
            Log.Information($"Expense {expense} added");
            return Ok(await _expenseService.CreateExpense(expense));
        }
        catch (NullReferenceException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("RemoveExpense")]
    public async Task<IActionResult> RemoveExpense([FromBody]RemoveExpenseDTO data)
    {
        try
        {
            await _expenseService.DeleteExpense(data);
            return Ok();
        }
        catch (InvalidDataException e)
        {
            Log.Error($"Eroare in ExpensesController.DeleteExpense: {e.Message}");
            return NotFound("Expense Not Found");
        }
    }


}