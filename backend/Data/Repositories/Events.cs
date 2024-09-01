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

        public async Task<List<User_Events>> GetEventsCreatedByUser(Guid id)
        {
            var userEventsList=new List<User_Events>();
            var q1 = await _db.Events
                      .Include(x=>x.Users)
                      .Where(x => x.Created_by==id ).ToListAsync(); //bununla inner join oluyor
                      

            for (int i = 0; i < q1.Count; i++)
            {
                var newUserEvents=q1[i];
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
                    Event=newEvent,
                    User_Name=newUserEvents.Users.Name,
                };
                userEventsList.Add(userEvents);
            }
            return userEventsList;
        }

        public async Task<List<User_Events?>> GetEventsByUserParticipated(int id)
        {
            var q1 = await _db.User_Events
                            .Include(x => x.Users)
                            .Where(x => x.Event_id == id && x.User_id == x.Users.ID)
                            .ToListAsync();
            var events = await _db.Events
                            .Where(x => x.ID == id)
                            .ToListAsync();

            var userEventsList = new List<User_Events?>();
            if (q1.Count > 0 && events.Count > 0)
            {
                foreach (var userEvent in q1)
                {
                    var newUserEvents = new User_Events
                    {
                        Event_id = userEvent.Event_id,
                        Event = events[0],
                        Users = userEvent.Users,
                    };
                    userEventsList.Add(newUserEvents);
                }
            }

            return userEventsList;
        }
        public async Task<List<User_Events>?> ParticipateEvent(int id, Joined_Events joined)
        {
            if (joined.Email == null || joined.User_Name == null || joined.Surname == null || joined.Enrollment == 0)
            {
                return null;
            }
            var user_id = await _db.Users
                                .Where(x => x.Email == joined.Email)
                                .Select(x => x.ID)
                                .FirstOrDefaultAsync();
            if (user_id == Guid.Empty)
            {
                return null;
            }

            var newUserEvent = new User_Events
            {
                Event_id = id,
                User_id = user_id,
            };

            var events = await _db.Events
                                .Where(x => x.ID == id)
                                .ToListAsync();
            if (events.Count == 0)
            {
                return null;
            }

            var eventToUpdate = events[0];
            if (int.TryParse(eventToUpdate.Quoata, out int currentQuota))
            {
                eventToUpdate.Quoata = (currentQuota - joined.Enrollment).ToString();
            }
            else
            {
                Console.WriteLine("Invalid Quoata value.");
                return null;
            }

            await _db.User_Events.AddAsync(newUserEvent);
            _db.Events.Update(eventToUpdate); 
            await _db.SaveChangesAsync();
            return new List<User_Events> { newUserEvent };
        }
    }
}