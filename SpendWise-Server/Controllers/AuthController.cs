using Microsoft.AspNetCore.Mvc;
using SpendWise_Server.Models.DTOs;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    public AuthController(ITokenService tokenService){
        _tokenService = tokenService;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDTO user)
    {
        //In repo to add user in dbContext
        return Ok();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserRegisterDTO user) 
    {
        //in repo to find the user with same username and password; in business to verify if user exists or not
        return Ok(_tokenService.CreateToken(user.username, user.email));
    }
}
