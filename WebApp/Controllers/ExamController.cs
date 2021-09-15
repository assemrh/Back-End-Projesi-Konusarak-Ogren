using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Classes;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ExamController : Controller
    {
        private readonly AppDbContext _context;
        public ExamController(AppDbContext context)
        {
            _context = context;
        }
        // GET: ExamController
        public async Task<ActionResult> Index()
        {
            var Exams = _context.Exams;
            return View(await Exams.ToListAsync());
        }

        // GET: ExamController/Details/5
        public ActionResult Details(int id)
        {
            var exam = _context.Exams.Find(id);
            return View(exam);
        }
        [Authorize(Roles = "student")]
        [HttpGet("/[Controller]/{id}")]  
        public async Task<ActionResult> AnswerViewAsync(int id)
        {
            var exam = _context.Exams.Include(e => e.Questions).ThenInclude(e=> e.Answers).Where(e => e.Id == id);
            return View(await exam.FirstOrDefaultAsync());
        }

        // GET: ExamController/Create
        [Authorize(Roles = "teacher")]
        [HttpGet("/[Controller]/Create")]
        public async Task<ActionResult> Create()
        {
            ViewBag.Items = await RssManeger.getItemsAsync();
            return View();
        }

        // POST: ExamController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Exam exam)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Task<int> task;
                   var result = await _context.Exams.AddAsync(exam);
                    await(task =  _context.SaveChangesAsync());
                    if (task.IsCompleted )
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "Sınav Oluşturulmaddı, lütfem tekrar deneyin");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewBag.Items = await RssManeger.getItemsAsync();
            return View(exam);

        }

        // GET: ExamController/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: ExamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
