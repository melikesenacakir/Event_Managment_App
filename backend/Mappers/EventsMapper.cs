using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;
using backend.DTOs;

namespace backend.Mappers
{
    public static class EventsMapper
    {
        public static EventsDTO ToEventsDTO(this Models.Events events){
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
        public static UserEventsDTO ToUserEventsDTO(this Models.User_Events userEvents){
            return new UserEventsDTO{
                Event_name=userEvents.Event_Name,
                Event_id=userEvents.Event_id,
                User_name=userEvents.User_Name,
                User_id=userEvents.User_id
            };
        }
    }
}