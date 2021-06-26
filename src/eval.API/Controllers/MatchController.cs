using eval.API.DTO;
using eval.Domain;
using eval.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eval.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        public readonly Repository _repository;
        public MatchController(Repository repository)
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
            Match match = new Match();
            match.UserName = matchDto.UserName;
            match.Date = matchDto.Date;
            match.OpponentName = matchDto.OpponentName;
            match.ReasonForLoss = matchDto.ReasonForLoss;
            _repository.Create(match);
            return Ok();
        }
    }
}
