using System;
using JWTOnNetCore.Models;
using JWTOnNetCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTOnNetCore.Controllers
{
    [Route("/api")]
    [ApiController]
    [Authorize]
    public class HomeController: ControllerBase
    {
        private readonly IUserService _service;

        public HomeController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Greetings()
        {
            var message = new SimpleMessage()
            {
                By = "System",
                Message = "Welcome",
                DateTime = DateTime.Now
            };
            return Ok(message);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("private")]
        public IActionResult Secret()
        {
            return Ok(_service.FindAll());
        }

        [AllowAnonymous]
        [HttpGet("public")]
        public IActionResult Public()
        {
            return Ok("Public");
        }
        
    }
}