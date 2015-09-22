using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using Polls.Domain.Models;

namespace Polls.Web.Infrastructure
{
    public class PollsDb:DbContext
    {
        public PollsDb():base("DefaultConnection")
        {
            
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Alternative> Alternatives { get; set; }
        

        //IQueryable<Question> IPollsDataSource.Questions
        //{
        //    get { return Questions; }
            
        //}

        //IQueryable<Alternative> IPollsDataSource.Alternatives
        //{
        //    get { return Alternatives; }
        //}

        //void IPollsDataSource.Save()
        //{
        //    SaveChanges();
        //}

        

    }
}