using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/events")]

    public class Events: ControllerBase
    {
        private readonly ApplicationDB _db;
        public Events(ApplicationDB db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents(){
            return Ok(_db.Events.Select(x=>x.ToEventsDTO()).ToList());
        }

        [HttpGet("{event_id}")] //returns events by id
        public async Task<IActionResult> GetEvent([FromRoute]int event_id){
            var events= await _db.Events.FindAsync(event_id); //searches via primary key
            if(events==null){
                return NotFound();
            }
            return Ok(events.ToEventsDTO());
        }
        [HttpGet("user/{user_id}")]
        public async Task<IActionResult> GetUserEvents([FromRoute]Guid user_id){ //get events that user created
            var events=await _db.Events.Where(x=>x.Created_by==user_id).ToListAsync();
            if(events==null){
                return NotFound();
            }
            return Ok(events.Select(x=>x.ToEventsDTO()).ToList());
        }

        [HttpGet("attended/{id}")]
        public async Task<IActionResult> AttendedEvents([FromRoute]Guid id){ //get users that attended events //burdaki id sonradan session ya da jwtden alınacaktır
            var events=await _db.User_Events.Where(x=>x.User_id==id).ToListAsync();
            if(events==null){
                return NotFound();
            }
            return Ok(events.Select(x=>x.ToUserEventsDTO()).ToList());
        }
    }
}
