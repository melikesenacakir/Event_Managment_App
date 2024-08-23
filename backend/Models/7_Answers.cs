using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Answers
    {
        public int ID { get; set; }

        [ForeignKey("Questions")]
        public int Question_id { get; set; }
        public string Content { get; set; }=string.Empty;
        public Questions? Questions { get; set; }
    }
}