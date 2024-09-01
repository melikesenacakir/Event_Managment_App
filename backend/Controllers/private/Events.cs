using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.DTOs;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("api/private/events")]

    public class Events : ControllerBase
    {
        private readonly IEventsService _eventsService;
        public Events(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        /// <summary>returns all events </summary>
        [HttpGet]
        public async Task<IActionResult> GetEvents(){
            var events= await _eventsService.GetEventsAsync();
            if(events==null){
                return NotFound(events?.Message);
            }
            return Ok(events.Data?.GetEventsDTO());
        }

         /// <summary>returns events by id </summary>
        [HttpGet("{event_id}")] 
        public async Task<IActionResult> GetEvent([FromRoute]int event_id){
           var events= await _eventsService.GetEventAsync(event_id);
            if(!events.Success){
                return NotFound(events?.Message);
            }
            return Ok(events.Data?.ToUserEventsDTO());
        }

        /// <summary>Creates an event </summary>
        [HttpPost("{user_id}")]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDTO eventsdto, [FromRoute]Guid user_id){
            var create=await _eventsService.CreateEventAsync(eventsdto.FromEventsDTO(user_id));
            if(!create.Success){
                return NotFound(create.Message);
            }
            return Ok(create.Message);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventDTO eventsdto, [FromRoute]int id){
            var update=await _eventsService.UpdateEventAsync(eventsdto.FromUpdateEventDTO(),id);
            if(!update.Success){
                return NotFound(update.Message);
            }
            return Ok(update.Message);
        }

           [HttpGet("user/{user_id}")]
        public async Task<IActionResult> GetUserEvents([FromRoute]Guid user_id){ //get events that user created
            var events=await _eventsService.GetEventsCreatedByUserAsync(user_id);
            if(events.Data==null){
                return NotFound(events.Message);
            }
            return Ok(events.Data?.ToUserCreatedEventsDTO());
           
        }
        
        [HttpGet("attended/{id}")]
        public async Task<IActionResult> AttendedEvents([FromRoute]int id){ //get users that attended events //burdaki id sonradan session ya da jwtden alınacaktır
            var events=await _eventsService.GetEventsByUserParticipatedAsync(id);
            if(events.Data==null){
                return NotFound(events.Message);
            }
            return Ok(events.Data?.ToAttendedEventsDTO());
        }

        [HttpPost("participate/{event_id}")]
        public async Task<IActionResult> ParticipateEvent([FromRoute]int event_id,[FromBody] Joined_Events joined_Events){
            var participate=await _eventsService.ParticipateEventAsync(event_id,joined_Events);
            return Ok(participate.Message);
        }
    }
}
