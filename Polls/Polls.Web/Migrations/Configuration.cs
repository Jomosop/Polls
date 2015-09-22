using Polls.Domain.Models;

namespace Polls.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Polls.Web.Infrastructure.PollsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Polls.Web.Infrastructure.PollsDb context)
        {
            context.Questions.AddOrUpdate(q => q.QuestionText, new Question() { QuestionText = "När Firar Bina Jul?", Published = true, UserId = 1, Alternatives = new Alternative[] { new Alternative() { AlternativeText = "Före Jul" }, new Alternative() { AlternativeText = "På Jul" }, new Alternative() { AlternativeText = "Efter Jul" }, } },
                new Question() { QuestionText = "Vilket Parti tänker Du Rösta På?", Published = true, UserId = 1, Alternatives = new Alternative[] { new Alternative() { AlternativeText = "Moderaterna" }, new Alternative() { AlternativeText = "Socialdemokraterna" } } },
                new Question() { QuestionText = "Vad anser du om skolan?", Published = true, Alternatives = new Alternative[] { new Alternative() { AlternativeText = "Jaaa" }, new Alternative() { AlternativeText = "Nja" } } });

        }
    }
}
