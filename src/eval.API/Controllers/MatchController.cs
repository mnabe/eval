using eval.Domain;
using eval.Persistence;
using eval.Persistence.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eval.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        public readonly IRepository _repository;
        public MatchController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("username")]
        public IEnumerable<Match> GetAll(string username)
        {
            var response = _repository.GetAll(username);
            return response;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMatchDto matchDto)
        {
            //Match match = new Match();
            //match.UserName = matchDto.UserName;
            //match.Date = matchDto.Date;
            //match.OpponentName = matchDto.OpponentName;
            //match.ReasonForLoss = matchDto.ReasonForLoss;
            _repository.Create(matchDto);
            return Ok();
        }
    }
}
