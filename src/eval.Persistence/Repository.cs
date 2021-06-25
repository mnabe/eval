using eval.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eval.Persistence
{
    public class Repository
    {
        private readonly TempContext _context;

        public Repository(TempContext context)
        {
            _context = context;
        }

        public IEnumerable<Match> GetAll()
        {
            var response = _context.MatchEntities.AsEnumerable();
            List<Match> matches = new List<Match>();
            foreach (var item in response)
            {
                Match match = new Match();
                match.Id = item.Id;
                match.Date = item.Date;
                match.OpponentName = item.OpponentName;
                match.ReasonForLoss = item.ReasonForLoss;
                matches.Add(match);
            } 
            return matches;
        }

        public void Create(Match match)
        {
            MatchEntity entity = new MatchEntity();
            entity.Date = match.Date;
            entity.OpponentName = match.OpponentName;
            entity.ReasonForLoss = match.ReasonForLoss;
            _context.MatchEntities.Add(entity);
            _context.SaveChanges();
        }
    }
}
