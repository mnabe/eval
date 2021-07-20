using AutoMapper;
using eval.Domain;
using eval.Persistence.DTO;
using System.Collections.Generic;
using System.Linq;

namespace eval.Persistence
{
    public class Repository: IRepository
    {
        private readonly TempContext _context;
        private readonly IMapper _mapper;
        public Repository(TempContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Match> GetAll(string username)
        {
            var response = _context.MatchEntities.AsEnumerable().Where(x => x.UserName == username); //TODO: Should be possible to map to match while retrieving matches, which would get rid of the matches-List and foreach loop
            List<Match> matches = new List<Match>();
            foreach (var item in response)
            {
                Match match = _mapper.Map<Match>(item);
                matches.Add(match);
            } 
            return matches;
        }
        public void Create(CreateMatchDto matchDto)
        {
            MatchEntity entity = _mapper.Map<MatchEntity>(matchDto);
            _context.MatchEntities.Add(entity);
            _context.SaveChanges();
        }
    }
}
