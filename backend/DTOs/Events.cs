using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using backend.Controllers;

namespace backend.DTOs
{
    public class EventsDTO
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }= string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; }= string.Empty;
        [JsonPropertyName("date")]  
        public string Date {  get; set; } = string.Empty;
        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;
        [JsonPropertyName("location")]
        public string Location { get; set; } = string.Empty;
        [JsonPropertyName("image")]
        public string Image {  get; set; } = string.Empty;
        [JsonPropertyName("quota")]
        public string Quoata { get; set; } = string.Empty; 
        [JsonPropertyName("created_by")]
        public Guid Created_by { get; set; } // This is a foreign key
    }

    public class GetEventsDTO{
         [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }= string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; }= string.Empty;
    }

    public class CreatedByDto{
        [JsonPropertyName("name")]
        public string Name { get; set; }=string.Empty;
        [JsonPropertyName("iconPath")]
        public string IconPath { get; set; }=string.Empty;
    }

    public class EventDTO{ //creates new event
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        [JsonPropertyName("date")]  
        public string Date {  get; set; } = string.Empty;
        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;
        [JsonPropertyName("location")]
        public string Location { get; set; } = string.Empty;
        [JsonPropertyName("image")]
        public string Image {  get; set; } = string.Empty;
        [JsonPropertyName("quota")]
        public string Quoata { get; set; } = string.Empty;
    }

    public class CreateEventDTO{ //creates new event
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        [JsonPropertyName("date")]  
        public string Date {  get; set; } = string.Empty;
        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;
        [JsonPropertyName("location")]
        public string Location { get; set; } = string.Empty;
        [JsonPropertyName("image")]
        public string Image {  get; set; } = string.Empty;
        [JsonPropertyName("quota")]
        public string Quoata { get; set; } = string.Empty;
    }

    public class UserEventsDTO{ //users that attended an specific event
        [JsonPropertyName("events")]
        public EventDTO Event { get; set; }

        [JsonPropertyName("user_name")]
        public string User_name { get; set; } = string.Empty;

        
    }
     public class AttendedEventsDTO{ //users that attended an specific event
        [JsonPropertyName("event_title")]
         //user id session ya da jwtden alınacaktır
         public string Event_title { get; set; } = string.Empty;
        [JsonPropertyName("event_id")]
        public int Event_id { get; set; } 
        
        [JsonPropertyName("users")]
        public List<UsersDTO> User { get; set; }

        
    }


    public class UpdateEventDTO{
        [JsonPropertyName("title")]
        public string Title { get; set; }= string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; }= string.Empty;
        [JsonPropertyName("date")]  
        public string Date {  get; set; } = string.Empty;
        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;
        [JsonPropertyName("location")]
        public string Location { get; set; } = string.Empty;
        [JsonPropertyName("image")]
        public string Image {  get; set; } = string.Empty;
        [JsonPropertyName("quota")]
        public string Quoata { get; set; } = string.Empty;
    }
}