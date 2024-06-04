using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            return Ok(await _service.AuthService.LoginAsync(request));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto request)
        {
            return Ok(await _service.AuthService.RegisterAsync(request));
        }
    }
}