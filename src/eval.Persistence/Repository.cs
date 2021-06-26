using eval.Domain;
using System.Collections.Generic;
using System.Linq;

namespace eval.Persistence
{
    public class Repository
    {
        private readonly TempContext _context;
        public Repository(TempContext context)
        {
            _context = context;
        }

        public IEnumerable<Match> GetAll(string username)
        {
            var response = _context.MatchEntities.AsEnumerable().Where(x => x.UserName == username);
            List<Match> matches = new List<Match>();
            foreach (var item in response)
            {
                Match match = new Match();
                match.Id = item.Id;
                match.UserName = item.UserName;
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
            entity.UserName = match.UserName;
            entity.OpponentName = match.OpponentName;
            entity.ReasonForLoss = match.ReasonForLoss;
            _context.MatchEntities.Add(entity);
            _context.SaveChanges();
        }
    }
}
