using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Users
    {
        public Guid ID { get; set; }
        public required string Name { get; set; } 
        public required string Surname { get; set; }
        public string Role { get; set; } = string.Empty;
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Username { get; set; }
        public ICollection<User_Events>? User_Events { get; set; }
        public ICollection<Events>? Events { get; set; }
        public ICollection<Feedbacks>? Feedbacks { get; set; }
        public ICollection<Messages>? Messages { get; set; }
    }
}