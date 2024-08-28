using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.DTOs;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/private/users")]
    public class Users : ControllerBase
    {
       // private readonly IUsersRepository _usersRepo;
        private readonly IUsersService _usersService;
        public Users(IUsersService usersService)
        {
           // _usersRepo = usersRepo;
            _usersService = usersService;
        }

        


        [HttpGet("{user_id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid user_id)
        {
            var user = await _usersService.GetUserAsync(user_id);
            if (!user.Success)
            {
                return NotFound(user.Message);
            }
            return Ok(user.Data?.ToUsersDTO());
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _usersService.GetUsersAsync();
            var userDTO = users.Data?.Select(x=>x.ToUsersDTO()).ToList();
            return Ok(userDTO);
        }

        [HttpPut("{user_id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateDTO updateDTO, [FromRoute] Guid user_id)
        {
            var confirmPassword = updateDTO.ConfirmPassword;
            var update = await _usersService.UpdateUserAsync(user_id, updateDTO.FromUpdateDTO(), confirmPassword);
            if (update != null && !update.Success)
            {
                return NotFound(update.Message);
            }
            return Ok(update?.Message);
        }

    }
}
