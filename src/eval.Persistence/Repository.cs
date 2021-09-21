using AutoMapper;
using eval.Domain;
using eval.Persistence.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eval.Persistence
{
    public class Repository: IRepository
    {
        private readonly MatchContext _context;
        private readonly IMapper _mapper;
        public Repository(MatchContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Match Get(int id)
        {
            var response = _context.MatchEntities.FirstOrDefault(x => x.Id == id);
            Match match = _mapper.Map<Match>(response);
            return match;
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
        public async Task Create(CreateMatchDto matchDto)
        {
            MatchEntity entity = _mapper.Map<MatchEntity>(matchDto);
            await _context.MatchEntities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(EditMatchDto matchDto)
        {
            var entity = await _context.MatchEntities.FindAsync(matchDto.Id);
            entity.Date = matchDto.Date;
            entity.OpponentName = matchDto.OpponentName;
            entity.ReasonForLoss = matchDto.ReasonForLoss;

            //_context.Attach(entity);
            //_context.Entry(entity).Property(p => p.Date).IsModified = true;
            //_context.Entry(entity).Property(p => p.OpponentName).IsModified = true;
            //_context.Entry(entity).Property(p => p.ReasonForLoss).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = _context.MatchEntities.FirstOrDefault(x => x.Id == id);
            _context.MatchEntities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
