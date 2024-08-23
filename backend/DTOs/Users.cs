using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class UsersDTO
    {
        [JsonPropertyName("id")]
        public Guid ID { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; } 
        [JsonPropertyName("surname")]
        public required string Surname { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        public required string Email { get; set; }
        [JsonPropertyName("password")]
        public required string Password { get; set; }
        [JsonPropertyName("username")]
        public required string Username { get; set; }
    }
    public class LoginDTO
    {
        [JsonPropertyName("username")]
        public required string Username { get; set; }
        [JsonPropertyName("password")]
        public required string Password { get; set; }
    }

    public class RegisterDTO
    {  
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("surname")]
        public required string Surname { get; set; }
        [JsonPropertyName("email")]
        public required string Email { get; set; }
        [JsonPropertyName("password")]
        public required string Password { get; set; }
        [JsonPropertyName("username")]
        public required string Username { get; set; }
    }
}