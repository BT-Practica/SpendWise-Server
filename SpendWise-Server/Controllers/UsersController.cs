using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.UserDtos;

namespace SpendWise_Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUser([FromQuery]int userId)
    {
        Log.Information("The log is working");
        try
        {
            User user = await _userService.getUserById(userId);
            return Ok(user);
        }
        catch (InvalidDataException e)
        {
            Log.Error($"Eroare in UsersController.GetUser: {e.Message}");
            return BadRequest();
        }
        catch (KeyNotFoundException e)
        {
            Log.Error($"Eroare in UsersController.GetUser: {e.Message}");
            return NotFound("User Not Found");
        }
    }

    [HttpPut("UpdatePassword")]
    public async Task<IActionResult> UpdatePassword([FromBody]ChangeUPassEmailDTO userData)//to use ChangeUPasswwordDTo
    {
        try{
            _userService.UpdatePassword(userData.id, userData.data);
            return Ok("Password Updated");
        }catch(InvalidDataException e){
            Log.Error($"Eroare in UsersController.UpdatePassword: {e.Message}");
            return BadRequest(e.Message);
        }
    }

    [HttpPut("UpdateEmail")]
    public async Task<IActionResult> UpdateEmail([FromBody]ChangeUPassEmailDTO userData)
    {
        try{
            _userService.UpdateEmail(userData.id, userData.data);
            return Ok("Email Updated");
        }catch(InvalidDataException e){
            Log.Error($"Eroare in UsersController.UpdateEmail: {e.Message}");
            return BadRequest(e.Message);
        }
    }

    [HttpPut("UpdateCurrency")]
    public async Task<IActionResult> UpdateCurrency([FromBody]ChangeUserCurrencyDTO userData)
    {
        try{
            await _userService.UpdateCurrency(userData.id, userData.currencyId);
            return Ok("Currency Updated");
        }catch(InvalidDataException e){
            Log.Error($"Eroare in UsersController.UpdateCurrency: {e.Message}");
            return BadRequest();
        }
    }

    [HttpDelete("RemoveUser")]
    public async Task<IActionResult> RemoveUser(int id)
    {
        _userService.deleteUser(id);
        return Ok();
    }


}
