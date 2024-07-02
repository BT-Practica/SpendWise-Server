using Microsoft.AspNetCore.Mvc;
using Serilog;
using SpendWise_Server.Business.Interfaces;
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
        public IActionResult GetIncomeById(int userid)
        {
            var incomes = _incomeServices.GetSingleIncomeByUserId(userid);
            return Ok(incomes);
        }

        [HttpGet("GetIncomes")]
        public IActionResult GetIncomes()
        {
            var incomes = _incomeServices.GetAllIncome(); ;
            return Ok(incomes);
        }

        [HttpPost("CreateIncomes")]
        public async Task<IActionResult> CreateIncomes(IncomesDto incomes)
        {
            if (incomes == null)
            {
                Log.Error("The income is invalid");
            }
            var incomeCreate = _incomeServices.CreateIncome(incomes);
            return Ok(incomes);
        }

        [HttpPut("UpdateIncomes")]
        public async Task<IActionResult> UpdateIncomes(IncomesDto incomes, int id)
        {
            if (incomes == null)
            {
                Log.Error("The income is invalid");
            }
            var incomeUpdate = _incomeServices.UpdateIncome(incomes, id);
            return Ok(incomeUpdate);
        }

        [HttpDelete("DeleteIncomes")]
        public async Task<IActionResult> DeleteIncomes(int id)
        {
            var incomes = _incomeServices.DeleteIncome(id);
            if (incomes == null)
            {
                Log.Error("Can`t delete the income because is null");
            }
            return Ok(incomes);
        }
    }
}
