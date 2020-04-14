using JWTOnNetCore.Models;
using JWTOnNetCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTOnNetCore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/auth")]
    public class AuthController: ControllerBase
    {
        private IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthForm auth)
        {
            var user = _service.Authenticate(auth.Username, auth.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}