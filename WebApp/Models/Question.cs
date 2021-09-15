using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public Exam Exam { get; set; }
        public int ExamId { get; set; }
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
        //public string Anwser1 { get; set; }
        //public string Anwser2 { get; set; }
        //public string Anwser3 { get; set; }
        //public string Anwser4 { get; set; }
        public int CurrectAnwser { get; set; }
        public DateTime CreatedAT { get; set; } = DateTime.Now;
    }

    public class QuestionModel
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int Answer { get; set; } 
    }

}
