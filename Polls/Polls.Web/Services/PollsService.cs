using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polls.Domain.Models;

namespace Polls.Web.Services
{
    public class PollsService
    {
        private readonly IPollsDataSource _db;

        public PollsService(IPollsDataSource db)
        {
            _db = db;
        }

       //public void SaveNewQuestion(Question question)
       // { 
       //     _db.
       // }
    }
}