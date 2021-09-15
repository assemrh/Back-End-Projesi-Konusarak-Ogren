using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class AnsweredQuestion
    {
        public int Id { get; set; }
        public Answer Answer { get; set; }
        public int AnswerId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAT { get; set; } = DateTime.Now;

    }
}
