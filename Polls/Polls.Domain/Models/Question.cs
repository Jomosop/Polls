using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polls.Domain.Models
{
    public class Question
    {
        public virtual int Id { get; set; }
        public virtual string QuestionText { get; set; }
        public virtual bool Published { get; set; }
        public virtual IList<Alternative> Alternatives { get; set; }
        public virtual int UserId { get; set; }
    }
}
