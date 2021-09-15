using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Classes;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Controllers.Api
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ValuesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{guid}")]
        public async Task<ActionResult<string>> GetActicleTextAsync([FromRoute]string guid)
        {
            
            return (await RssManeger.getItemsAsync()).Where(i => i.Guid.Text == guid).FirstOrDefault().Description;
        }



        [HttpPost("iscorrect")]
        public async Task<ActionResult<bool>> GetCurrectAnswers(QuestionModel question)
        {
            var questions = _context.Questions.Where(q => q.ExamId == question.ExamId && q.Id == question.Id);
            return (await questions.FirstOrDefaultAsync()).CurrectAnwser == question.Answer;
        }
    }
}
