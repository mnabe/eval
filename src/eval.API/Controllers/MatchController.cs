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

        [HttpGet]
        public IEnumerable<Match> GetAll()
        {
           var response = _repository.GetAll();
            return response;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMatchDto matchDto)
        {
            Match match = new Match();
            match.Date = matchDto.Date;
            match.OpponentName = matchDto.OpponentName;
            match.ReasonForLoss = matchDto.ReasonForLoss;
            _repository.Create(match);
            return Ok();
        }
    }
}
