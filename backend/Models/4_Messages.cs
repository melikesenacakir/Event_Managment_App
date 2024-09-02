using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Messages
    {
        public int ID { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Created_at { get; set; } = DateTime.Now;

        [ForeignKey("Users")]
        public Guid Craeted_by { get; set; }

        [ForeignKey("Event")]
        public int Event_id { get; set; }
        public Events? Events { get; set; }
        public Users? Users { get; set; }
    }
}