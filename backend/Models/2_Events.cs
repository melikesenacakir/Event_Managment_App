using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Events
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string Date {  get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Image {  get; set; } = string.Empty;
        public string Quoata { get; set; } = string.Empty;

        [ForeignKey("Users")]
        public Guid Created_by { get; set; } // This is a foreign key

        public ICollection<User_Events>? User_Events { get; set; }
        public ICollection<Feedbacks>? Feedbacks { get; set; }
        public ICollection<Messages>? Messages { get; set; }

        public Users? Users { get; set; }
    }

    [NotMapped]
    public class Created_Events{
        public Events? Events { get; set; }
        public Users? Users { get; set; }
    }
     [NotMapped]
     public class Joined_Events{
        public required string User_Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required int Enrollment { get; set; }
     }

}