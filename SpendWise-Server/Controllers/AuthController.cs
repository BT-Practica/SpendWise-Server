using System.Reflection.Metadata;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models.DTOs;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;
    public AuthController(ITokenService tokenService, IUserService userService)
    {
        _tokenService = tokenService;
        _userService = userService;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDTO user)
    {
        //In repo to add user in dbContext.done
        //to call UserService.AddUser.done
        //Username to be unique?.done
        try
        {
            _userService.createUser(user);
            Log.Information($"User:{user} created");
            return Ok();
        }
        catch (ArgumentException e)
        {
            Log.Error($"Eroare in AuthController.Register: {e.Message}");
            return BadRequest(e.Message);
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
    {
        //Validate user: in repo to find the user with same username and password.done
        //in business to verify uname,password; if user exists return jwt.done
        try
        {
            _userService.FindUserByUNameAndPass(user);
            return Ok(_tokenService.CreateToken(user.userName));
        }
        catch (KeyNotFoundException e)
        {
            Log.Error($"Eroare in AuthController.Login: {e.Message}");
            return NotFound("User not found");
        }
        catch (InvalidDataException e)
        {
            Log.Error($"Eroare in AuthController.Login: {e.Message}");
            return BadRequest("Wrong password");
        }
    }

    [Authorize]
    [HttpPost("")]
    public async Task<IActionResult> Dummy(){
        var a = this.HttpContext.User.Claims.Where(u => u.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
        return Ok(a);
    }
}
