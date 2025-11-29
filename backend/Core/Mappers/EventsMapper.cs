using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Entities;

namespace Core.Mappers
{
    public static class EventsMapper
    {

        public static EventsDTO ToEventsDTO(this Events events){
            return new EventsDTO{
                ID=events.ID,
                Title=events.Title,
                Description=events.Description,
                Date=events.Date,
                Time=events.Time,
                Location=events.Location,
                Image=events.Image,
                Quoata=events.Quoata,
                Created_by=events.Created_by
            };
        }

        public static CreatedByDto ToCreatedByDto(this Users created_by){
            return new CreatedByDto{
                Name=created_by.Name
            };
        }
        public static List<UserEventsDTO> ToUserEventsDTO(this User_Events userEvents){
            var newEvents=userEvents.Event.ToEventDTO();
            var events=new List<UserEventsDTO>{
                new UserEventsDTO {
                    User_name=userEvents.User_Name,
                    Event=newEvents
                }
            };
            return events;
        }

        public static EventDTO ToEventDTO(this Events events){
            return new EventDTO{
                Title=events.Title,
                Description=events.Description,
                Date=events.Date,
                Time=events.Time,
                Location=events.Location,
                Image=events.Image,
                Quoata=events.Quoata
            };
        }
        public static List<GetEventsDTO> GetEventsDTO(this List<Events> events){
            return events.Select(x=>new GetEventsDTO{
                ID=x.ID,
                Title=x.Title,
                Description=x.Description
            }).ToList();
        }
        public static Events FromEventsDTO(this CreateEventDTO events, Guid created_by){
            return new Events{
                Title=events.Title,
                Description=events.Description,
                Date=events.Date,
                Time=events.Time,
                Location=events.Location,
                Image=events.Image,
                Quoata=events.Quoata,
                Created_by=created_by,
            };
        }
        public static List<UpdateEventDTO> ToUpdateEventDTO(this List<Events> events){
            return events.Select(x=>new UpdateEventDTO{
                Title=x.Title,
                Description=x.Description,
                Date=x.Date,
                Time=x.Time,
                Location=x.Location,
                Image=x.Image,
                Quoata=x.Quoata,
            }).ToList();
        }

        public static Events FromUpdateEventDTO(this UpdateEventDTO events){
            return new Events{
                Title=events.Title,
                Description=events.Description,
                Date=events.Date,
                Time=events.Time,
                Location=events.Location,
                Image=events.Image,
                Quoata=events.Quoata,
            };
        }
       public static AttendedEventsDTO ToAttendedEventsDTO(this List<User_Events> userEventsList){
            var usersList = new List<UsersDTO>();

            foreach (var userEvent in userEventsList)
            {
                
                var newUser = userEvent.Users.ToUsersDTO();
                Console.WriteLine(newUser.Name);
                usersList.Add(newUser);
            }
                var attendedEvent = new AttendedEventsDTO
                {
                    Event_title = userEventsList[0].Event.Title,
                    Event_id = userEventsList[0].Event.ID,
                    User = usersList,
                };
                return attendedEvent;
            }
    public static List<UserEventsDTO> ToUserCreatedEventsDTO(this List<User_Events> userEvents){
                var user_events=new List<UserEventsDTO>();
                foreach (var events in userEvents)
                {
                    var newEvents = events.Event.ToEventDTO();
                    user_events.Add(new UserEventsDTO {
                        User_name=events.User_Name,
                        Event=newEvents
                    });
                }
                return user_events;
           
            }
        public static List<EventDTO> ToHomepageDTO(this List<Events> users){
            var events = new List<EventDTO>();
            foreach (var user in users)
            {
                var newEvent = user.ToEventDTO();
                events.Add(newEvent);
            }
            return events;
        }
   }
 }