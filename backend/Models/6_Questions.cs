using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Questions
    {
        public int ID { get; set; }
        public required string Content { get; set; }
        public string Type { get; set; } = string.Empty;

        [ForeignKey("Feedbacks")]
        public int Feedback_id { get; set; } // This is a foreign key
        public Feedbacks? Feedbacks { get; set; }
        public ICollection<Answers>? Answers { get; set; }
    }
}