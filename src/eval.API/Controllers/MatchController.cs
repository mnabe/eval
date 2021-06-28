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
        public IActionResult GetAll(string username)
        {
            var response = _repository.GetAll(username);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMatchDto matchDto)
        {
            _repository.Create(matchDto);
            return Ok();
        }
    }
}
