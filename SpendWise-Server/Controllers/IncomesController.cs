using Microsoft.AspNetCore.Mvc;
using Serilog;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Incomes;
using SpendWise_Server.Models.DTOs.IncomesDtos;

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
            catch (KeyNotFoundException ex)
            {
                return NotFound(new {ex.Message});
            }
        }

        [HttpPost("CreateIncomes")]
        public async Task<IActionResult> CreateIncomes(CreateIncomeDto incomeData)
        {
            try
            {
                await _incomeServices.CreateIncome(incomeData);
                return Ok("Income created successfully");
            }
            catch (NullReferenceException e)
            {
                Log.Error(e.Message);
                return BadRequest(new {e.Message});
            }catch(InvalidDataException e){
                Log.Error(e.Message);
                return BadRequest(new {e.Message});
            }

        }



        [HttpPut("UpdateIncomes")]
        public async Task<IActionResult> UpdateIncomes(IncomesDto incomes, int id)
        {

            try
            {
                await _incomeServices.UpdateIncome(incomes, id);
                return Ok("Income updated successfully");
            }
            catch (InvalidDataException e)
            {
                Log.Error("Failed to update income");
                return BadRequest(new {e.Message});
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
            catch (InvalidDataException e)
            {
                Log.Warning($"Error in IncomesController.DeleteIncomes {e.Message}");
                return NotFound(new {e.Message});
            }
            catch (KeyNotFoundException e)
            {
                Log.Error("Failed to delete income");
                return NotFound(new {e.Message});
            }
        }

    }
}
