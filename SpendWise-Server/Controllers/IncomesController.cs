using Microsoft.AspNetCore.Mvc;
using Serilog;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;

namespace SpendWise_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        private readonly IIncomeServices _incomeServices;
        public IncomesController(IIncomeServices incomeServices)
        {
            _incomeServices = incomeServices;
        }

        [HttpGet("GetIncomeByUserId")]
        public async Task<ActionResult<List<Incomes>>> GetIncomeByUserId(int userId)
        {
            try
            {
                var incomes = await _incomeServices.GetSingleIncomeByUserId(userId);
                return Ok(incomes);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetIncomes")]
        public async Task<ActionResult<List<Incomes>>> GetIncomes()
        {
            var incomes = await _incomeServices.GetAllIncome();
            return Ok(incomes);
        }

        [HttpPost("CreateIncomes")]
        public async Task<IActionResult> CreateIncomes(IncomesDto incomes, int userId)
        {
            if (incomes == null)
            {
                Log.Error("The income is invalid");
                return BadRequest("Invalid income data");
            }

            try
            {
                await _incomeServices.CreateIncome(incomes, userId);
                return Ok("Income created successfully");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to create income");
                return StatusCode(500, "Failed to create income: " + ex.Message);
            }
        }



        [HttpPut("UpdateIncomes")]
        public async Task<IActionResult> UpdateIncomes(IncomesDto incomes, int id, int userId)
        {
            if (incomes == null)
            {
                Log.Error("The income is invalid");
                return BadRequest("Invalid income data");
            }

            try
            {
                await _incomeServices.UpdateIncome(incomes, id, userId);
                return Ok("Income updated successfully");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to update income");
                return StatusCode(500, "Failed to update income: " + ex.Message);
            }
        }

        [HttpDelete("DeleteIncomes")]
        public async Task<IActionResult> DeleteIncomes(int id)
        {
            try
            {
                await _incomeServices.DeleteIncome(id);
                return Ok("Income deleted successfully");
            }
            catch (ArgumentException ex)
            {
                Log.Warning(ex, "Income not found");
                return NotFound("Income not found");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to delete income");
                return StatusCode(500, "Failed to delete income: " + ex.Message);
            }
        }

    }
}
