using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Polls.Domain.Models;
using Polls.Web.Infrastructure;
using Polls.Web.Models;
using Polls.Web.Services;

namespace Polls.Web.Controllers
{
    public class QuestionController : Controller
    {
        //private readonly IPollsDataSource _db;
        
        //public QuestionController(IPollsDataSource db)
        //{
        //    _db = db;
        //}

        private PollsDb _db = new PollsDb();
        
        public ActionResult Vote(int id)
        {
            Question question = _db.Questions.Single(q => q.Id == id);
            return View(question);
        }

        
        public ActionResult Thanks(QuestionModel model)
        {
            CookieService cookie=new CookieService();
            Alternative alternative = _db.Alternatives.Single(a => a.Id == model.AlternativeId);
            Question question = _db.Questions.Single(q => q.Id == model.QuestionId);
            
            if (cookie.VoteAllowed(question.Id))
            {
                alternative.Votes++;
                _db.SaveChanges();
                cookie.MakeVoteAuthenticate(question.Id);
                
                return View(question);
            }
            else return View("VoteDenied",question);
        }

        public ActionResult VoteResult(int id)
        {
            Question question = _db.Questions.Single(q => q.Id == id);
            return View(question);
        }

    }
}
