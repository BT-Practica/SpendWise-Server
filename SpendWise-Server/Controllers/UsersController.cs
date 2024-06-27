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

    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUser() //dto
    {
        //model
        return Ok();
    }

    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser()
    {
        return Ok();
    }

    [HttpDelete("RemoveUser")]
    public async Task<IActionResult> RemoveUser()
    {
        return Ok();
    }


}
