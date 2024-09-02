using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Feedbacks
    {
        public int ID { get; set; }

        [ForeignKey("Users")]
        public Guid User_id { get; set; }

        [ForeignKey("Events")]
        public int Event_id { get; set; }

        //public ICollection<Questions>? Questions { get; set; }
        public string Feedback { get; set; } = string.Empty;

        [NotMapped]
        public string User_name { get; set; } = string.Empty;

        [NotMapped]
        public string Event_title { get; set; } = string.Empty;

        public Users? Users { get; set; }
        public Events? Events { get; set; }
    }
}