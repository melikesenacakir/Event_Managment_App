using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class MessagesDTO //creates new message
    {
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
        [JsonPropertyName("created_by")]
        public string Created_by { get; set; } = string.Empty;
        [JsonPropertyName("created_at")]
        public string Created_at { get; set; } = string.Empty;
        [JsonPropertyName("event_id")]
        public string Event_id { get; set; } = string.Empty;
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
        public string Event_Name { get; set; } = string.Empty;
    }
}