using eval.Domain;
using eval.Persistence;
using eval.Persistence.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            var response = _repository.Get(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMatchDto matchDto)
        {
            await _repository.Create(matchDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditMatchDto matchDto)
        {
            await _repository.Edit(matchDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}
