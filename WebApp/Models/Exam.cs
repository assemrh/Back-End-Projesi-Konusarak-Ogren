using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public DateTime CreatedAT { get; set; } = DateTime.Now;

    }
    public class ExamModel
    {
        public int Id { get; set; }
        public List<string> Answers { get; set; }

    }
}
