using Microsoft.AspNetCore.Mvc;
using AppleWatch_Notes_app.Auth;

namespace AuthController
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase

    {

        AccountService accountService = new AccountService();

        [HttpPost("register")]

        public IActionResult Register ([FromBody] string userName, string password)
          {
            accountService.Register(userName, password);
            return NoContent();
          }


        [HttpPost("login")]

        public IActionResult Login([FromBody] string userName, string password)
        {
            var token = accountService.Login(userName, password);
            return Ok(token);
        }
    }

}
