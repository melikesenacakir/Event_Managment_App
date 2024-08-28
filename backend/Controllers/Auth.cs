using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.DTOs;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class Auth: ControllerBase
    {
        private readonly IAuthService _authService;
        public Auth(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO usersdto)
        {
            var users=usersdto.FromLoginDTO();
            var login = await _authService.LoginAsync(users);
            if (!login.Success)
            {
                return NotFound(login.Message);
            }
            return Ok(login.Message);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO usersdto)
        {
            var users=usersdto.FromRegisterDTO();
            var register = await _authService.RegisterAsync(users);
            if (!register.Success){
                    return NotFound(register.Message);
            }
            return Ok(register.Message);
        }
        
    }
}