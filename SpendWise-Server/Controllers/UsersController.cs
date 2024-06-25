using Microsoft.AspNetCore.Mvc;

namespace SpendWise_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("GetUser/{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            return Ok();
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok();
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
}
