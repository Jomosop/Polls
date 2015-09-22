using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polls.Domain.Models
{
    public interface IPollsDataSource
    {
        IQueryable<Question> Questions { get; }
        IQueryable<Alternative> Alternatives { get; }
        
        void Save();
    }
}
