using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Polls.Domain.Models;
using Polls.Web.Infrastructure;

namespace Polls.Web.Services
{
    public class CookieService
    {
        public bool VoteAllowed(int questionId)
        {
            if (HttpContext.Current.Request.Cookies["Poll"+questionId] == null)
            {
                return true;
            }
            else
            {
                return false;
                //HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("PollCookie");
                //Guid guid=new Guid(cookie["UserId"]);
                //using (PollsDb db = new PollsDb())
                //{
                //    if (db.Votes.Any(x => x.Id == guid && x.QuestionId == questionId)) return false;
                //    else return true;
                //}
            }
        }

        public void MakeVoteAuthenticate(int questionId)
        {
            HttpCookie cookie = new HttpCookie("Poll"+questionId);
            //Guid guid = Guid.NewGuid();
            cookie.Values["Poll"] = "Hej";
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.SetCookie(cookie);
            //using (PollsDb db = new PollsDb())
            //{
            //    db.Votes.Add(new Votes(){Expires = DateTime.Now.AddDays(1),Id = guid,QuestionId = questionId});
            //    db.SaveChanges();
            //}
        }
    }
}