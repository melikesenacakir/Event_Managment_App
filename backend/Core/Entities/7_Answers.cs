using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
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