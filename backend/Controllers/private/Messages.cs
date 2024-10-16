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
    [Route("api/private/messages")]
    public class Messages : ControllerBase
    {
        private readonly IMessagesService _messagesService;
        public Messages(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _messagesService.GetMessagesAsync();
            if (messages == null)
            {
                return NotFound(messages?.Message);
            }
            return Ok(messages.Data.ToMessageDTO());
        }

        [HttpPost("{event_id}/{user_id}")]
        public async Task<IActionResult> CreateMessage([FromBody] CreateMessagesDTO messagedto, [FromRoute] Guid user_id, [FromRoute] int event_id)
        {
            var create = await _messagesService.CreateMessageAsync(messagedto.FromMessageDTO(), user_id, event_id);
            if (!create.Success)
            {
                return NotFound(create.Message);
            }
            return Ok(create.Message);
        }
    }
}