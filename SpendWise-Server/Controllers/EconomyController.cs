using Microsoft.AspNetCore.Mvc;
using SpendWise_Server.Business.Services;
using Serilog;
using SpendWise_Server.Models.DTOs.EconomyDtos;
using SpendWise_Server.Models;

namespace SpendWise_Server.Controllers;

public class EconomyController : ControllerBase
{
    private readonly EconomyService _economyService;

    public EconomyController(EconomyService economyService)
    {
        _economyService = economyService;
    }

    [HttpGet("GetEconomy")]
    public async Task<IActionResult> GetEconomy([FromQuery] int economyId)
    {
        try
        {
            Economies economy = _economyService.GetEconomy(economyId);
            if (economy == null)
            {
                Log.Error($"Economy with ID {economyId} not found.");
                return NotFound("Economy Not Found");
            }
            return Ok(economy);
        }
        catch (InvalidDataException e)
        {
            Log.Error($"Error in EconomyController.GetEconomy: {e.Message}");
            return BadRequest("Invalid data provided.");
        }
        catch (KeyNotFoundException e)
        {
            Log.Error($"Error in EconomyController.GetEconomy: {e.Message}");
            return NotFound("Economy Not Found");
        }
    }


    [HttpGet("GetEconomies")]
    public IActionResult GetEconomies()
    {
        try
        {
            List<Economies> economies = _economyService.GetAllEconomies();
            return Ok(economies);
        }
        catch (KeyNotFoundException e)
        {
            Log.Error($"Error in EconomyController.GetEconomies: {e.Message}");
            return NotFound("Economy Not Found");
        }
    }


    [HttpPost("AddEconomy")]
    public async Task<IActionResult> AddEconomy([FromBody] EconomyDto economy)
    {
        try
        {
            await _economyService.CreateEconomy(economy);
            Log.Information($"Economy {economy} added");
            return Ok("Economy added");
        }
        catch (NullReferenceException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("UpdateEconomy")]
    public async Task<IActionResult> UpdateEconomy(EconomyDto economy, int id)
    {
        try
        {
            await _economyService.UpdateEcnomy(economy, id);
            Log.Information($"Economy {economy} updated!");
            return Ok($"Economy added!");
        }
        catch (KeyNotFoundException e)
        {
            Log.Error($"Error in EconomyController.UpdateEconomy: {e.Message}");
            return NotFound($"Economy with ID {id} not found.");
        }
    }


    [HttpDelete("DeleteEconomy")]
    public async Task<IActionResult> DeleteEconomy(int id)
    {
        try
        {
            await _economyService.DeleteEconomy(id);
            Log.Information($"Economy deleted");
            return Ok($"Economy with ID {id} deleted!");
        }
        catch (KeyNotFoundException e)
        {
            Log.Error($"Error in EconomyController.DeleteEconomy: {e.Message}");
            return BadRequest(e.Message);
        }
    }
}