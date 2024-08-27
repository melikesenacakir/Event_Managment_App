using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
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
        public ICollection<User_Events>? User_Events { get; set; }
        public ICollection<Events>? Events { get; set; }
        public ICollection<Feedbacks>? Feedbacks { get; set; }
        public ICollection<Messages>? Messages { get; set; }

    }
}