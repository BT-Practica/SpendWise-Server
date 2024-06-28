using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SpendWise_Server.Business.Interfaces;

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
    [HttpGet("GetUser/{userId}")]
    public async Task<IActionResult> GetUser(int userId)
    {
        Log.Information("The log is working");
        try
        {
            var user = _userService.getUserById(userId);
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
            return NotFound();
        }
    }

    [HttpPut("UpdatePassword")]
    public async Task<IActionResult> UpdatePassword(int id,[FromBody] string password)
    {
        try{
            _userService.UpdatePassword(id, password);
            return Ok();
        }catch(InvalidDataException e){
            Log.Error($"Eroare in UsersController.UpdatePassword: {e.Message}");
            return BadRequest();
        }
    }

    [HttpPut("UpdateEmail")]
    public async Task<IActionResult> UpdateEmail(int id,[FromBody][EmailAddress] string email)
    {
        try{
            _userService.UpdateEmail(id, email);
            return Ok();
        }catch(InvalidDataException e){
            Log.Error($"Eroare in UsersController.UpdateEmail: {e.Message}");
            return BadRequest();
        }
    }

    [HttpPut("UpdateEmail")]
    public async Task<IActionResult> UpdateCurrency(int id, [FromBody]int CurrencyId)
    {
        try{
            _userService.UpdateCurrency(id, CurrencyId);
            return Ok();
        }catch(InvalidDataException e){
            Log.Error($"Eroare in UsersController.UpdateCurrency: {e.Message}");
            return BadRequest();
        }
    }

    [HttpDelete("RemoveUser")]
    public async Task<IActionResult> RemoveUser()
    {
        return Ok();
    }


}
