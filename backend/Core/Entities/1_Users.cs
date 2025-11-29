using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Users
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }=string.Empty;
        public string Username { get; set; }=string.Empty;
        
    }
}