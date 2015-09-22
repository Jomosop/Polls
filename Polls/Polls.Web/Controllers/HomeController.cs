using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Polls.Domain.Models;
using Polls.Web.Infrastructure;

namespace Polls.Web.Controllers
{
    public class HomeController : Controller
    {
        //private IPollsDataSource _db;

        //public HomeController(IPollsDataSource db)
        //{
        //    _db = db;
        //}

        private PollsDb _db=new PollsDb();

        public ActionResult Index()
        {
            var questions = _db.Questions.Where(q => q.Published == true).ToList();

            return View(questions);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
