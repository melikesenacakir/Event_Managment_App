using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class MessagesDTO
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
        [JsonPropertyName("created_by")]
        public string Created_by { get; set; } = string.Empty;
        [JsonPropertyName("created_at")]
        public string Created_at { get; set; } = string.Empty;
        [JsonPropertyName("event_id")]
        public int Event_id { get; set; } 
    }
    public class MessageDTO // send message to user
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
        [JsonPropertyName("created_by")]
        public string Created_by { get; set; } = string.Empty;
        [JsonPropertyName("created_at")]
        public string Created_at { get; set; } = string.Empty;
        [JsonPropertyName("event_id")]
        public int Event_id { get; set; }
    }

    public class CreateMessagesDTO //creates new message
    {  
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
    }
}