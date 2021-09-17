using eval.Domain;
using eval.Persistence.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eval.Persistence
{
    public interface IRepository
    {
        Match Get(int id);
        IEnumerable<Match> GetAll(string username);
        Task Create(CreateMatchDto matchDto);
        Task Edit(EditMatchDto matchDto);
    }
}
