using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class User_Events
    {
        public int ID { get; set; }

        [ForeignKey("Users")]
        public Guid User_id { get; set; }

        [ForeignKey("Events")]
        public int Event_id { get; set; }

        public Users? Users { get; set; }
        public Events? Events { get; set; }

        [NotMapped]
        public string User_Name { get; set; } = string.Empty;
        [NotMapped]
        public Events Event { get; set; }


    }

}