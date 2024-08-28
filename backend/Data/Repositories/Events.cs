using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.DTOs;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class EventsRepository: IEventsRepository
    {
        private readonly ApplicationDB _db;
        
        public EventsRepository(ApplicationDB db)
        {
            _db = db;
        }

        public async Task<Events?> CreateEvent(Events events)
        {
            var updatedEvent=await _db.Users.FindAsync(events.Created_by);
            if(updatedEvent==null){
                return null;
            }
            await _db.Events.AddAsync(events);
            await _db.SaveChangesAsync();
            return events;
        }

       public async Task<User_Events> GetEvent(int id)
        {
            var q1 = await _db.Events
                      .Include(x=>x.Users)
                      .Where(x => x.Created_by == x.Users.ID && x.ID==id).ToListAsync(); //bununla inner join oluyor
            var newUserEvents=q1.FirstOrDefault();
            if (newUserEvents==null)
            {
                return null;
            }
            var newEvent=new Events{
                Title=newUserEvents.Title,
                Description=newUserEvents.Description,
                Date=newUserEvents.Date,
                Time=newUserEvents.Time,
                Location=newUserEvents.Location,
                Image=newUserEvents.Image,
                Quoata=newUserEvents.Quoata
            };
            var userEvents=new User_Events{
                User_Name=newUserEvents.Users.Name,
                Event=newEvent,
            };
        
            return userEvents;
        }
        public async Task<List<Events>> GetEvents()
        {
             return await _db.Events.ToListAsync();
        }

        public async Task<List<Events>?> UpdateEvent(Events events,int id)
        {
            var updatedEvent=await _db.Events.FindAsync(id);
            if(updatedEvent==null){
                return null;
            }
            updatedEvent.Title=events.Title;
            updatedEvent.Description=events.Description;
            updatedEvent.Date=events.Date;
            updatedEvent.Time=events.Time;
            updatedEvent.Location=events.Location;
            updatedEvent.Image=events.Image;
            updatedEvent.Quoata=events.Quoata;

            _db.Events.Update(updatedEvent);
            _db.SaveChanges();
            return await _db.Events.ToListAsync();
        }
    }
}