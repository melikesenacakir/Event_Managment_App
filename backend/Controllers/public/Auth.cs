using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using backend.Database;
using backend.DTOs;
using backend.Interfaces;
using backend.Mappers;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/public/auth")]
    public class Auth: ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly IMiddlewareService _middlewareService;
        private readonly IConfiguration _configuration;
        private static readonly Dictionary<Guid, (string Token, DateTime Expiry)> UserTokens = new Dictionary<Guid, (string Token, DateTime Expiry)>();

        public Auth(IAuthService authService, IConfiguration configuration, IMiddlewareService middlewareService)
        {
            _authService = authService;
            _configuration=configuration;
            _middlewareService=middlewareService;
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

            var userID = Guid.Parse(login.Data.ID.ToString());

            var checkExpired = _middlewareService._CheckExpired(userID);
            if (checkExpired != "")
            {
                return Ok(new { token = checkExpired, login.Message });
            }

            var tokenValue = _middlewareService.GenerateToken(login.Data, userID);
            
            return Ok(new {token=tokenValue,login.Message});
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