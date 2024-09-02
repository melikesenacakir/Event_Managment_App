using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using backend.Controllers;

namespace backend.DTOs
{
    public class FeedbacksDTO
    {
        [JsonPropertyName("id")]
        public string User_name { get; set; }=string.Empty;
        [JsonPropertyName("event_title")]
        public string Event_title { get; set; }=string.Empty;
        [JsonPropertyName("event_id")]
        public int Event_id { get; set; }
        [JsonPropertyName("feedback")]
       // public List<QuestionDTO> Questions { get; set; } = [];
        public string Feedback { get; set; } = string.Empty;
    }
    public class QuestionDTO{
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("content")]
        public required string Content { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
        [JsonPropertyName("answers")]
        public AnswerDTO Answers { get; set; } = new AnswerDTO();
    }
    public class AnswerDTO{
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }=string.Empty;
    }

    public class CreateFeedbackDTO{
        [JsonPropertyName("feedback")]
        public string Feedback { get; set; } = string.Empty;
    }
}