using Microsoft.AspNetCore.Mvc;

namespace SpendWise_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register() //dto user,,,
        {
            // user din models
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login() //dto login
        {
            // user din models
            return Ok();
        }
    }
}
