using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polls.Domain.Models;

namespace Polls.Web.Models
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public int AlternativeId { get; set; }
    }
}