using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Polls.Domain.Models;
using Polls.Web.Filters;
using Polls.Web.Infrastructure;
using WebMatrix.WebData;

namespace Polls.Web.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class EditQuestionController : Controller
    {
        //private IPollsDataSource _db;

        //public EditQuestionController(IPollsDataSource db)
        //{
        //    _db = db;
        //}

        private PollsDb _db = new PollsDb();

        public ActionResult Edit()
        {
            int userId = WebSecurity.CurrentUserId;
            List<Question> questions = _db.Questions.Where(q => q.UserId == userId).ToList();
            
            return View(questions);
        }
        [HttpGet]
        public ActionResult EditQuestion(int id)
        {
            Question question = _db.Questions.Single(q => q.Id == id);
            return View(question);
        }

        [HttpPost]
        public ActionResult EditQuestion(Question question, string btnSubmit)
        {
            List<int> alternativeDeletId=new List<int>();
            if (question.Alternatives[question.Alternatives.Count - 1].AlternativeText == null) question.Alternatives.RemoveAt(question.Alternatives.Count - 1);
            //List<int> number=new List<int>();
            //for (int i=question.Alternatives.Count-1;i>=0;i--)
            //{
            //    if(question.Alternatives[i].AlternativeText==null) number.Add(i);
            //}
            //foreach (var row in number)
            //{
            //    question.Alternatives.RemoveAt(row);
            //}
            if (btnSubmit == "Add Alternative")
            {
                return View(question); 
            }
            if (btnSubmit == "Save")
            {
                var quest = _db.Questions.Single(q => q.Id == question.Id);
                quest.Published = question.Published;
                quest.QuestionText = question.QuestionText;
                int max;
                
                for (int i = question.Alternatives.Count-1; i >=0; i--)
                {
                    if (i < quest.Alternatives.Count)
                    {
                        if (question.Alternatives[i].AlternativeText == null)
                        {
                            int a = quest.Alternatives[i].Id;
                            alternativeDeletId.Add(a);
                            quest.Alternatives.RemoveAt(i);
                        }
                    }
                    else quest.Alternatives.Add(new Alternative(){AlternativeText = question.Alternatives[i].AlternativeText});
                }
                
                    _db.SaveChanges();
                
                return RedirectToAction("Edit");
            }
            return View(question);
        }

        [HttpGet]
        public ActionResult NewQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewQuestion(Question question,string btnSubmit)
        {
            if (question.Alternatives[question.Alternatives.Count - 1].AlternativeText == null) question.Alternatives.RemoveAt(question.Alternatives.Count - 1);
            if (btnSubmit == "Add Alternative")
            {
                return View(question);
            }
            if (btnSubmit == "Create")
            {
                question.UserId = (int)WebSecurity.CurrentUserId;
                _db.Questions.Add(question);

                _db.SaveChanges();
                
                return RedirectToAction("Edit");
            }
            else return View(question);
        }

        public ActionResult Delete(int id)
        {
            var question = _db.Questions.Single(q => q.Id == id);
            _db.Questions.Remove(question);
            _db.SaveChanges();
            return RedirectToAction("Edit");
        }

        public ActionResult Reset(int id)
        {
            var question = _db.Questions.Single(q => q.Id == id);
            foreach (var alternative in question.Alternatives)
            {
                alternative.Votes = 0;
            }
            _db.SaveChanges();
            return RedirectToAction("Edit");
        }
    }
}
